using Colossal.Entities;
using Game.Prefabs;
using Game;
using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace DemandMaster
{
    public partial class DemandPrefabSystem : GameSystemBase
    {
        public static PrefabSystem prefabSystem;
        public static EntityQuery prefabQuery;
        public Setting setting = Mod.m_Setting;

        protected override void OnCreate()
        {
            base.OnCreate();
            prefabSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<PrefabSystem>();
            prefabQuery = GetEntityQuery(new EntityQueryDesc()
            {
                All = [
                    ComponentType.ReadWrite<DemandParameterData>()
                    ],
            });
            RequireForUpdate(prefabQuery);
        }
        protected override void OnUpdate()
        {
            var entites = prefabQuery.ToEntityArray(Allocator.Temp);
            Entity entity;
            //Mod.log.Info(entites.Length);

            if (entites.Length == 1)
            {
                entity = entites[0];
                if (!prefabSystem.TryGetPrefab(entity, out PrefabBase prefabBase))
                {
                    return;
                }

                if (prefabBase != null)
                {
                    if (EntityManager.TryGetComponent(entity, out DemandParameterData data))
                    {
                        data.m_MinimumHappiness = setting.MinimumHappiness;
                        data.m_HappinessEffect = setting.HappinessEffect;
                        data.m_TaxEffect = setting.TaxEffect;
                        data.m_StudentEffect = setting.StudentEffect;
                        data.m_AvailableWorkplaceEffect = setting.AvailableWorkplaceEffect;
                        data.m_HomelessEffect = setting.HomelessEffect;

                        data.m_NeutralHappiness = setting.NeutralHappiness;
                        data.m_NeutralUnemployment = setting.NeutralUnemployment;
                        data.m_NeutralAvailableWorkplacePercentage = setting.NeutralAvailableWorkplacePercentage;
                        data.m_NeutralHomelessness = setting.NeutralHomelessness;

                        data.m_FreeResidentialRequirement = new int3(setting.FreeResidentialRequirement_Low, setting.FreeResidentialRequirement_Medium, setting.FreeResidentialRequirement_High);
                        data.m_FreeCommercialProportion = setting.FreeCommercialProportion;
                        data.m_FreeIndustrialProportion = setting.FreeIndustrialProportion;

                        data.m_CommercialStorageMinimum = setting.CommercialStorageMinimum;
                        data.m_CommercialStorageEffect = setting.CommercialStorageEffect;
                        data.m_CommercialBaseDemand = setting.CommercialBaseDemand;

                        data.m_IndustrialStorageMinimum = setting.IndustrialStorageMinimum;
                        data.m_IndustrialStorageEffect = setting.IndustrialStorageEffect;
                        data.m_IndustrialBaseDemand = setting.IndustrialBaseDemand;
                        data.m_ExtractorBaseDemand = setting.ExtractorBaseDemand;
                        data.m_StorageDemandMultiplier = setting.StorageDemandMultiplier;

                        data.m_CommuterWorkerRatioLimit = setting.CommuterWorkerRatioLimit;
                        data.m_CommuterSlowSpawnFactor = setting.CommuterSlowSpawnFactor;

                        data.m_CommuterOCSpawnParameters = ReVal(setting.CommuterOCSpawnParameters_Road, setting.CommuterOCSpawnParameters_Train, setting.CommuterOCSpawnParameters_Air, setting.CommuterOCSpawnParameters_Ship);
                        data.m_TouristOCSpawnParameters = ReVal(setting.TouristOCSpawnParameters_Road, setting.TouristOCSpawnParameters_Train, setting.TouristOCSpawnParameters_Air, setting.TouristOCSpawnParameters_Ship);
                        data.m_CitizenOCSpawnParameters = ReVal(setting.CitizenOCSpawnParameters_Road, setting.CitizenOCSpawnParameters_Train, setting.CitizenOCSpawnParameters_Air, setting.CitizenOCSpawnParameters_Ship);
                        data.m_TeenSpawnPercentage = setting.TeenSpawnPercentage;
                        data.m_FrameIntervalForSpawning = new int3(setting.FrameIntervalForSpawning_Res, setting.FrameIntervalForSpawning_Com, setting.FrameIntervalForSpawning_Ind);
                        data.m_HouseholdSpawnSpeedFactor = setting.HouseholdSpawnSpeedFactor;
                        data.m_NewCitizenEducationParameters =ReValEdu(setting.NewCitizenEducationParameters_Uneducated, setting.NewCitizenEducationParameters_PoorlyEducated, setting.NewCitizenEducationParameters_Educated, setting.NewCitizenEducationParameters_WellEducated, setting.NewCitizenEducationParameters_HighlyEducated);

                        EntityManager.SetComponentData(entity, data);
                    }
                }
            }
        }

        public float4 ReValEdu(float l0, float l1, float l2, float l3, float l4)
        {
            float total = l0 + l1 + l2 + l3 + l4;
            int xl0 = (int)Math.Round(100 * l0 / total);
            int xl1 = (int)Math.Round(100 * l1 / total);
            int xl2 = (int)Math.Round(100 * l2 / total);
            int xl3 = (int)Math.Round(100 * l3 / total);
            int xl4 = (int)Math.Round(100 * l4 / total);
            int xTotal = xl0 + xl1 + xl2 + xl3 + xl4;
            int currentTotal = 0;

            float yl0 = 0.20f;
            float yl1 = 0.20f;
            float yl2 = 0.20f;
            float yl3 = 0.20f;


            if (xTotal != 0)
            {
                if (xTotal != 100 && xl4 != 0)
                {
                    int diff = 100 - xTotal;
                    xl4 = xl4 + diff;
                }
                else if (xTotal != 100 && xl3 != 0)
                {
                    int diff = 100 - xTotal;
                    xl3 = xl3 + diff;
                }
                else if (xTotal != 100 && xl2 != 0)
                {
                    int diff = 100 - xTotal;
                    xl2 = xl2 + diff;
                }
                else if (xTotal != 100 && xl1 != 0)
                {
                    int diff = 100 - xTotal;
                    xl1 = xl1 + diff;
                }
                if (xl0 != 0)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xl0);
                    yl0 = value / 100f;
                    currentTotal += value;
                }
                if (xl1 != 0)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xl1);
                    yl1 = value / 100f;
                    currentTotal += value;
                }
                if (xl2 != 0)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xl2);
                    yl2 = value / 100f;
                    currentTotal += value;
                }
                if (xl3 != 0)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xl3);
                    yl3 = value / 100f;
                    //currentTotal += value;
                }
            }
            return new float4(yl0, yl1, yl2, yl3);
        }

        public float4 ReVal(float Road, float Train, float Air, float Ship)
        {
            float total = Road + Train + Air + Ship;
            int xRoad = (int)Math.Round(100 * Road / total);
            int xTrain = (int)Math.Round(100 * Train / total);
            int xAir = (int)Math.Round(100 * Air / total);
            int xShip = (int)Math.Round(100 * Ship / total);
            int xTotal = xRoad + xTrain + xAir + xShip;
            int currentTotal = 0;

            float yRoad = 0.25f;
            float yTrain = 0.25f;
            float yAir = 0.25f;
            float yShip = 0.25f;

            if (xTotal != 0)
            {
                if (xTotal != 100 && xShip != 0)
                {
                    int diff = 100 - xTotal;
                    xShip = xShip + diff;
                }
                else if (xTotal != 100 && xAir != 0)
                {
                    int diff = 100 - xTotal;
                    xAir = xAir + diff;
                }
                else if (xTotal != 100 && xTrain != 0)
                {
                    int diff = 100 - xTotal;
                    xTrain = xTrain + diff;
                }
                if (Road != 0f)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xRoad);
                    yRoad = value / 100f;
                    currentTotal += value;
                }
                if (Train != 0f)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xTrain);
                    yTrain = value / 100f;
                    currentTotal += value;
                }
                if (Air != 0f)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xAir);
                    yAir = value / 100f;
                    currentTotal += value;
                }
                if (Ship != 0f)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xShip);
                    yShip = value / 100f;
                    //currentTotal += value;
                }
            }
            return new float4(yRoad, yTrain, yAir, yShip);
        }
    }
}