using System;
using System.Collections.Generic;
using Colossal.IO.AssetDatabase;
using Colossal.Json;
using DemandMasterControl.Systems;
using Game.Modding;
using Game.Settings;
using Game.UI;
using UnityEngine.Device;

namespace DemandMasterControl
{
    [FileLocation("ModsSettings\\StarQ\\" + nameof(DemandMasterControl))]
    [SettingsUITabOrder(DemandTab, FactorTab, OCTab, AboutTab)]
    [SettingsUIGroupOrder(
        ResiDemandGroup,
        CommDemandGroup,
        IndDemandGroup,
        HappinessGroup,
        WorkplaceGroup,
        SpawnGroup,
        OthersGroup,
        CitizenGroup,
        CitizenPrefGroup,
        CommuterGroup,
        CommuterPrefGroup,
        TouristPrefGroup,
        EduGroup,
        InfoGroup
    )]
    [SettingsUIShowGroupName(
        ResiDemandGroup,
        CommDemandGroup,
        IndDemandGroup,
        HappinessGroup,
        WorkplaceGroup,
        SpawnGroup,
        OthersGroup,
        CitizenGroup,
        CitizenPrefGroup,
        CommuterGroup,
        CommuterPrefGroup,
        TouristPrefGroup,
        EduGroup
    )]
    public class Setting : ModSetting
    {
        public Setting(IMod mod)
            : base(mod)
        {
            SetDefaults();
        }

        private readonly Dictionary<string, object> _values = new();

        private T GetValue<T>(string propertyName, T defaultValue = default)
        {
            if (_values.TryGetValue(propertyName, out var value))
            {
                try
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                catch (InvalidCastException)
                {
                    Mod.log.Info(
                        $"Warning: Unable to cast setting '{propertyName}' to {typeof(T)}. Returning default."
                    );
                }
            }
            return defaultValue;
        }

        private void SetValue<T>(string propertyName, T value, Action onChanged = null)
        {
            _values[propertyName] = value;
            onChanged?.Invoke();
        }

