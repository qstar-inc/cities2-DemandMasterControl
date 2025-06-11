using System;
using Colossal.Entities;
using Game;
using Game.City;
using Game.Prefabs;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace DemandMasterControl.Systems
{
    public partial class DemandPrefabSystem : GameSystemBase
    {
        public static PrefabSystem prefabSystem;
        public static EntityQuery prefabQuery;
        public Setting setting = Mod.m_Setting;

        protected override void OnCreate()
        {
            base.OnCreate();
            prefabSystem =
                World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<PrefabSystem>();
            prefabQuery = GetEntityQuery(
                new EntityQueryDesc()
                {
                    All = new[] { ComponentType.ReadOnly<DemandParameterData>() },
                }
            );
            RequireForUpdate(prefabQuery);
        }

        protected override void OnUpdate()
        {
            Setting settings = Mod.m_Setting;
            if (settings.Changes)
            {
                try
                {
                    var entities = prefabQuery.ToEntityArray(Allocator.Temp);
                    foreach (Entity entity in entities)
                    {
                        if (!prefabSystem.TryGetPrefab(entity, out PrefabBase prefabBase))
                        {
                            continue;
                        }

                        if (prefabBase != null)
                        {
                            if (
                                EntityManager.TryGetComponent(entity, out DemandParameterData data)
                                && prefabSystem.GetPrefabName(entity).Contains("DemandParameters")
                            )
                            {
                                data.m_MinimumHappiness = setting.MinimumHappiness;
                                data.m_HappinessEffect = setting.HappinessEffect;
                                data.m_TaxEffect = new float3(
                                    setting.TaxEffect_x,
                                    setting.TaxEffect_y,
                                    setting.TaxEffect_z
                                );
                                data.m_StudentEffect = setting.StudentEffect;
                                data.m_AvailableWorkplaceEffect = setting.AvailableWorkplaceEffect;
                                data.m_HomelessEffect = setting.HomelessEffect;

                                data.m_NeutralHappiness = setting.NeutralHappiness;
                                data.m_NeutralUnemployment = setting.NeutralUnemployment;
                                data.m_NeutralAvailableWorkplacePercentage =
                                    setting.NeutralAvailableWorkplacePercentage;
                                data.m_NeutralHomelessness = setting.NeutralHomelessness;

                                data.m_FreeResidentialRequirement = new int3(
                                    setting.FreeResidentialRequirement_Low,
                                    setting.FreeResidentialRequirement_Medium,
                                    setting.FreeResidentialRequirement_High
                                );
                                //data.m_FreeCommercialProportion = setting.FreeCommercialProportion;
                                //data.m_FreeIndustrialProportion = setting.FreeIndustrialProportion;

                                //data.m_CommercialStorageMinimum = setting.CommercialStorageMinimum;
                                //data.m_CommercialStorageEffect = setting.CommercialStorageEffect;
                                data.m_CommercialBaseDemand = setting.CommercialBaseDemand;

                                //data.m_IndustrialStorageMinimum = setting.IndustrialStorageMinimum;
                                //data.m_IndustrialStorageEffect = setting.IndustrialStorageEffect;
                                data.m_IndustrialBaseDemand = setting.IndustrialBaseDemand;
                                data.m_ExtractorBaseDemand = setting.ExtractorBaseDemand;
                                //data.m_StorageDemandMultiplier = setting.StorageDemandMultiplier;

                                data.m_CommuterSlowSpawnFactor = setting.CommuterSlowSpawnFactor;
                                if (!setting.IsRealisticTripsRunning)
                                {
                                    data.m_CommuterWorkerRatioLimit =
                                        setting.CommuterWorkerRatioLimit;
                                    data.m_CommuterOCSpawnParameters = Reval4uf4(
                                        setting.CommuterOCSpawnParameters_Road,
                                        setting.CommuterOCSpawnParameters_Train,
                                        setting.CommuterOCSpawnParameters_Air,
                                        setting.CommuterOCSpawnParameters_Ship
                                    );
                                }
                                data.m_TouristOCSpawnParameters = Reval4uf4(
                                    setting.TouristOCSpawnParameters_Road,
                                    setting.TouristOCSpawnParameters_Train,
                                    setting.TouristOCSpawnParameters_Air,
                                    setting.TouristOCSpawnParameters_Ship
                                );
                                data.m_CitizenOCSpawnParameters = Reval4uf4(
                                    setting.CitizenOCSpawnParameters_Road,
                                    setting.CitizenOCSpawnParameters_Train,
                                    setting.CitizenOCSpawnParameters_Air,
                                    setting.CitizenOCSpawnParameters_Ship
                                );
                                data.m_TeenSpawnPercentage = setting.TeenSpawnPercentage;
                                data.m_FrameIntervalForSpawning = new int3(
                                    setting.FrameIntervalForSpawning_Res,
                                    setting.FrameIntervalForSpawning_Com,
                                    setting.FrameIntervalForSpawning_Ind
                                );
                                data.m_HouseholdSpawnSpeedFactor =
                                    setting.HouseholdSpawnSpeedFactor;
                                data.m_HotelRoomPercentRequirement =
                                    setting.HotelRoomPercentRequirement;
                                data.m_NewCitizenEducationParameters = Reval5u4f(
                                    setting.NewCitizenEducationParameters_Uneducated,
                                    setting.NewCitizenEducationParameters_PoorlyEducated,
                                    setting.NewCitizenEducationParameters_Educated,
                                    setting.NewCitizenEducationParameters_WellEducated,
                                    setting.NewCitizenEducationParameters_HighlyEducated
                                );

                                EntityManager.SetComponentData(entity, data);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Mod.log.Error(e);
                }
            }
        }

        public float4 Reval5u4f(float l0, float l1, float l2, float l3, float l4)
        {
            float total = l0 + l1 + l2 + l3 + l4;

            float yl0 = 100f / 5f;
            float yl1 = 100f / 5f;
            float yl2 = 100f / 5f;
            float yl3 = 100f / 5f;

            if (total == 0f || total - l4 == 0f)
            {
                return new float4(yl0, yl1, yl2, yl3);
            }

            float xl0 = 100f * l0 / total;
            float xl1 = 100f * l1 / total;
            float xl2 = 100f * l2 / total;
            float xl3 = 100f * l3 / total;
            float xl4 = 100f * l4 / total;
            float xTotal = xl0 + xl1 + xl2 + xl3 + xl4;
            float currentTotal = 0f;

            if (xTotal != 0f | total != 0f)
            {
                if (xTotal != 100f && xl4 != 0f)
                {
                    //int diff = 100 - xTotal;
                    //xl4 += diff;
                }
                else if (xTotal != 100f && xl3 != 0f)
                {
                    float diff = 100f - xTotal;
                    xl3 += diff;
                }
                else if (xTotal != 100f && xl2 != 0f)
                {
                    float diff = 100f - xTotal;
                    xl2 += diff;
                }
                else if (xTotal != 100f && xl1 != 0f)
                {
                    float diff = 100f - xTotal;
                    xl1 += diff;
                }
                if (xl0 != 0f)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl0);
                    yl0 = value / 100f;
                    currentTotal += value;
                }
                if (xl1 != 0f)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl1);
                    yl1 = value / 100f;
                    currentTotal += value;
                }
                if (xl2 != 0f)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl2);
                    yl2 = value / 100f;
                    currentTotal += value;
                }
                if (xl3 != 0f)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl3);
                    yl3 = value / 100f;
                    //currentTotal += value;
                }
            }
            return new float4(yl0, yl1, yl2, yl3);
        }

        public float4 Reval4uf4(float l0, float l1, float l2, float l3)
        {
            float total = l0 + l1 + l2 + l3;

            float yl0 = 100f / 4f;
            float yl1 = 100f / 4f;
            float yl2 = 100f / 4f;
            float yl3 = 100f / 4f;

            if (total == 0f)
            {
                return new float4(yl0, yl1, yl2, yl3);
            }

            float xl0 = 100f * l0 / total;
            float xl1 = 100f * l1 / total;
            float xl2 = 100f * l2 / total;
            float xl3 = 100f * l3 / total;
            float xTotal = xl0 + xl1 + xl2 + xl3;
            float currentTotal = 0f;

            if (xTotal != 0f)
            {
                if (xTotal != 100f && xl3 != 0f)
                {
                    float diff = 100f - xTotal;
                    xl3 += diff;
                }
                else if (xTotal != 100f && xl2 != 0f)
                {
                    float diff = 100f - xTotal;
                    xl2 += diff;
                }
                else if (xTotal != 100f && xl1 != 0f)
                {
                    float diff = 100f - xTotal;
                    xl1 += diff;
                }
                if (l0 != 0f)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl0);
                    yl0 = value / 100f;
                    currentTotal += value;
                }
                if (l1 != 0f)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl1);
                    yl1 = value / 100f;
                    currentTotal += value;
                }
                if (l2 != 0f)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl2);
                    yl2 = value / 100f;
                    currentTotal += value;
                }
                if (l3 != 0f)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl3);
                    yl3 = value / 100f;
                    //currentTotal += value;
                }
            }
            return new float4(yl0, yl1, yl2, yl3);
        }
    }
}
