using Colossal.IO.AssetDatabase;
using Colossal.Json;
using Game.Modding;
using Game.Settings;
using Game.UI;
using System;

namespace DemandMaster
{
    [FileLocation($"ModsSettings\\StarQ\\{nameof(DemandMaster)}")]
    [SettingsUITabOrder(FactorTab, DemandTab, CommuterTab, AboutTab)]
    [SettingsUIGroupOrder(HappinessGroup, WorkplaceGroup, OthersGroup, ResiDemandGroup, CommDemandGroup, IndDemandGroup, EduGroup, SpawnGroup, CommuterGroup, CommuterPrefGroup, TouristPrefGroup, CitizenGroup, CitizenPrefGroup, InfoGroup)]
    [SettingsUIShowGroupName(HappinessGroup, WorkplaceGroup, OthersGroup, ResiDemandGroup, CommDemandGroup, IndDemandGroup, EduGroup, SpawnGroup, CommuterGroup, CommuterPrefGroup, TouristPrefGroup, CitizenGroup, CitizenPrefGroup)]
    public class Setting(IMod mod) : ModSetting(mod)
    {
        private static readonly VanillaData VanillaData = new();

        public const string FactorTab = "Factors";
        public const string HappinessGroup = "Happiness";
        public const string WorkplaceGroup = "Workplace";
        public const string OthersGroup = "Others";

        public const string DemandTab = "Demands";
        public const string ResiDemandGroup = "Residential";
        public const string CommDemandGroup = "Commercial";
        public const string IndDemandGroup = "Industrial";
        public const string EduGroup = "Education Factors";
        public const string SpawnGroup = "Spawning Factors";

        public const string CommuterTab = "Outside Connections";
        public const string CommuterGroup = "Commuters";
        public const string CommuterPrefGroup = "Commuters Preference";
        public const string TouristPrefGroup = "Tourists Preference";
        public const string CitizenGroup = "Citizens";
        public const string CitizenPrefGroup = "Citizens Preference";

        public const string AboutTab = "About";
        public const string InfoGroup = "Info";

