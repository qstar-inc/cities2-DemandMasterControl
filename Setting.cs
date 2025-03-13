using Colossal.IO.AssetDatabase;
using Colossal.Json;
using DemandMasterControl.Systems;
using Game.Modding;
using Game.Settings;
using Game.UI;
using System;
using UnityEngine.Device;

namespace DemandMasterControl
{
    [FileLocation("ModsSettings\\StarQ\\"+nameof(DemandMasterControl))]
    [SettingsUITabOrder(DemandTab, FactorTab, OCTab, AboutTab)]
    [SettingsUIGroupOrder(ResiDemandGroup, CommDemandGroup, IndDemandGroup, HappinessGroup, WorkplaceGroup, SpawnGroup, OthersGroup, CitizenGroup, CitizenPrefGroup, CommuterGroup, CommuterPrefGroup, TouristPrefGroup, EduGroup, InfoGroup)]
    [SettingsUIShowGroupName(ResiDemandGroup, CommDemandGroup, IndDemandGroup, HappinessGroup, WorkplaceGroup, SpawnGroup, OthersGroup, CitizenGroup, CitizenPrefGroup, CommuterGroup, CommuterPrefGroup, TouristPrefGroup, EduGroup)]
    public class Setting : ModSetting
    {
        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        private static readonly VanillaData VanillaData = new();

        public const string FactorTab = "Factors";
        public const string HappinessGroup = "Happiness";
        public const string WorkplaceGroup = "Workplace";
        public const string SpawnGroup = "Spawning";
        public const string OthersGroup = "Others";

        public const string DemandTab = "Demands";
        public const string ResiDemandGroup = "Residential";
        public const string CommDemandGroup = "Commercial";
        public const string IndDemandGroup = "Industrial";

        public const string OCTab = "Outside Connections";
        public const string CommuterGroup = "Commuters";
        public const string CommuterPrefGroup = "Commuters Preference";
        public const string TouristPrefGroup = "Tourists Preference";
        public const string CitizenGroup = "Citizens";
        public const string CitizenPrefGroup = "Citizens Preference";
        public const string EduGroup = "Education";

        public const string AboutTab = "About";
        public const string InfoGroup = "Info";

