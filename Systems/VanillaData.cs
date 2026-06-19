using Colossal.Json;
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

    public partial class VanillaDataSystem
    {
        public static void CollectVanillaData()
        {
            VanillaDataStorage.VanillaData = new VanillaData
            {
                m_MinimumHappiness = 30,
                m_HappinessEffect = 2,
                m_TaxEffect = new float3(2, 1, 1),
                m_StudentEffect = 2,
                m_AvailableWorkplaceEffect = 4,
                m_HomelessEffect = 10,
                m_NeutralHappiness = 50,
                m_NeutralUnemployment = 30,
                m_NeutralAvailableWorkplacePercentage = 10,
                m_NeutralHomelessness = 2,
                m_FreeResidentialRequirement = new int3(5, 60, 100),
                m_FreeCommercialProportion = 5,
                m_FreeIndustrialProportion = 5,
                m_CommercialStorageMinimum = 0.2f,
                m_CommercialStorageEffect = 1.6f,
                m_CommercialBaseDemand = 5,
                m_IndustrialStorageMinimum = 0.2f,
                m_IndustrialStorageEffect = 1.6f,
                m_IndustrialBaseDemand = 1,
                m_ExtractorBaseDemand = 1,
                m_StorageDemandMultiplier = 1,
                m_CommuterWorkerRatioLimit = 8,
                m_CommuterSlowSpawnFactor = 8,
                m_CommuterOCSpawnParameters = new float4(0.7f, 0.2f, 0.05f, 0.05f),
                m_TouristOCSpawnParameters = new float4(0.1f, 0.2f, 0.4f, 0.3f),
                m_CitizenOCSpawnParameters = new float4(0.6f, 0.2f, 0.15f, 0.05f),
                m_TeenSpawnPercentage = 0.2f,
                m_FrameIntervalForSpawning = new int3(0, 2000, 2000),
                m_HouseholdSpawnSpeedFactor = 0.5f,
                m_HotelRoomPercentRequirement = 0.5f,
                m_NewCitizenEducationParameters = new float4(0.005f, 0.5f, 0.35f, 0.13f),
            };

            //#if DEBUG
            Mod.log.Info($"Vanilla data saved: {VanillaDataStorage.VanillaData.ToJSONString()}");
            //#endif

            Mod.State = "Ready";
        }
    }
}
