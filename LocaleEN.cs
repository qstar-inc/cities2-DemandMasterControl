using Colossal;
using System.Collections.Generic;

namespace DemandMaster
{
    public class LocaleEN(Setting setting) : IDictionarySource
    {
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            string Frames = "Frames";

            static string NumUnoccupied(string type, string form = "buildings") => $"The number of {type} {form} need to be unoccupied.";
            static string ImpToDemand(string type) => $"This value determines how important {type} is to the demand.";
            static string ConsNeutral(string type) => $"The {type} percentage which is to be considered neutral.";

            return new Dictionary<string, string>
            {
                { setting.GetSettingsLocaleID(), Mod.Name },
                { setting.GetOptionTabLocaleID(Setting.FactorTab), Setting.FactorTab },
                { setting.GetOptionTabLocaleID(Setting.DemandTab), Setting.DemandTab },
                { setting.GetOptionTabLocaleID(Setting.CommuterTab), Setting.CommuterTab },
                { setting.GetOptionTabLocaleID(Setting.AboutTab), Setting.AboutTab },

                { setting.GetOptionGroupLocaleID(Setting.HappinessGroup), Setting.HappinessGroup },
                { setting.GetOptionGroupLocaleID(Setting.WorkplaceGroup), Setting.WorkplaceGroup },
                { setting.GetOptionGroupLocaleID(Setting.OthersGroup), Setting.OthersGroup },
                { setting.GetOptionGroupLocaleID(Setting.ResiDemandGroup), Setting.ResiDemandGroup },
                { setting.GetOptionGroupLocaleID(Setting.CommDemandGroup), Setting.CommDemandGroup },
                { setting.GetOptionGroupLocaleID(Setting.IndDemandGroup), Setting.IndDemandGroup },
                { setting.GetOptionGroupLocaleID(Setting.EduGroup), Setting.EduGroup },
                { setting.GetOptionGroupLocaleID(Setting.SpawnGroup), Setting.SpawnGroup },
                { setting.GetOptionGroupLocaleID(Setting.CommuterGroup), Setting.CommuterGroup },
                { setting.GetOptionGroupLocaleID(Setting.CommuterPrefGroup), Setting.CommuterPrefGroup },
                { setting.GetOptionGroupLocaleID(Setting.TouristPrefGroup), Setting.TouristPrefGroup },
                { setting.GetOptionGroupLocaleID(Setting.CitizenGroup), Setting.CitizenGroup },
                { setting.GetOptionGroupLocaleID(Setting.CitizenPrefGroup), Setting.CitizenPrefGroup },
                { setting.GetOptionGroupLocaleID(Setting.InfoGroup), Setting.InfoGroup },

                { setting.GetOptionLabelLocaleID(nameof(Setting.MinimumHappiness)), "Minimum Happiness" },
                { setting.GetOptionDescLocaleID(nameof(Setting.MinimumHappiness)), "The lowest happiness value that affects demand. Value less than this won't have any effect." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.NeutralHappiness)), "Neutral Happiness" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NeutralHappiness)), ConsNeutral("happiness") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.HappinessEffect)), "Happiness Effect" },
                { setting.GetOptionDescLocaleID(nameof(Setting.HappinessEffect)), ImpToDemand("happiness") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.HappinessText)), "Current Happiness" },
                { setting.GetOptionDescLocaleID(nameof(Setting.HappinessText)), "" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.AvailableWorkplaceEffect)), "Available Workplace Effect" },
                { setting.GetOptionDescLocaleID(nameof(Setting.AvailableWorkplaceEffect)), ImpToDemand("available workplace") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.NeutralUnemployment)), "Neutral Unemployment" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NeutralUnemployment)), ConsNeutral("unemployment") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.NeutralAvailableWorkplacePercentage)), "Neutral Available Workplace Percentage" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NeutralAvailableWorkplacePercentage)), ConsNeutral("available workplace") },

                { setting.GetOptionLabelLocaleID(nameof(Setting.TaxEffect)), "Tax Effect" },
                { setting.GetOptionDescLocaleID(nameof(Setting.TaxEffect)), ImpToDemand("tax") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.StudentEffect)), "Student Effect" },
                { setting.GetOptionDescLocaleID(nameof(Setting.StudentEffect)), ImpToDemand("student") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.HomelessEffect)), "Homeless Effect" },
                { setting.GetOptionDescLocaleID(nameof(Setting.HomelessEffect)), ImpToDemand("homelessness") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.NeutralHomelessness)), "Neutral Homelessness" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NeutralHomelessness)), ConsNeutral("homelessness") },

                { setting.GetOptionLabelLocaleID(nameof(Setting.FreeResidentialRequirement_Low)), "Unoccupied Low Density Residential" },
                { setting.GetOptionDescLocaleID(nameof(Setting.FreeResidentialRequirement_Low)), NumUnoccupied("low density residential", "households") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.FreeResidentialRequirement_Medium)), "Unoccupied Medium Density Residential" },
                { setting.GetOptionDescLocaleID(nameof(Setting.FreeResidentialRequirement_Medium)), NumUnoccupied("medium density residential", "households") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.FreeResidentialRequirement_High)), "Unoccupied High Density Residential" },
                { setting.GetOptionDescLocaleID(nameof(Setting.FreeResidentialRequirement_High)), NumUnoccupied("high density residential", "households") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.FreeCommercialProportion)), "Unoccupied Commercial" },
                { setting.GetOptionDescLocaleID(nameof(Setting.FreeCommercialProportion)), NumUnoccupied("commercial") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.FreeIndustrialProportion)), "Unoccupied Industrial" },
                { setting.GetOptionDescLocaleID(nameof(Setting.FreeIndustrialProportion)), NumUnoccupied("industrial") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CommercialStorageMinimum)), "Commercial Storage Minimum" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CommercialStorageMinimum)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CommercialStorageEffect)), "Commercial Storage Effect" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CommercialStorageEffect)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CommercialBaseDemand)), "Commercial Base Demand" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CommercialBaseDemand)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.IndustrialStorageMinimum)), "Industrial Storage Minimum" },
                { setting.GetOptionDescLocaleID(nameof(Setting.IndustrialStorageMinimum)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.IndustrialStorageEffect)), "Industrial Storage Effect" },
                { setting.GetOptionDescLocaleID(nameof(Setting.IndustrialStorageEffect)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.IndustrialBaseDemand)), "Industrial Base Demand" },
                { setting.GetOptionDescLocaleID(nameof(Setting.IndustrialBaseDemand)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.ExtractorBaseDemand)), "Extractor Base Demand" },
                { setting.GetOptionDescLocaleID(nameof(Setting.ExtractorBaseDemand)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.StorageDemandMultiplier)), "Storage Demand Multiplier" },
                { setting.GetOptionDescLocaleID(nameof(Setting.StorageDemandMultiplier)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CommuterWorkerRatioLimit)), "Commuter Worker Ratio Limit" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CommuterWorkerRatioLimit)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CommuterSlowSpawnFactor)), "Commuter Slow Spawn Factor" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CommuterSlowSpawnFactor)), "" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.CommuterOCSpawnParameters_Road)), "Commuter Preference by Road" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CommuterOCSpawnParameters_Road)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CommuterOCSpawnParameters_Train)), "Commuter Preference by Train" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CommuterOCSpawnParameters_Train)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CommuterOCSpawnParameters_Air)), "Commuter Preference by Air" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CommuterOCSpawnParameters_Air)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CommuterOCSpawnParameters_Ship)), "Commuter Preference by Ship" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CommuterOCSpawnParameters_Ship)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CommuterPrefText)), "Current Commuter Preference" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CommuterPrefText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.TouristOCSpawnParameters_Road)), "Tourist Preference by Road" },
                { setting.GetOptionDescLocaleID(nameof(Setting.TouristOCSpawnParameters_Road)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.TouristOCSpawnParameters_Train)), "Tourist Preference by Train" },
                { setting.GetOptionDescLocaleID(nameof(Setting.TouristOCSpawnParameters_Train)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.TouristOCSpawnParameters_Air)), "Tourist Preference by Air" },
                { setting.GetOptionDescLocaleID(nameof(Setting.TouristOCSpawnParameters_Air)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.TouristOCSpawnParameters_Ship)), "Tourist Preference by Ship" },
                { setting.GetOptionDescLocaleID(nameof(Setting.TouristOCSpawnParameters_Ship)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.TouristPrefText)), "Current Tourist Preference" },
                { setting.GetOptionDescLocaleID(nameof(Setting.TouristPrefText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CitizenOCSpawnParameters_Road)), "Citizen Preference by Road" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CitizenOCSpawnParameters_Road)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CitizenOCSpawnParameters_Train)), "Citizen Preference by Train" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CitizenOCSpawnParameters_Train)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CitizenOCSpawnParameters_Air)), "Citizen Preference by Air" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CitizenOCSpawnParameters_Air)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CitizenOCSpawnParameters_Ship)), "Citizen Preference by Ship" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CitizenOCSpawnParameters_Ship)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.CitizenPrefText)), "Current Citizen Preference" },
                { setting.GetOptionDescLocaleID(nameof(Setting.CitizenPrefText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.TeenSpawnPercentage)), "Teen Spawn Percentage" },
                { setting.GetOptionDescLocaleID(nameof(Setting.TeenSpawnPercentage)), "" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.FrameIntervalForSpawning_Res)), "Residential Properties" },
                { setting.GetOptionDescLocaleID(nameof(Setting.FrameIntervalForSpawning_Res)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.FrameIntervalForSpawning_Com)), "Commercial Properties" },
                { setting.GetOptionDescLocaleID(nameof(Setting.FrameIntervalForSpawning_Com)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.FrameIntervalForSpawning_Ind)), "Industrial Properties" },
                { setting.GetOptionDescLocaleID(nameof(Setting.FrameIntervalForSpawning_Ind)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.HouseholdSpawnSpeedFactor)), "Household" },
                { setting.GetOptionDescLocaleID(nameof(Setting.HouseholdSpawnSpeedFactor)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.NewCitizenEducationParameters_Uneducated)), "Uneducated" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NewCitizenEducationParameters_Uneducated)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.NewCitizenEducationParameters_PoorlyEducated)), "Poorly Uneducated" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NewCitizenEducationParameters_PoorlyEducated)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.NewCitizenEducationParameters_Educated)), "Educated" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NewCitizenEducationParameters_Educated)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.NewCitizenEducationParameters_WellEducated)), "Well Educated" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NewCitizenEducationParameters_WellEducated)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.NewCitizenEducationParameters_HighlyEducated)), "Highly Educated" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NewCitizenEducationParameters_HighlyEducated)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.EducationParamText1)), "Current Education Level" },
                { setting.GetOptionDescLocaleID(nameof(Setting.EducationParamText1)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.EducationParamText2)), "" },
                { setting.GetOptionDescLocaleID(nameof(Setting.EducationParamText2)), "" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod Name" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NameText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Mod Version" },
                { setting.GetOptionDescLocaleID(nameof(Setting.VersionText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.AuthorText)), "Author" },
                { setting.GetOptionDescLocaleID(nameof(Setting.AuthorText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheMod)), "About the Mod:\nThis is a very powerful mod. It allows the player to modify a lot of parameters related to the demand system. However, this is not an infinite demand mod where buildings get built but nobody moves in.\nThat being said I'm calling this an alpha mod, for now. Everything works, that much is tested. However, it is impossible to find every extremes cases.\nThis mod runs only during the simulation is running. That being said, this mod does not touch your save. All settings are global and players can use the button above to reset everything to vanilla in one shot.\nAs always, it is recommended to have reduntant save files just so if your city dies it can be recovered. Also, make sure to have autosave on.\nIf you find a case where the simulation is crashing, please do reach out to me to fix those edge cases.\nEnjoy!" },
                { setting.GetOptionDescLocaleID(nameof(Setting.AboutTheMod)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Reset)), "Reset to Vanilla" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Reset)), "Reset all values to it's vanilla values." },
            };
        }

        public void Unload()
        {

        }
    }
}