        public const string UnitFrame = " Frames";

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(FactorTab, HappinessGroup)]
        public int MinimumHappiness { get; set; } = VanillaData.MinimumHappiness;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(FactorTab, HappinessGroup)]
        public int NeutralHappiness { get; set; } = VanillaData.NeutralHappiness;

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, HappinessGroup)]
        public float HappinessEffect { get; set; } = VanillaData.HappinessEffect;

        [SettingsUISection(FactorTab, HappinessGroup)]
        public string CurrentHappiness => CurrentHappinessValue;

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, WorkplaceGroup)]
        public float AvailableWorkplaceEffect { get; set; } = VanillaData.AvailableWorkplaceEffect;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(FactorTab, WorkplaceGroup)]
        public float NeutralUnemployment { get; set; } = VanillaData.NeutralUnemployment;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(FactorTab, WorkplaceGroup)]
        public float NeutralAvailableWorkplacePercentage { get; set; } = VanillaData.NeutralAvailableWorkplacePercentage;

        //[SettingsUISection(FactorTab, HappinessGroup)]
        //public string CurrentUnemployment => $"{CurrentUnemploymentValue}%";

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public float TaxEffect { get; set; } = VanillaData.TaxEffect;

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public float StudentEffect { get; set; } = VanillaData.StudentEffect;

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public float HomelessEffect { get; set; } = VanillaData.HomelessEffect;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public int NeutralHomelessness { get; set; } = VanillaData.NeutralHomelessness;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, ResiDemandGroup)]
        public int FreeResidentialRequirement_Low { get; set; } = VanillaData.FreeResidentialRequirement.x;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, ResiDemandGroup)]
        public int FreeResidentialRequirement_Medium { get; set; } = VanillaData.FreeResidentialRequirement.y;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, ResiDemandGroup)]
        public int FreeResidentialRequirement_High { get; set; } = VanillaData.FreeResidentialRequirement.z;

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(DemandTab, CommDemandGroup)]
        public float CommercialBaseDemand { get; set; } = VanillaData.CommercialBaseDemand;

        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        //[SettingsUISection(DemandTab, CommDemandGroup)]
        //public float FreeCommercialProportion { get; set; } = VanillaData.FreeCommercialProportion;

        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        //[SettingsUISection(DemandTab, CommDemandGroup)]
        //public float CommercialStorageMinimum { get; set; } = VanillaData.CommercialStorageMinimum;
        
        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        //[SettingsUISection(DemandTab, CommDemandGroup)]
        //public float CommercialStorageEffect { get; set; } = VanillaData.CommercialStorageEffect;

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(DemandTab, CommDemandGroup)]
        public float HotelRoomPercentRequirement { get; set; } = VanillaData.HotelRoomPercentRequirement;

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(DemandTab, IndDemandGroup)]
        public float IndustrialBaseDemand { get; set; } = VanillaData.IndustrialBaseDemand;

        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        //[SettingsUISection(DemandTab, IndDemandGroup)]
        //public float FreeIndustrialProportion { get; set; } = VanillaData.FreeIndustrialProportion;

        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        //[SettingsUISection(DemandTab, IndDemandGroup)]
        //public float IndustrialStorageMinimum { get; set; } = VanillaData.IndustrialStorageMinimum;

        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        //[SettingsUISection(DemandTab, IndDemandGroup)]
        //public float IndustrialStorageEffect { get; set; } = VanillaData.IndustrialStorageEffect;

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(DemandTab, IndDemandGroup)]
        public float ExtractorBaseDemand { get; set; } = VanillaData.ExtractorBaseDemand;

        //[SettingsUISlider(min = 0, max = 1, step = 0.00001f, scalarMultiplier = 10000, unit = Unit.kFloatTwoFractions)]
        //[SettingsUISection(DemandTab, IndDemandGroup)]
        //public float StorageDemandMultiplier { get; set; } = VanillaData.StorageDemandMultiplier;

        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsRealisticTripsRunning))]
        [SettingsUISlider(min = 1, max = 20, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(OCTab, CommuterGroup)]
        public int CommuterWorkerRatioLimit { get; set; } = VanillaData.CommuterWorkerRatioLimit;

        [SettingsUISlider(min = 1, max = 20, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(OCTab, CommuterGroup)]
        public int CommuterSlowSpawnFactor { get; set; } = VanillaData.CommuterSlowSpawnFactor;

        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsRealisticTripsRunning))]
        [SettingsUISlider(min = 0, max = 100, step = 5, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, CommuterPrefGroup)]
        public float CommuterOCSpawnParameters_Road { get; set; } = VanillaData.CommuterOCSpawnParameters.x;

        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsRealisticTripsRunning))]
        [SettingsUISection(OCTab, CommuterPrefGroup)]
        [SettingsUISlider(min = 0, max = 100, step = 5, scalarMultiplier = 100, unit = Unit.kPercentage)]
        public float CommuterOCSpawnParameters_Train { get; set; } = VanillaData.CommuterOCSpawnParameters.y;

        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsRealisticTripsRunning))]
        [SettingsUISlider(min = 0, max = 100, step = 5, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, CommuterPrefGroup)]
        public float CommuterOCSpawnParameters_Air { get; set; } = VanillaData.CommuterOCSpawnParameters.z;

        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsRealisticTripsRunning))]
        [SettingsUISlider(min = 0, max = 100, step = 5, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, CommuterPrefGroup)]
        public float CommuterOCSpawnParameters_Ship { get; set; } = VanillaData.CommuterOCSpawnParameters.w;

        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsRealisticTripsRunning))]
        [SettingsUISection(OCTab, CommuterPrefGroup)]
        public string CommuterPrefText => ReVal(CommuterOCSpawnParameters_Road, CommuterOCSpawnParameters_Train, CommuterOCSpawnParameters_Air, CommuterOCSpawnParameters_Ship, true);

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, TouristPrefGroup)]
        public float TouristOCSpawnParameters_Road { get; set; } = VanillaData.TouristOCSpawnParameters.x;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, TouristPrefGroup)]
        public float TouristOCSpawnParameters_Train { get; set; } = VanillaData.TouristOCSpawnParameters.y;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, TouristPrefGroup)]
        public float TouristOCSpawnParameters_Air { get; set; } = VanillaData.TouristOCSpawnParameters.z;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, TouristPrefGroup)]
        public float TouristOCSpawnParameters_Ship { get; set; } = VanillaData.TouristOCSpawnParameters.w;

        [SettingsUISection(OCTab, TouristPrefGroup)]
        public string TouristPrefText => ReVal(TouristOCSpawnParameters_Road, TouristOCSpawnParameters_Train, TouristOCSpawnParameters_Air, TouristOCSpawnParameters_Ship);

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, CitizenPrefGroup)]
        public float CitizenOCSpawnParameters_Road { get; set; } = VanillaData.CitizenOCSpawnParameters.x;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, CitizenPrefGroup)]
        public float CitizenOCSpawnParameters_Train { get; set; } = VanillaData.CitizenOCSpawnParameters.y;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, CitizenPrefGroup)]
        public float CitizenOCSpawnParameters_Air { get; set; } = VanillaData.CitizenOCSpawnParameters.z;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, CitizenPrefGroup)]
        public float CitizenOCSpawnParameters_Ship { get; set; } = VanillaData.CitizenOCSpawnParameters.w;

        [SettingsUISection(OCTab, CitizenPrefGroup)]
        public string CitizenPrefText => ReVal(CitizenOCSpawnParameters_Road, CitizenOCSpawnParameters_Train, CitizenOCSpawnParameters_Air, CitizenOCSpawnParameters_Ship);

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, CitizenGroup)]
        public float TeenSpawnPercentage { get; set; } = VanillaData.TeenSpawnPercentage;

        [SettingsUISlider(min = 0, max = 5000, step = 100, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, SpawnGroup)]
        public int FrameIntervalForSpawning_Res { get; set; } = VanillaData.FrameIntervalForSpawning.x;

        [SettingsUISlider(min = 0, max = 5000, step = 100, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, SpawnGroup)]
        public int FrameIntervalForSpawning_Com { get; set; } = VanillaData.FrameIntervalForSpawning.y;

        [SettingsUISlider(min = 0, max = 5000, step = 100, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, SpawnGroup)]
        public int FrameIntervalForSpawning_Ind { get; set; } = VanillaData.FrameIntervalForSpawning.z;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(FactorTab, SpawnGroup)]
        public float HouseholdSpawnSpeedFactor { get; set; } = VanillaData.HouseholdSpawnSpeedFactor;

        [SettingsUISlider(min = 0, max = 100, step = 0.1f, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, EduGroup)]
        public float NewCitizenEducationParameters_Uneducated { get; set; } = VanillaData.NewCitizenEducationParameters.x;

        [SettingsUISlider(min = 0, max = 100, step = 0.1f, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, EduGroup)]
        public float NewCitizenEducationParameters_PoorlyEducated { get; set; } = VanillaData.NewCitizenEducationParameters.y;

        [SettingsUISlider(min = 0, max = 100, step = 0.1f, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, EduGroup)]
        public float NewCitizenEducationParameters_Educated { get; set; } = VanillaData.NewCitizenEducationParameters.z;

        [SettingsUISlider(min = 0, max = 100, step = 0.1f, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, EduGroup)]
        public float NewCitizenEducationParameters_WellEducated { get; set; } = VanillaData.NewCitizenEducationParameters.w;

        [SettingsUISlider(min = 0, max = 100, step = 0.1f, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(OCTab, EduGroup)]
        public float NewCitizenEducationParameters_HighlyEducated { get; set; } = VanillaData.NewCitizenEducationParameters_HighlyRaw;

        [SettingsUISection(OCTab, EduGroup)]
        public string EducationParamText1 => ReValEdu(NewCitizenEducationParameters_Uneducated, NewCitizenEducationParameters_PoorlyEducated, NewCitizenEducationParameters_Educated, NewCitizenEducationParameters_WellEducated, NewCitizenEducationParameters_HighlyEducated).Item1;

        [SettingsUISection(OCTab, EduGroup)]
        public string EducationParamText2 => ReValEdu(NewCitizenEducationParameters_Uneducated, NewCitizenEducationParameters_PoorlyEducated, NewCitizenEducationParameters_Educated, NewCitizenEducationParameters_WellEducated, NewCitizenEducationParameters_HighlyEducated).Item2;

        [SettingsUIHidden]
        [Exclude]
        public string CurrentHappinessValue { get; set; }

        [SettingsUIHidden]
        [Exclude]
        public bool IsRealisticTripsRunning { get; set; } = false;

        [SettingsUIHidden]
        [Exclude]
        public bool NotGameMode { get; set; }

        public override void SetDefaults()
        {
            MinimumHappiness = VanillaData.MinimumHappiness;
            NeutralHappiness = VanillaData.NeutralHappiness;
            HappinessEffect = VanillaData.HappinessEffect;
            AvailableWorkplaceEffect = VanillaData.AvailableWorkplaceEffect;
            NeutralUnemployment = VanillaData.NeutralUnemployment;
            NeutralAvailableWorkplacePercentage = VanillaData.NeutralAvailableWorkplacePercentage;
            TaxEffect = VanillaData.TaxEffect;
            StudentEffect = VanillaData.StudentEffect;
            HomelessEffect = VanillaData.HomelessEffect;
            NeutralHomelessness = VanillaData.NeutralHomelessness;
            FreeResidentialRequirement_Low = VanillaData.FreeResidentialRequirement.x;
            FreeResidentialRequirement_Medium = VanillaData.FreeResidentialRequirement.y;
            FreeResidentialRequirement_High = VanillaData.FreeResidentialRequirement.z;
            //FreeCommercialProportion = VanillaData.FreeCommercialProportion;
            //FreeIndustrialProportion = VanillaData.FreeIndustrialProportion;
            //CommercialStorageMinimum = VanillaData.CommercialStorageMinimum;
            //CommercialStorageEffect = VanillaData.CommercialStorageEffect;
            CommercialBaseDemand = VanillaData.CommercialBaseDemand;
            //IndustrialStorageMinimum = VanillaData.IndustrialStorageMinimum;
            //IndustrialStorageEffect = VanillaData.IndustrialStorageEffect;
            IndustrialBaseDemand = VanillaData.IndustrialBaseDemand;
            ExtractorBaseDemand = VanillaData.ExtractorBaseDemand;
            //StorageDemandMultiplier = VanillaData.StorageDemandMultiplier;
            CommuterWorkerRatioLimit = VanillaData.CommuterWorkerRatioLimit;
            CommuterSlowSpawnFactor = VanillaData.CommuterSlowSpawnFactor;
            CommuterOCSpawnParameters_Road = VanillaData.CommuterOCSpawnParameters.x;
            CommuterOCSpawnParameters_Train = VanillaData.CommuterOCSpawnParameters.y;
            CommuterOCSpawnParameters_Air = VanillaData.CommuterOCSpawnParameters.z;
            CommuterOCSpawnParameters_Ship = VanillaData.CommuterOCSpawnParameters.w;
            TouristOCSpawnParameters_Road = VanillaData.TouristOCSpawnParameters.x;
            TouristOCSpawnParameters_Train = VanillaData.TouristOCSpawnParameters.y;
            TouristOCSpawnParameters_Air = VanillaData.TouristOCSpawnParameters.z;
            TouristOCSpawnParameters_Ship = VanillaData.TouristOCSpawnParameters.w;
            CitizenOCSpawnParameters_Road = VanillaData.CitizenOCSpawnParameters.x;
            CitizenOCSpawnParameters_Train = VanillaData.CitizenOCSpawnParameters.y;
            CitizenOCSpawnParameters_Air = VanillaData.CitizenOCSpawnParameters.z;
            CitizenOCSpawnParameters_Ship = VanillaData.CitizenOCSpawnParameters.w;
            TeenSpawnPercentage = VanillaData.TeenSpawnPercentage;
            FrameIntervalForSpawning_Res = VanillaData.FrameIntervalForSpawning.x;
            FrameIntervalForSpawning_Com = VanillaData.FrameIntervalForSpawning.y;
            FrameIntervalForSpawning_Ind = VanillaData.FrameIntervalForSpawning.z;
            HouseholdSpawnSpeedFactor = VanillaData.HouseholdSpawnSpeedFactor;
            NewCitizenEducationParameters_Uneducated = VanillaData.NewCitizenEducationParameters.x;
            NewCitizenEducationParameters_PoorlyEducated = VanillaData.NewCitizenEducationParameters.y;
            NewCitizenEducationParameters_Educated = VanillaData.NewCitizenEducationParameters.z;
            NewCitizenEducationParameters_WellEducated = VanillaData.NewCitizenEducationParameters.w;
            NewCitizenEducationParameters_HighlyEducated = VanillaData.NewCitizenEducationParameters_HighlyRaw;
            HotelRoomPercentRequirement = VanillaData.HotelRoomPercentRequirement;
        }

        public (string, string) ReValEdu(float l0, float l1, float l2, float l3, float l4)
        {
            float total = l0 + l1 + l2 + l3 + l4;
            float xl0 = 100 * l0 / total;
            float xl1 = 100 * l1 / total;
            float xl2 = 100 * l2 / total;
            float xl3 = 100 * l3 / total;
            float xl4 = 100 * l4 / total;
            float xTotal = xl0 + xl1 + xl2 + xl3 + xl4;
            string text1 = "";
            string text2 = "";
            float currentTotal = 0;

            if (xTotal == 0f || total == 0f || total - l4 == 0f)
            {
                text1 = "Uneducated: 20%, Poorly Educated: 20%;";
                text2 = "Educated: 20%, Well Educated: 20%, Highly Educated: 20%";
            }
            else
            {
                if (xTotal != 100f && xl4 != 0)
                {
                    float diff = 100f - xTotal;
                    xl4 += diff;
                }
                else if (xTotal != 100 && xl3 != 0)
                {
                    float diff = 100f - xTotal;
                    xl3 += diff;
                }
                else if (xTotal != 100 && xl2 != 0)
                {
                    float diff = 100f - xTotal;
                    xl2 += diff;
                }
                else if (xTotal != 100 && xl1 != 0)
                {
                    float diff = 100f - xTotal;
                    xl1 += diff;
                }
                if (1 == 1)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl0);
                    if (!string.IsNullOrEmpty(text1))
                    {
                        text1 += ", ";
                    }
                    text1 += $"Uneducated: {Math.Round(value, 3)}%";
                    currentTotal += value;
                }
                if (1 == 1)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl1);
                    if (!string.IsNullOrEmpty(text1))
                    {
                        text1 += ", ";
                    }
                    text1 += $"Poorly Educated: {Math.Round(value, 3)}%";
                    currentTotal += value;
                }
                if (1 == 1)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl2);
                    if (!string.IsNullOrEmpty(text2))
                    {
                        text2 += ", ";
                    }
                    text2 += $"Educated: {Math.Round(value, 3)}%";
                    currentTotal += value;
                }
                if (1 == 1)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl3);
                    if (!string.IsNullOrEmpty(text2))
                    {
                        text2 += ", ";
                    }
                    text2 += $"Well Educated: {Math.Round(value, 3)}%";
                    currentTotal += value;
                }
                if (1 == 1)
                {
                    float remaining = 100f - currentTotal;
                    float value = Math.Min(remaining, xl4);
                    if (!string.IsNullOrEmpty(text2))
                    {
                        text2 += ", ";
                    }
                    text2 += $"Highly Educated: {Math.Round(value,3)}%";
                    //currentTotal += value;
                }
            }
            return (text1, text2);
        }

        public string ReVal(float l0, float l1, float l2, float l3, bool checkRealisticTrips = false)
        {
            if (IsRealisticTripsRunning && checkRealisticTrips)
            {
                return "[DISABLED] <Realistic Trips> detected";
            }
            float total = l0 + l1 + l2 + l3;
            int xl0 = (int)Math.Round(100 * l0 / total);
            int xl1 = (int)Math.Round(100 * l1 / total);
            int xl2 = (int)Math.Round(100 * l2 / total);
            int xl3 = (int)Math.Round(100 * l3 / total);
            int xTotal = xl0 + xl1 + xl2 + xl3;
            string text = "";
            int currentTotal = 0;

            if (xTotal == 0 | total == 0f)
            {
                return "Road: 25%, Train: 25%, Air: 25%, Ship: 25%";
            }
            if (xTotal != 100 && xl3 != 0)
            {
                int diff = 100 - xTotal;
                xl3 += diff;
            }
            else if (xTotal != 100 && xl2 != 0)
            {
                int diff = 100 - xTotal;
                xl2 += diff;
            }
            else if (xTotal != 100 && xl1 != 0)
            {
                int diff = 100 - xTotal;
                xl1 += diff;
            }
            if (1 == 1)
            {
                int remaining = 100 - currentTotal;
                int value = Math.Min(remaining, xl0);
                if (!string.IsNullOrEmpty(text))
                {
                    text += ", ";
                }
                text += $"Road: {value}%";
                currentTotal += value;
            }
            if (1 == 1)
            {
                int remaining = 100 - currentTotal;
                int value = Math.Min(remaining, xl1);
                if (!string.IsNullOrEmpty(text))
                {
                    text += ", ";
                }
                text += $"Train: {value}%";
                currentTotal += value;
            }
            if (1 == 1)
            {
                int remaining = 100 - currentTotal;
                int value = Math.Min(remaining, xl2);
                if (!string.IsNullOrEmpty(text))
                {
                    text += ", ";
                }
                text += $"Air: {value}%";
                currentTotal += value;
            }
            if (1 == 1)
            {
                int remaining = 100 - currentTotal;
                int value = Math.Min(remaining, xl3);
                if (!string.IsNullOrEmpty(text))
                {
                    text += ", ";
                }
                text += $"Ship: {value}%";
                //currentTotal += value;
            }
            return text.Trim();
        }

        [SettingsUISection(AboutTab, InfoGroup)]
        public string NameText => Mod.Name;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string VersionText =>
#if DEBUG
            $"{Mod.Version} - DEV";
#else
            Mod.Version;
#endif

        [SettingsUISection(AboutTab, InfoGroup)]
        public string AuthorText => "StarQ";

        [SettingsUIButtonGroup("Social")]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, InfoGroup)]
        public bool BMaCLink
        {
            set
            {
                try
                {
                    Application.OpenURL($"https://buymeacoffee.com/starq");
                }
                catch (Exception e)
                {
                    Mod.log.Info(e);
                }
            }
        }

        [SettingsUIButton]
        [SettingsUISection(AboutTab, InfoGroup)]
        public bool Reset { set { SetDefaults(); } }

        [SettingsUISection(AboutTab, InfoGroup)]
        [SettingsUIMultilineText]
        public string AboutTheMod => "";
    }
}
