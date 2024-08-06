using Unity.Mathematics;

namespace DemandMaster
{
    public class VanillaData
    {
        public int MinimumHappiness { get; }
        public float HappinessEffect { get; }
        public float AvailableWorkplaceEffect { get; }
        public float HomelessEffect { get; }
        public int NeutralHappiness { get; }
        public float NeutralAvailableWorkplacePercentage { get; }
        public float NeutralHomelessness { get; }
        public int3 FreeResidentialRequirement { get; }
        public float FreeCommercialProportion { get; }
        public float FreeIndustrialProportion { get; }
        public float CommercialStorageMinimum { get; }
        public float CommercialStorageEffect { get; }
        public float CommercialBaseDemand { get; }
        public float IndustrialStorageMinimum { get; }
        public float IndustrialStorageEffect { get; }
        public float IndustrialBaseDemand { get; }
        public float ExtractorBaseDemand { get; }
        public float StorageDemandMultiplier { get; }
        public int CommuterWorkerRatioLimit { get; }
        public int CommuterSlowSpawnFactor { get; }
        public float4 CommuterOCSpawnParameters { get; }
        public float4 TouristOCSpawnParameters { get; }
        public float4 CitizenOCSpawnParameters { get; }
        public float TeenSpawnPercentage { get; }
        public int3 FrameIntervalForSpawning { get; }
        public float NeutralUnemployment { get; }
        public float TaxEffect { get; }
        public float StudentEffect { get; }
        public float HouseholdSpawnSpeedFactor { get; }
        public float4 NewCitizenEducationParameters { get; }
        public float NewCitizenEducationParameters_v { get; }

        public VanillaData()
        {

            MinimumHappiness = 30;
            HappinessEffect = 2f;
            TaxEffect = 1f;
            StudentEffect = 1f;
            AvailableWorkplaceEffect = 8f;
            HomelessEffect = 20f;
            NeutralHappiness = 45;
            NeutralUnemployment = 20f;
            NeutralAvailableWorkplacePercentage = 10f;
            NeutralHomelessness = 2f;
            FreeResidentialRequirement = new int3(5, 10, 10);
            FreeCommercialProportion = 10f;
            FreeIndustrialProportion = 10f;
            CommercialStorageMinimum = 0.2f;
            CommercialStorageEffect = 1.6f;
            CommercialBaseDemand = 4f;
            IndustrialStorageMinimum = 0.2f;
            IndustrialStorageEffect = 1.6f;
            IndustrialBaseDemand = 7f;
            ExtractorBaseDemand = 1.5f;
            StorageDemandMultiplier = 5E-05f;
            CommuterWorkerRatioLimit = 8;
            CommuterSlowSpawnFactor = 8;
            CommuterOCSpawnParameters = new float4(0.8f, 0.2f, 0f, 0f);
            TouristOCSpawnParameters = new float4(0.1f, 0.1f, 0.5f, 0.3f);
            CitizenOCSpawnParameters = new float4(0.6f, 0.2f, 0.15f, 0.05f);
            TeenSpawnPercentage = 0.5f;
            FrameIntervalForSpawning = new int3(0, 2000, 2000);
            HouseholdSpawnSpeedFactor = 0.5f;
            NewCitizenEducationParameters = new float4(0.005f, 0.5f, 0.35f, 0.13f);
            NewCitizenEducationParameters_v = 0.015f;
        }
    }
}