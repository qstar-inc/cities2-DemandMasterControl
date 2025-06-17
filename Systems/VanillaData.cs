using Colossal.Json;
using Colossal.Serialization.Entities;
using Game;
using Game.Prefabs;
using Game.SceneFlow;
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
        public EntityQuery demandQuery;

        protected override void OnCreate()
        {
            base.OnCreate();

            prefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            demandQuery = SystemAPI.QueryBuilder().WithAll<DemandParameterData>().Build();
            RequireForUpdate(demandQuery);
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGamePreload(purpose, mode);
            CollectVanillaData();
        }

        protected override void OnUpdate() { }

        public void CollectVanillaData()
        {
            DemandParameterData data = demandQuery.GetSingleton<DemandParameterData>();
            if (data.m_CommuterSlowSpawnFactor == 0)
            {
                Mod.log.Info("DMC: Failed to load because of invalid values");
                Mod.State = "Shutting down";
                return;
            }
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
                m_NeutralAvailableWorkplacePercentage = data.m_NeutralAvailableWorkplacePercentage,
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
            //#if DEBUG
            Mod.log.Info($"Vanilla data saved: {VanillaDataStorage.VanillaData.ToJSONString()}");
            //#endif

            Mod.m_Setting.VanillaDataFromStorage = VanillaDataStorage.VanillaData;
            GameManager.instance.localizationManager.AddSource(
                "en-US",
                new LocaleEN(Mod.m_Setting)
            );
            Mod.State = "Ready";
        }
    }
}
