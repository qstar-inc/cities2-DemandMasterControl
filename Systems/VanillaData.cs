using Colossal.Entities;
using Game;
using Game.City;
using Game.Prefabs;
using Game.SceneFlow;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace DemandMasterControl.Systems
{
    public static class VanillaDataStorage
    {
        public static VanillaData VanillaData { get; set; } = new VanillaData();
    }

    public struct VanillaData
    {
        public int m_MinimumHappiness;
        public float m_HappinessEffect;
        public float3 m_TaxEffect;
        public float m_StudentEffect;
        public float m_AvailableWorkplaceEffect;
        public float m_HomelessEffect;
        public int m_NeutralHappiness;
        public float m_NeutralUnemployment;
        public float m_NeutralAvailableWorkplacePercentage;
        public int m_NeutralHomelessness;
        public int3 m_FreeResidentialRequirement;
        public float m_FreeCommercialProportion;
        public float m_FreeIndustrialProportion;
        public float m_CommercialStorageMinimum;
        public float m_CommercialStorageEffect;
        public float m_CommercialBaseDemand;
        public float m_IndustrialStorageMinimum;
        public float m_IndustrialStorageEffect;
        public float m_IndustrialBaseDemand;
        public float m_ExtractorBaseDemand;
        public float m_StorageDemandMultiplier;
        public int m_CommuterWorkerRatioLimit;
        public int m_CommuterSlowSpawnFactor;
        public float4 m_CommuterOCSpawnParameters;
        public float4 m_TouristOCSpawnParameters;
        public float4 m_CitizenOCSpawnParameters;
        public float m_TeenSpawnPercentage;
        public int3 m_FrameIntervalForSpawning;
        public float m_HouseholdSpawnSpeedFactor;
        public float m_HotelRoomPercentRequirement;
        public float4 m_NewCitizenEducationParameters;
    }

    public partial class VanillaDataSystem : GameSystemBase
    {
        private PrefabSystem prefabSystem;
        private EntityQuery prefabQuery;

        protected override void OnCreate()
        {
            base.OnCreate();

            prefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            prefabQuery = SystemAPI.QueryBuilder().WithAll<DemandParameterData>().Build();
            RequireForUpdate(prefabQuery);
        }

        protected override void OnUpdate()
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
                        VanillaDataStorage.VanillaData = new VanillaData
                        {
                            m_MinimumHappiness = data.m_MinimumHappiness,
                            m_HappinessEffect = data.m_HappinessEffect,
                            m_TaxEffect = data.m_TaxEffect,
                            m_StudentEffect = data.m_StudentEffect,
                            m_AvailableWorkplaceEffect = data.m_AvailableWorkplaceEffect,
                            m_HomelessEffect = data.m_HomelessEffect,
                            m_NeutralHappiness = data.m_NeutralHappiness,
                            m_NeutralUnemployment = data.m_NeutralUnemployment,
                            m_NeutralAvailableWorkplacePercentage =
                                data.m_NeutralAvailableWorkplacePercentage,
                            m_NeutralHomelessness = data.m_NeutralHomelessness,
                            m_FreeResidentialRequirement = data.m_FreeResidentialRequirement,
                            m_FreeCommercialProportion = data.m_FreeCommercialProportion,
                            m_FreeIndustrialProportion = data.m_FreeIndustrialProportion,
                            m_CommercialStorageMinimum = data.m_CommercialStorageMinimum,
                            m_CommercialStorageEffect = data.m_CommercialStorageEffect,
                            m_CommercialBaseDemand = data.m_CommercialBaseDemand,
                            m_IndustrialStorageMinimum = data.m_IndustrialStorageMinimum,
                            m_IndustrialStorageEffect = data.m_IndustrialStorageEffect,
                            m_IndustrialBaseDemand = data.m_IndustrialBaseDemand,
                            m_ExtractorBaseDemand = data.m_ExtractorBaseDemand,
                            m_StorageDemandMultiplier = data.m_StorageDemandMultiplier,
                            m_CommuterWorkerRatioLimit = data.m_CommuterWorkerRatioLimit,
                            m_CommuterSlowSpawnFactor = data.m_CommuterSlowSpawnFactor,
                            m_CommuterOCSpawnParameters = data.m_CommuterOCSpawnParameters,
                            m_TouristOCSpawnParameters = data.m_TouristOCSpawnParameters,
                            m_CitizenOCSpawnParameters = data.m_CitizenOCSpawnParameters,
                            m_TeenSpawnPercentage = data.m_TeenSpawnPercentage,
                            m_FrameIntervalForSpawning = data.m_FrameIntervalForSpawning,
                            m_HouseholdSpawnSpeedFactor = data.m_HouseholdSpawnSpeedFactor,
                            m_HotelRoomPercentRequirement = data.m_HotelRoomPercentRequirement,
                            m_NewCitizenEducationParameters = data.m_NewCitizenEducationParameters,
                        };
#if DEBUG
                        Mod.log.Info(
                            $"Vanilla data saved: {VanillaDataStorage.VanillaData.ToJSONString()}"
                        );
#endif
                    }
                }
            }
            Mod.m_Setting.VanillaDataFromStorage = VanillaDataStorage.VanillaData;
            GameManager.instance.localizationManager.AddSource(
                "en-US",
                new LocaleEN(Mod.m_Setting)
            );
            Enabled = false;
        }
    }

    //public VanillaData()
    //{
    //    MinimumHappiness = 30;
    //    HappinessEffect = 2f;
    //    TaxEffect = 1f;
    //    StudentEffect = 1f;
    //    AvailableWorkplaceEffect = 8f;
    //    HomelessEffect = 20f;
    //    NeutralHappiness = 45;
    //    NeutralUnemployment = 20f;
    //    NeutralAvailableWorkplacePercentage = 10f;
    //    NeutralHomelessness = 2;
    //    FreeResidentialRequirement = new int3(5, 10, 10);
    //    FreeCommercialProportion = 10f;
    //    FreeIndustrialProportion = 10f;
    //    CommercialStorageMinimum = 0.2f;
    //    CommercialStorageEffect = 1.6f;
    //    CommercialBaseDemand = 4f;
    //    IndustrialStorageMinimum = 0.2f;
    //    IndustrialStorageEffect = 1.6f;
    //    IndustrialBaseDemand = 7f;
    //    ExtractorBaseDemand = 1.5f;
    //    StorageDemandMultiplier = 5E-05f;
    //    CommuterWorkerRatioLimit = 8;
    //    CommuterSlowSpawnFactor = 8;
    //    CommuterOCSpawnParameters = new float4(0.8f, 0.2f, 0f, 0f);
    //    TouristOCSpawnParameters = new float4(0.1f, 0.1f, 0.5f, 0.3f);
    //    CitizenOCSpawnParameters = new float4(0.6f, 0.2f, 0.15f, 0.05f);
    //    TeenSpawnPercentage = 0.5f;
    //    FrameIntervalForSpawning = new int3(0, 2000, 2000);
    //    HouseholdSpawnSpeedFactor = 0.5f;
    //    HotelRoomPercentRequirement = 0.5f;
    //    NewCitizenEducationParameters = new float4(0.005f, 0.5f, 0.35f, 0.13f);
    //    NewCitizenEducationParameters_HighlyRaw = 0.015f;
    //}
    //}
}