        [Exclude]
        public VanillaData VanillaDataFromStorage = new();

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

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(FactorTab, HappinessGroup)]
        public int MinimumHappiness
        {
            get => GetValue(nameof(MinimumHappiness), VanillaDataFromStorage.m_MinimumHappiness);
            set => SetValue(nameof(MinimumHappiness), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(FactorTab, HappinessGroup)]
        public int NeutralHappiness
        {
            get => GetValue(nameof(NeutralHappiness), VanillaDataFromStorage.m_NeutralHappiness);
            set => SetValue(nameof(NeutralHappiness), value, ApplyChanges);
        }

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, HappinessGroup)]
        public float HappinessEffect
        {
            get => GetValue(nameof(HappinessEffect), VanillaDataFromStorage.m_HappinessEffect);
            set => SetValue(nameof(HappinessEffect), value, ApplyChanges);
        }

        [SettingsUISection(FactorTab, HappinessGroup)]
        public string CurrentHappiness => CurrentHappinessValue;

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, WorkplaceGroup)]
        public float AvailableWorkplaceEffect
        {
            get =>
                GetValue(
                    nameof(AvailableWorkplaceEffect),
                    VanillaDataFromStorage.m_AvailableWorkplaceEffect
                );
            set => SetValue(nameof(AvailableWorkplaceEffect), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(FactorTab, WorkplaceGroup)]
        public float NeutralUnemployment
        {
            get =>
                GetValue(nameof(NeutralUnemployment), VanillaDataFromStorage.m_NeutralUnemployment);
            set => SetValue(nameof(NeutralUnemployment), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(FactorTab, WorkplaceGroup)]
        public float NeutralAvailableWorkplacePercentage
        {
            get =>
                GetValue(
                    nameof(NeutralAvailableWorkplacePercentage),
                    VanillaDataFromStorage.m_NeutralAvailableWorkplacePercentage
                );
            set => SetValue(nameof(NeutralAvailableWorkplacePercentage), value, ApplyChanges);
        }

        //[SettingsUISection(FactorTab, HappinessGroup)]
        //public string CurrentUnemployment => $"{CurrentUnemploymentValue}%";

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public float TaxEffect_x
        {
            get => GetValue(nameof(TaxEffect_x), VanillaDataFromStorage.m_TaxEffect.x);
            set => SetValue(nameof(TaxEffect_x), value, ApplyChanges);
        }

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public float TaxEffect_y
        {
            get => GetValue(nameof(TaxEffect_y), VanillaDataFromStorage.m_TaxEffect.y);
            set => SetValue(nameof(TaxEffect_y), value, ApplyChanges);
        }

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public float TaxEffect_z
        {
            get => GetValue(nameof(TaxEffect_z), VanillaDataFromStorage.m_TaxEffect.z);
            set => SetValue(nameof(TaxEffect_z), value, ApplyChanges);
        }

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public float StudentEffect
        {
            get => GetValue(nameof(StudentEffect), VanillaDataFromStorage.m_StudentEffect);
            set => SetValue(nameof(StudentEffect), value, ApplyChanges);
        }

        [SettingsUISlider(min = 0, max = 50, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(FactorTab, OthersGroup)]
        public float HomelessEffect
        {
            get => GetValue(nameof(HomelessEffect), VanillaDataFromStorage.m_HomelessEffect);
            set => SetValue(nameof(HomelessEffect), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(FactorTab, OthersGroup)]
        public int NeutralHomelessness
        {
            get =>
                GetValue(nameof(NeutralHomelessness), VanillaDataFromStorage.m_NeutralHomelessness);
            set => SetValue(nameof(NeutralHomelessness), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(DemandTab, ResiDemandGroup)]
        public int FreeResidentialRequirement_Low
        {
            get =>
                GetValue(
                    nameof(FreeResidentialRequirement_Low),
                    VanillaDataFromStorage.m_FreeResidentialRequirement.x
                );
            set => SetValue(nameof(FreeResidentialRequirement_Low), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(DemandTab, ResiDemandGroup)]
        public int FreeResidentialRequirement_Medium
        {
            get =>
                GetValue(
                    nameof(FreeResidentialRequirement_Medium),
                    VanillaDataFromStorage.m_FreeResidentialRequirement.y
                );
            set => SetValue(nameof(FreeResidentialRequirement_Medium), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(DemandTab, ResiDemandGroup)]
        public int FreeResidentialRequirement_High
        {
            get =>
                GetValue(
                    nameof(FreeResidentialRequirement_High),
                    VanillaDataFromStorage.m_FreeResidentialRequirement.z
                );
            set => SetValue(nameof(FreeResidentialRequirement_High), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 50,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kFloatTwoFractions
        )]
        [SettingsUISection(DemandTab, CommDemandGroup)]
        public float CommercialBaseDemand
        {
            get =>
                GetValue(
                    nameof(CommercialBaseDemand),
                    VanillaDataFromStorage.m_CommercialBaseDemand
                );
            set => SetValue(nameof(CommercialBaseDemand), value, ApplyChanges);
        }

        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        //[SettingsUISection(DemandTab, CommDemandGroup)]
        //public float FreeCommercialProportion { get; set; } = VanillaData.FreeCommercialProportion;

        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        //[SettingsUISection(DemandTab, CommDemandGroup)]
        //public float CommercialStorageMinimum { get; set; } = VanillaData.CommercialStorageMinimum;

        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        //[SettingsUISection(DemandTab, CommDemandGroup)]
        //public float CommercialStorageEffect { get; set; } = VanillaData.CommercialStorageEffect;

        [SettingsUISlider(
            min = 0,
            max = 50,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kFloatTwoFractions
        )]
        [SettingsUISection(DemandTab, CommDemandGroup)]
        public float HotelRoomPercentRequirement
        {
            get =>
                GetValue(
                    nameof(HotelRoomPercentRequirement),
                    VanillaDataFromStorage.m_HotelRoomPercentRequirement
                );
            set => SetValue(nameof(HotelRoomPercentRequirement), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 50,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kFloatTwoFractions
        )]
        [SettingsUISection(DemandTab, IndDemandGroup)]
        public float IndustrialBaseDemand
        {
            get =>
                GetValue(
                    nameof(IndustrialBaseDemand),
                    VanillaDataFromStorage.m_IndustrialBaseDemand
                );
            set => SetValue(nameof(IndustrialBaseDemand), value, ApplyChanges);
        }

        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        //[SettingsUISection(DemandTab, IndDemandGroup)]
        //public float FreeIndustrialProportion { get; set; } = VanillaData.FreeIndustrialProportion;

        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        //[SettingsUISection(DemandTab, IndDemandGroup)]
        //public float IndustrialStorageMinimum { get; set; } = VanillaData.IndustrialStorageMinimum;

        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        //[SettingsUISection(DemandTab, IndDemandGroup)]
        //public float IndustrialStorageEffect { get; set; } = VanillaData.IndustrialStorageEffect;

        [SettingsUISlider(
            min = 0,
            max = 50,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kFloatTwoFractions
        )]
        [SettingsUISection(DemandTab, IndDemandGroup)]
        public float ExtractorBaseDemand
        {
            get =>
                GetValue(nameof(ExtractorBaseDemand), VanillaDataFromStorage.m_ExtractorBaseDemand);
            set => SetValue(nameof(ExtractorBaseDemand), value, ApplyChanges);
        }

        //[SettingsUISlider(min = 0, max = 1, step = 0.00001f, scalarMultiplier = 10000, unit = Unit.kFloatTwoFractions)]
        //[SettingsUISection(DemandTab, IndDemandGroup)]
        //public float StorageDemandMultiplier { get; set; } = VanillaData.StorageDemandMultiplier;

        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsRealisticTripsRunning))]
        [SettingsUISlider(min = 1, max = 20, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(OCTab, CommuterGroup)]
        public int CommuterWorkerRatioLimit
        {
            get =>
                GetValue(
                    nameof(CommuterWorkerRatioLimit),
                    VanillaDataFromStorage.m_CommuterWorkerRatioLimit
                );
            set => SetValue(nameof(CommuterWorkerRatioLimit), value, ApplyChanges);
        }

        [SettingsUISlider(min = 1, max = 20, step = 1, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(OCTab, CommuterGroup)]
        public int CommuterSlowSpawnFactor
        {
            get =>
                GetValue(
                    nameof(CommuterSlowSpawnFactor),
                    VanillaDataFromStorage.m_CommuterSlowSpawnFactor
                );
            set => SetValue(nameof(CommuterSlowSpawnFactor), value, ApplyChanges);
        }

        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsRealisticTripsRunning))]
        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 5,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, CommuterPrefGroup)]
        public float CommuterOCSpawnParameters_Road
        {
            get =>
                GetValue(
                    nameof(CommuterOCSpawnParameters_Road),
                    VanillaDataFromStorage.m_CommuterOCSpawnParameters.x
                );
            set => SetValue(nameof(CommuterOCSpawnParameters_Road), value, ApplyChanges);
        }

        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsRealisticTripsRunning))]
        [SettingsUISection(OCTab, CommuterPrefGroup)]
        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 5,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        public float CommuterOCSpawnParameters_Train
        {
            get =>
                GetValue(
                    nameof(CommuterOCSpawnParameters_Train),
                    VanillaDataFromStorage.m_CommuterOCSpawnParameters.y
                );
            set => SetValue(nameof(CommuterOCSpawnParameters_Train), value, ApplyChanges);
        }

        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsRealisticTripsRunning))]
        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 5,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, CommuterPrefGroup)]
        public float CommuterOCSpawnParameters_Air
        {
            get =>
                GetValue(
                    nameof(CommuterOCSpawnParameters_Air),
                    VanillaDataFromStorage.m_CommuterOCSpawnParameters.z
                );
            set => SetValue(nameof(CommuterOCSpawnParameters_Air), value, ApplyChanges);
        }

        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsRealisticTripsRunning))]
        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 5,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, CommuterPrefGroup)]
        public float CommuterOCSpawnParameters_Ship
        {
            get =>
                GetValue(
                    nameof(CommuterOCSpawnParameters_Ship),
                    VanillaDataFromStorage.m_CommuterOCSpawnParameters.w
                );
            set => SetValue(nameof(CommuterOCSpawnParameters_Ship), value, ApplyChanges);
        }

        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsRealisticTripsRunning))]
        [SettingsUISection(OCTab, CommuterPrefGroup)]
        public string CommuterPrefText =>
            ReVal(
                CommuterOCSpawnParameters_Road,
                CommuterOCSpawnParameters_Train,
                CommuterOCSpawnParameters_Air,
                CommuterOCSpawnParameters_Ship,
                true
            );

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, TouristPrefGroup)]
        public float TouristOCSpawnParameters_Road
        {
            get =>
                GetValue(
                    nameof(TouristOCSpawnParameters_Road),
                    VanillaDataFromStorage.m_TouristOCSpawnParameters.x
                );
            set => SetValue(nameof(TouristOCSpawnParameters_Road), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, TouristPrefGroup)]
        public float TouristOCSpawnParameters_Train
        {
            get =>
                GetValue(
                    nameof(TouristOCSpawnParameters_Train),
                    VanillaDataFromStorage.m_TouristOCSpawnParameters.y
                );
            set => SetValue(nameof(TouristOCSpawnParameters_Train), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, TouristPrefGroup)]
        public float TouristOCSpawnParameters_Air
        {
            get =>
                GetValue(
                    nameof(TouristOCSpawnParameters_Air),
                    VanillaDataFromStorage.m_TouristOCSpawnParameters.z
                );
            set => SetValue(nameof(TouristOCSpawnParameters_Air), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, TouristPrefGroup)]
        public float TouristOCSpawnParameters_Ship
        {
            get =>
                GetValue(
                    nameof(TouristOCSpawnParameters_Ship),
                    VanillaDataFromStorage.m_TouristOCSpawnParameters.w
                );
            set => SetValue(nameof(TouristOCSpawnParameters_Ship), value, ApplyChanges);
        }

        [SettingsUISection(OCTab, TouristPrefGroup)]
        public string TouristPrefText =>
            ReVal(
                TouristOCSpawnParameters_Road,
                TouristOCSpawnParameters_Train,
                TouristOCSpawnParameters_Air,
                TouristOCSpawnParameters_Ship
            );

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, CitizenPrefGroup)]
        public float CitizenOCSpawnParameters_Road
        {
            get =>
                GetValue(
                    nameof(CitizenOCSpawnParameters_Road),
                    VanillaDataFromStorage.m_CitizenOCSpawnParameters.x
                );
            set => SetValue(nameof(CitizenOCSpawnParameters_Road), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, CitizenPrefGroup)]
        public float CitizenOCSpawnParameters_Train
        {
            get =>
                GetValue(
                    nameof(CitizenOCSpawnParameters_Train),
                    VanillaDataFromStorage.m_CitizenOCSpawnParameters.y
                );
            set => SetValue(nameof(CitizenOCSpawnParameters_Train), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, CitizenPrefGroup)]
        public float CitizenOCSpawnParameters_Air
        {
            get =>
                GetValue(
                    nameof(CitizenOCSpawnParameters_Air),
                    VanillaDataFromStorage.m_CitizenOCSpawnParameters.z
                );
            set => SetValue(nameof(CitizenOCSpawnParameters_Air), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, CitizenPrefGroup)]
        public float CitizenOCSpawnParameters_Ship
        {
            get =>
                GetValue(
                    nameof(CitizenOCSpawnParameters_Ship),
                    VanillaDataFromStorage.m_CitizenOCSpawnParameters.w
                );
            set => SetValue(nameof(CitizenOCSpawnParameters_Ship), value, ApplyChanges);
        }

        [SettingsUISection(OCTab, CitizenPrefGroup)]
        public string CitizenPrefText =>
            ReVal(
                CitizenOCSpawnParameters_Road,
                CitizenOCSpawnParameters_Train,
                CitizenOCSpawnParameters_Air,
                CitizenOCSpawnParameters_Ship
            );

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, CitizenGroup)]
        public float TeenSpawnPercentage
        {
            get =>
                GetValue(nameof(TeenSpawnPercentage), VanillaDataFromStorage.m_TeenSpawnPercentage);
            set => SetValue(nameof(TeenSpawnPercentage), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 5000,
            step = 100,
            scalarMultiplier = 1,
            unit = Unit.kInteger
        )]
        [SettingsUISection(FactorTab, SpawnGroup)]
        public int FrameIntervalForSpawning_Res
        {
            get =>
                GetValue(
                    nameof(FrameIntervalForSpawning_Res),
                    VanillaDataFromStorage.m_FrameIntervalForSpawning.x
                );
            set => SetValue(nameof(FrameIntervalForSpawning_Res), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 5000,
            step = 100,
            scalarMultiplier = 1,
            unit = Unit.kInteger
        )]
        [SettingsUISection(FactorTab, SpawnGroup)]
        public int FrameIntervalForSpawning_Com
        {
            get =>
                GetValue(
                    nameof(FrameIntervalForSpawning_Com),
                    VanillaDataFromStorage.m_FrameIntervalForSpawning.y
                );
            set => SetValue(nameof(FrameIntervalForSpawning_Com), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 5000,
            step = 100,
            scalarMultiplier = 1,
            unit = Unit.kInteger
        )]
        [SettingsUISection(FactorTab, SpawnGroup)]
        public int FrameIntervalForSpawning_Ind
        {
            get =>
                GetValue(
                    nameof(FrameIntervalForSpawning_Ind),
                    VanillaDataFromStorage.m_FrameIntervalForSpawning.z
                );
            set => SetValue(nameof(FrameIntervalForSpawning_Ind), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 1,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(FactorTab, SpawnGroup)]
        public float HouseholdSpawnSpeedFactor
        {
            get =>
                GetValue(
                    nameof(HouseholdSpawnSpeedFactor),
                    VanillaDataFromStorage.m_HouseholdSpawnSpeedFactor
                );
            set => SetValue(nameof(HouseholdSpawnSpeedFactor), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 0.1f,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, EduGroup)]
        public float NewCitizenEducationParameters_Uneducated
        {
            get =>
                GetValue(
                    nameof(NewCitizenEducationParameters_Uneducated),
                    VanillaDataFromStorage.m_NewCitizenEducationParameters.x
                );
            set => SetValue(nameof(NewCitizenEducationParameters_Uneducated), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 0.1f,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, EduGroup)]
        public float NewCitizenEducationParameters_PoorlyEducated
        {
            get =>
                GetValue(
                    nameof(NewCitizenEducationParameters_PoorlyEducated),
                    VanillaDataFromStorage.m_NewCitizenEducationParameters.y
                );
            set =>
                SetValue(nameof(NewCitizenEducationParameters_PoorlyEducated), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 0.1f,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, EduGroup)]
        public float NewCitizenEducationParameters_Educated
        {
            get =>
                GetValue(
                    nameof(NewCitizenEducationParameters_Educated),
                    VanillaDataFromStorage.m_NewCitizenEducationParameters.z
                );
            set => SetValue(nameof(NewCitizenEducationParameters_Educated), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 0.1f,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, EduGroup)]
        public float NewCitizenEducationParameters_WellEducated
        {
            get =>
                GetValue(
                    nameof(NewCitizenEducationParameters_WellEducated),
                    VanillaDataFromStorage.m_NewCitizenEducationParameters.w
                );
            set =>
                SetValue(nameof(NewCitizenEducationParameters_WellEducated), value, ApplyChanges);
        }

        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 0.1f,
            scalarMultiplier = 100,
            unit = Unit.kPercentage
        )]
        [SettingsUISection(OCTab, EduGroup)]
        public float NewCitizenEducationParameters_HighlyEducated
        {
            get =>
                GetValue(
                    nameof(NewCitizenEducationParameters_HighlyEducated),
                    1
                        - VanillaDataFromStorage.m_NewCitizenEducationParameters.x
                        - VanillaDataFromStorage.m_NewCitizenEducationParameters.y
                        - VanillaDataFromStorage.m_NewCitizenEducationParameters.z
                        - VanillaDataFromStorage.m_NewCitizenEducationParameters.w
                );
            set =>
                SetValue(nameof(NewCitizenEducationParameters_HighlyEducated), value, ApplyChanges);
        }

        [SettingsUISection(OCTab, EduGroup)]
        public string EducationParamText1 =>
            ReValEdu(
                NewCitizenEducationParameters_Uneducated,
                NewCitizenEducationParameters_PoorlyEducated,
                NewCitizenEducationParameters_Educated,
                NewCitizenEducationParameters_WellEducated,
                NewCitizenEducationParameters_HighlyEducated
            ).Item1;

        [SettingsUISection(OCTab, EduGroup)]
        public string EducationParamText2 =>
            ReValEdu(
                NewCitizenEducationParameters_Uneducated,
                NewCitizenEducationParameters_PoorlyEducated,
                NewCitizenEducationParameters_Educated,
                NewCitizenEducationParameters_WellEducated,
                NewCitizenEducationParameters_HighlyEducated
            ).Item2;

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
            Changes = false;
            MinimumHappiness = VanillaDataFromStorage.m_MinimumHappiness;
            NeutralHappiness = VanillaDataFromStorage.m_NeutralHappiness;
            HappinessEffect = VanillaDataFromStorage.m_HappinessEffect;
            AvailableWorkplaceEffect = VanillaDataFromStorage.m_AvailableWorkplaceEffect;
            NeutralUnemployment = VanillaDataFromStorage.m_NeutralUnemployment;
            NeutralAvailableWorkplacePercentage =
                VanillaDataFromStorage.m_NeutralAvailableWorkplacePercentage;
            TaxEffect_x = VanillaDataFromStorage.m_TaxEffect.x;
            TaxEffect_y = VanillaDataFromStorage.m_TaxEffect.y;
            TaxEffect_z = VanillaDataFromStorage.m_TaxEffect.z;
            StudentEffect = VanillaDataFromStorage.m_StudentEffect;
            HomelessEffect = VanillaDataFromStorage.m_HomelessEffect;
            NeutralHomelessness = VanillaDataFromStorage.m_NeutralHomelessness;
            FreeResidentialRequirement_Low = VanillaDataFromStorage.m_FreeResidentialRequirement.x;
            FreeResidentialRequirement_Medium = VanillaDataFromStorage
                .m_FreeResidentialRequirement
                .y;
            FreeResidentialRequirement_High = VanillaDataFromStorage.m_FreeResidentialRequirement.z;
            //FreeCommercialProportion = VanillaData.m_FreeCommercialProportion;
            //FreeIndustrialProportion = VanillaData.m_FreeIndustrialProportion;
            //CommercialStorageMinimum = VanillaData.m_CommercialStorageMinimum;
            //CommercialStorageEffect = VanillaData.m_CommercialStorageEffect;
            CommercialBaseDemand = VanillaDataFromStorage.m_CommercialBaseDemand;
            //IndustrialStorageMinimum = VanillaData.m_IndustrialStorageMinimum;
            //IndustrialStorageEffect = VanillaData.m_IndustrialStorageEffect;
            IndustrialBaseDemand = VanillaDataFromStorage.m_IndustrialBaseDemand;
            ExtractorBaseDemand = VanillaDataFromStorage.m_ExtractorBaseDemand;
            //StorageDemandMultiplier = VanillaData.m_StorageDemandMultiplier;
            CommuterWorkerRatioLimit = VanillaDataFromStorage.m_CommuterWorkerRatioLimit;
            CommuterSlowSpawnFactor = VanillaDataFromStorage.m_CommuterSlowSpawnFactor;
            CommuterOCSpawnParameters_Road = VanillaDataFromStorage.m_CommuterOCSpawnParameters.x;
            CommuterOCSpawnParameters_Train = VanillaDataFromStorage.m_CommuterOCSpawnParameters.y;
            CommuterOCSpawnParameters_Air = VanillaDataFromStorage.m_CommuterOCSpawnParameters.z;
            CommuterOCSpawnParameters_Ship = VanillaDataFromStorage.m_CommuterOCSpawnParameters.w;
            TouristOCSpawnParameters_Road = VanillaDataFromStorage.m_TouristOCSpawnParameters.x;
            TouristOCSpawnParameters_Train = VanillaDataFromStorage.m_TouristOCSpawnParameters.y;
            TouristOCSpawnParameters_Air = VanillaDataFromStorage.m_TouristOCSpawnParameters.z;
            TouristOCSpawnParameters_Ship = VanillaDataFromStorage.m_TouristOCSpawnParameters.w;
            CitizenOCSpawnParameters_Road = VanillaDataFromStorage.m_CitizenOCSpawnParameters.x;
            CitizenOCSpawnParameters_Train = VanillaDataFromStorage.m_CitizenOCSpawnParameters.y;
            CitizenOCSpawnParameters_Air = VanillaDataFromStorage.m_CitizenOCSpawnParameters.z;
            CitizenOCSpawnParameters_Ship = VanillaDataFromStorage.m_CitizenOCSpawnParameters.w;
            TeenSpawnPercentage = VanillaDataFromStorage.m_TeenSpawnPercentage;
            FrameIntervalForSpawning_Res = VanillaDataFromStorage.m_FrameIntervalForSpawning.x;
            FrameIntervalForSpawning_Com = VanillaDataFromStorage.m_FrameIntervalForSpawning.y;
            FrameIntervalForSpawning_Ind = VanillaDataFromStorage.m_FrameIntervalForSpawning.z;
            HouseholdSpawnSpeedFactor = VanillaDataFromStorage.m_HouseholdSpawnSpeedFactor;
            NewCitizenEducationParameters_Uneducated = VanillaDataFromStorage
                .m_NewCitizenEducationParameters
                .x;
            NewCitizenEducationParameters_PoorlyEducated = VanillaDataFromStorage
                .m_NewCitizenEducationParameters
                .y;
            NewCitizenEducationParameters_Educated = VanillaDataFromStorage
                .m_NewCitizenEducationParameters
                .z;
            NewCitizenEducationParameters_WellEducated = VanillaDataFromStorage
                .m_NewCitizenEducationParameters
                .w;
            NewCitizenEducationParameters_HighlyEducated =
                1
                - VanillaDataFromStorage.m_NewCitizenEducationParameters.x
                - VanillaDataFromStorage.m_NewCitizenEducationParameters.y
                - VanillaDataFromStorage.m_NewCitizenEducationParameters.z
                - VanillaDataFromStorage.m_NewCitizenEducationParameters.w;
            HotelRoomPercentRequirement = VanillaDataFromStorage.m_HotelRoomPercentRequirement;
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
                    text2 += $"Highly Educated: {Math.Round(value, 3)}%";
                    //currentTotal += value;
                }
            }
            return (text1, text2);
        }

        public string ReVal(
            float l0,
            float l1,
            float l2,
            float l3,
            bool checkRealisticTrips = false
        )
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

        [Exclude]
        public bool Changes = false;

        public void ApplyChanges()
        {
            Changes = true;
        }

        [SettingsUIButton]
        [SettingsUISection(AboutTab, InfoGroup)]
        public bool Reset
        {
            set { SetDefaults(); }
        }

        [SettingsUISection(AboutTab, InfoGroup)]
        [SettingsUIMultilineText]
        public string AboutTheMod => "";
    }
}