        public const string UnitFrame = " Frames";

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(FactorTab, HappinessGroup)]
        public int MinimumHappiness { get; set; } = VanillaData.MinimumHappiness;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(FactorTab, HappinessGroup)]
        public int NeutralHappiness { get; set; } = VanillaData.NeutralHappiness;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, HappinessGroup)]
        public float HappinessEffect { get; set; } = VanillaData.HappinessEffect;

        [SettingsUISection(FactorTab, HappinessGroup)]
        public string HappinessText => $"{HappinessValue}%";

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, WorkplaceGroup)]
        public float AvailableWorkplaceEffect { get; set; } = VanillaData.AvailableWorkplaceEffect;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(FactorTab, WorkplaceGroup)]
        public float NeutralUnemployment { get; set; } = VanillaData.NeutralUnemployment;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(FactorTab, WorkplaceGroup)]
        public float NeutralAvailableWorkplacePercentage { get; set; } = VanillaData.NeutralAvailableWorkplacePercentage;

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public float TaxEffect { get; set; } = VanillaData.TaxEffect;

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public float StudentEffect { get; set; } = VanillaData.StudentEffect;

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public float HomelessEffect { get; set; } = VanillaData.HomelessEffect;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public float NeutralHomelessness { get; set; } = VanillaData.NeutralHomelessness;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, ResiDemandGroup)]
        public int FreeResidentialRequirement_Low { get; set; } = VanillaData.FreeResidentialRequirement.x;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, ResiDemandGroup)]
        public int FreeResidentialRequirement_Medium { get; set; } = VanillaData.FreeResidentialRequirement.y;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, ResiDemandGroup)]
        public int FreeResidentialRequirement_High { get; set; } = VanillaData.FreeResidentialRequirement.z;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, CommDemandGroup)]
        public float FreeCommercialProportion { get; set; } = VanillaData.FreeCommercialProportion;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, IndDemandGroup)]
        public float FreeIndustrialProportion { get; set; } = VanillaData.FreeIndustrialProportion;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, CommDemandGroup)]
        public float CommercialStorageMinimum { get; set; } = VanillaData.CommercialStorageMinimum;
        
        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, CommDemandGroup)]
        public float CommercialStorageEffect { get; set; } = VanillaData.CommercialStorageEffect;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(DemandTab, CommDemandGroup)]
        public float CommercialBaseDemand { get; set; } = VanillaData.CommercialBaseDemand;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, IndDemandGroup)]
        public float IndustrialStorageMinimum { get; set; } = VanillaData.IndustrialStorageMinimum;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, IndDemandGroup)]
        public float IndustrialStorageEffect { get; set; } = VanillaData.IndustrialStorageEffect;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(DemandTab, IndDemandGroup)]
        public float IndustrialBaseDemand { get; set; } = VanillaData.IndustrialBaseDemand;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(DemandTab, IndDemandGroup)]
        public float ExtractorBaseDemand { get; set; } = VanillaData.ExtractorBaseDemand;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 1, step = 0.00001f, scalarMultiplier = 10000, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(DemandTab, IndDemandGroup)]
        public float StorageDemandMultiplier { get; set; } = VanillaData.StorageDemandMultiplier;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 1, max = 20, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(CommuterTab, CommuterGroup)]
        public int CommuterWorkerRatioLimit { get; set; } = VanillaData.CommuterWorkerRatioLimit;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 1, max = 20, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(CommuterTab, CommuterGroup)]
        public int CommuterSlowSpawnFactor { get; set; } = VanillaData.CommuterSlowSpawnFactor;

        [SettingsUISlider(min = 0, max = 100, step = 5, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(CommuterTab, CommuterPrefGroup)]
        public float CommuterOCSpawnParameters_Road { get; set; } = VanillaData.CommuterOCSpawnParameters.x;

        [SettingsUISection(CommuterTab, CommuterPrefGroup)]
        [SettingsUISlider(min = 0, max = 100, step = 5, scalarMultiplier = 100, unit = Unit.kPercentage)]
        public float CommuterOCSpawnParameters_Train { get; set; } = VanillaData.CommuterOCSpawnParameters.y;

        [SettingsUISlider(min = 0, max = 100, step = 5, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(CommuterTab, CommuterPrefGroup)]
        public float CommuterOCSpawnParameters_Air { get; set; } = VanillaData.CommuterOCSpawnParameters.z;

        [SettingsUISlider(min = 0, max = 100, step = 5, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(CommuterTab, CommuterPrefGroup)]
        public float CommuterOCSpawnParameters_Ship { get; set; } = VanillaData.CommuterOCSpawnParameters.w;

        [SettingsUISection(CommuterTab, CommuterPrefGroup)]
        public string CommuterPrefText => ReVal(CommuterOCSpawnParameters_Road, CommuterOCSpawnParameters_Train, CommuterOCSpawnParameters_Air, CommuterOCSpawnParameters_Ship);

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(CommuterTab, TouristPrefGroup)]
        public float TouristOCSpawnParameters_Road { get; set; } = VanillaData.TouristOCSpawnParameters.x;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(CommuterTab, TouristPrefGroup)]
        public float TouristOCSpawnParameters_Train { get; set; } = VanillaData.TouristOCSpawnParameters.y;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(CommuterTab, TouristPrefGroup)]
        public float TouristOCSpawnParameters_Air { get; set; } = VanillaData.TouristOCSpawnParameters.z;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(CommuterTab, TouristPrefGroup)]
        public float TouristOCSpawnParameters_Ship { get; set; } = VanillaData.TouristOCSpawnParameters.w;

        [SettingsUISection(CommuterTab, TouristPrefGroup)]
        public string TouristPrefText => ReVal(TouristOCSpawnParameters_Road, TouristOCSpawnParameters_Train, TouristOCSpawnParameters_Air, TouristOCSpawnParameters_Ship);

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(CommuterTab, CitizenPrefGroup)]
        public float CitizenOCSpawnParameters_Road { get; set; } = VanillaData.CitizenOCSpawnParameters.x;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(CommuterTab, CitizenPrefGroup)]
        public float CitizenOCSpawnParameters_Train { get; set; } = VanillaData.CitizenOCSpawnParameters.y;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(CommuterTab, CitizenPrefGroup)]
        public float CitizenOCSpawnParameters_Air { get; set; } = VanillaData.CitizenOCSpawnParameters.z;

        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(CommuterTab, CitizenPrefGroup)]
        public float CitizenOCSpawnParameters_Ship { get; set; } = VanillaData.CitizenOCSpawnParameters.w;

        [SettingsUISection(CommuterTab, CitizenPrefGroup)]
        public string CitizenPrefText => ReVal(CitizenOCSpawnParameters_Road, CitizenOCSpawnParameters_Train, CitizenOCSpawnParameters_Air, CitizenOCSpawnParameters_Ship);

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(CommuterTab, CitizenGroup)]
        public float TeenSpawnPercentage { get; set; } = VanillaData.TeenSpawnPercentage;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 5000, step = 100, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(DemandTab, SpawnGroup)]
        public int FrameIntervalForSpawning_Res { get; set; } = VanillaData.FrameIntervalForSpawning.x;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 5000, step = 100, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(DemandTab, SpawnGroup)]
        public int FrameIntervalForSpawning_Com { get; set; } = VanillaData.FrameIntervalForSpawning.y;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 5000, step = 100, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(DemandTab, SpawnGroup)]
        public int FrameIntervalForSpawning_Ind { get; set; } = VanillaData.FrameIntervalForSpawning.z;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, SpawnGroup)]
        public float HouseholdSpawnSpeedFactor { get; set; } = VanillaData.HouseholdSpawnSpeedFactor;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 0.1f, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, EduGroup)]
        public float NewCitizenEducationParameters_Uneducated { get; set; } = VanillaData.NewCitizenEducationParameters.x;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 0.1f, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, EduGroup)]
        public float NewCitizenEducationParameters_PoorlyEducated { get; set; } = VanillaData.NewCitizenEducationParameters.y;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 0.1f, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, EduGroup)]
        public float NewCitizenEducationParameters_Educated { get; set; } = VanillaData.NewCitizenEducationParameters.z;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 0.1f, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, EduGroup)]
        public float NewCitizenEducationParameters_WellEducated { get; set; } = VanillaData.NewCitizenEducationParameters.w;

        [SettingsUIAdvanced]
        [SettingsUISlider(min = 0, max = 100, step = 0.1f, scalarMultiplier = 100, unit = Unit.kPercentage)]
        [SettingsUISection(DemandTab, EduGroup)]
        public float NewCitizenEducationParameters_HighlyEducated { get; set; } = VanillaData.NewCitizenEducationParameters_v;

        [SettingsUIAdvanced]
        [SettingsUISection(DemandTab, EduGroup)]
        public string EducationParamText1 => ReValEdu(NewCitizenEducationParameters_Uneducated, NewCitizenEducationParameters_PoorlyEducated, NewCitizenEducationParameters_Educated, NewCitizenEducationParameters_WellEducated, NewCitizenEducationParameters_HighlyEducated).Item1;

        [SettingsUIAdvanced]
        [SettingsUISection(DemandTab, EduGroup)]
        public string EducationParamText2 => ReValEdu(NewCitizenEducationParameters_Uneducated, NewCitizenEducationParameters_PoorlyEducated, NewCitizenEducationParameters_Educated, NewCitizenEducationParameters_WellEducated, NewCitizenEducationParameters_HighlyEducated).Item2;


        [SettingsUISection(AboutTab, InfoGroup)]
        public string NameText => Mod.Name;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string VersionText => Mod.Version;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string AuthorText => Mod.Author;

        [SettingsUIButton]
        [SettingsUISection(AboutTab, InfoGroup)]
        public bool Reset { set { SetDefaults(); } }

        [SettingsUISection(AboutTab, InfoGroup)]
        [SettingsUIMultilineText]
        public string AboutTheMod  => "";

        [SettingsUIHidden]
        [Exclude]
        public double HappinessValue { get; set; }

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
            FreeCommercialProportion = VanillaData.FreeCommercialProportion;
            FreeIndustrialProportion = VanillaData.FreeIndustrialProportion;
            CommercialStorageMinimum = VanillaData.CommercialStorageMinimum;
            CommercialStorageEffect = VanillaData.CommercialStorageEffect;
            CommercialBaseDemand = VanillaData.CommercialBaseDemand;
            IndustrialStorageMinimum = VanillaData.IndustrialStorageMinimum;
            IndustrialStorageEffect = VanillaData.IndustrialStorageEffect;
            IndustrialBaseDemand = VanillaData.IndustrialBaseDemand;
            ExtractorBaseDemand = VanillaData.ExtractorBaseDemand;
            StorageDemandMultiplier = VanillaData.StorageDemandMultiplier;
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
            NewCitizenEducationParameters_HighlyEducated = VanillaData.NewCitizenEducationParameters_v;

        }

        public (string, string) ReValEdu(float l0, float l1, float l2, float l3, float l4)
        {
            float total = l0 + l1 + l2 + l3 + l4;
            int xl0 = (int)Math.Round(100 * l0 / total);
            int xl1 = (int)Math.Round(100 * l1 / total);
            int xl2 = (int)Math.Round(100 * l2 / total);
            int xl3 = (int)Math.Round(100 * l3 / total);
            int xl4 = (int)Math.Round(100 * l4 / total);
            int xTotal = xl0 + xl1 + xl2 + xl3 + xl4;
            string text1 = "";
            string text2 = "";
            int currentTotal = 0;

            if (xTotal == 0)
            {
                text1 = "Uneducated: 20%, Poorly Educated: 20%;";
                text2 = "Educated: 20%, Well Educated: 20%, Highly Educated: 20%";
            }
            else
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
                if (1 == 1)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xl0);
                    if (!string.IsNullOrEmpty(text1))
                    {
                        text1 += ", ";
                    }
                    text1 += $"Uneducated: {value}%";
                    currentTotal += value;
                }
                if (1 == 1)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xl1);
                    if (!string.IsNullOrEmpty(text1))
                    {
                        text1 += ", ";
                    }
                    text1 += $"Poorly Educated: {value}%";
                    currentTotal += value;
                }
                if (1 == 1)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xl2);
                    if (!string.IsNullOrEmpty(text2))
                    {
                        text2 += ", ";
                    }
                    text2 += $"Educated: {value}%";
                    currentTotal += value;
                }
                if (1 == 1)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xl3);
                    if (!string.IsNullOrEmpty(text2))
                    {
                        text2 += ", ";
                    }
                    text2 += $"Well Educated: {value}%";
                    currentTotal += value;
                }
                if (1 == 1)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xl4);
                    if (!string.IsNullOrEmpty(text2))
                    {
                        text2 += ", ";
                    }
                    text2 += $"Highly Educated: {value}%";
                    //currentTotal += value;
                }
            }
            return (text1, text2);
        }

        public string ReVal(float Road, float Train, float Air, float Ship)
        {
            float total = Road + Train + Air + Ship;
            int xRoad = (int)Math.Round(100 * Road / total);
            int xTrain = (int)Math.Round(100 * Train / total);
            int xAir = (int)Math.Round(100 * Air / total);
            int xShip = (int)Math.Round(100 * Ship / total);
            int xTotal = xRoad + xTrain + xAir + xShip;
            string text = "";
            int currentTotal = 0;

            if (xTotal == 0)
            {
                text = "Road: 25%, Train: 25%, Air: 25%, Ship: 25%";
            }
            else
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
                if (1 == 1)
                {
                    int remaining = 100 - currentTotal;
                    int value = Math.Min(remaining, xRoad);
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
                    int value = Math.Min(remaining, xTrain);
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
                    int value = Math.Min(remaining, xAir);
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
                    int value = Math.Min(remaining, xShip);
                    if (!string.IsNullOrEmpty(text))
                    {
                        text += ", ";
                    }
                    text += $"Ship: {value}%";
                    //currentTotal += value;
                }
            }
            return text.Trim();
        }
    }
}
