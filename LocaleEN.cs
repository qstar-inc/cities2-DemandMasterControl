using Colossal;
using Colossal.IO.AssetDatabase.Internal;
using DemandMasterControl.Systems;
using System.Collections.Generic;

namespace DemandMasterControl
{
    public class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;
        private static readonly VanillaData VanillaData = new();

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }
        public string RealisticTripsCheck() { return m_Setting.IsRealisticTripsRunning ? "\r\n[DISABLED] <Realistic Trips> detected" : ""; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            static string NumUnoccupied(string type, string form = "buildings") => $"The number of {type} {form} need to be unoccupied.";
            static string ImpToDemand(string type) => $"This value determines how important '{type}' is to the demand.";
            static string ZeroVal(string type) => $"\r\n- Zero value will remove '{type}' from the demand calculation.";
            static string ConsNeutral(string type) => $"The {type} % which is to be considered normal.";
            static string Default(string value) => $"\r\n- Default: <{value}>";
            static string Preference(string human, string transport) => $"The percentage of {human}s that will prefer using {transport} transportation.";
            static string NewCitizenEducationParameters(string level) => $"The percentage of citizen to spawn with {level} education level.\r\nThe maximum level of a citizen will still depend on the age of the citizen. Thus a new child cannot be highly educated.";
            string LowerNoEffect = $"\r\n- Value lower than this value won't have any effect on demand calculations.";
            string HigherBetter = $"\r\n- Higher value = More demand.";
            string LowerBetter = $"\r\n- Lower value = More demand.";
            
            

            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), Mod.Name },
                { m_Setting.GetOptionTabLocaleID(Setting.FactorTab), Setting.FactorTab },
                { m_Setting.GetOptionTabLocaleID(Setting.DemandTab), Setting.DemandTab },
                { m_Setting.GetOptionTabLocaleID(Setting.OCTab), Setting.OCTab },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), Setting.AboutTab },

                { m_Setting.GetOptionGroupLocaleID(Setting.HappinessGroup), Setting.HappinessGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.WorkplaceGroup), Setting.WorkplaceGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.OthersGroup), Setting.OthersGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResiDemandGroup), Setting.ResiDemandGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.CommDemandGroup), Setting.CommDemandGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.IndDemandGroup), Setting.IndDemandGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.EduGroup), Setting.EduGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.SpawnGroup), Setting.SpawnGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.CommuterGroup), Setting.CommuterGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.CommuterPrefGroup), Setting.CommuterPrefGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.TouristPrefGroup), Setting.TouristPrefGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.CitizenGroup), Setting.CitizenGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.CitizenPrefGroup), Setting.CitizenPrefGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.InfoGroup), Setting.InfoGroup },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MinimumHappiness)), "Minimum Happiness" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MinimumHappiness)), $"The lowest happiness value that affects demand. {LowerNoEffect} {HigherBetter} {Default($"{VanillaData.MinimumHappiness}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NeutralHappiness)), "Neutral Happiness" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NeutralHappiness)), $"{ConsNeutral("Happiness")} {LowerBetter} {Default($"{VanillaData.NeutralHappiness}%")}"},
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HappinessEffect)), "Happiness Effect" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HappinessEffect)), $"{ImpToDemand("Happiness")} {HigherBetter} {ZeroVal("Happiness")} {Default($"{VanillaData.HappinessEffect}")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CurrentHappiness)), "Current Happiness" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CurrentHappiness)), "The current happiness value in the currently loaded city." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AvailableWorkplaceEffect)), "Free Workplaces Effect" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AvailableWorkplaceEffect)), $"{ImpToDemand("Free Workplaces")} {HigherBetter} {ZeroVal("Free Workplaces")} {Default($"{VanillaData.AvailableWorkplaceEffect}")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NeutralUnemployment)), "Neutral Unemployment" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NeutralUnemployment)), $"{ConsNeutral("Unemployment")} {HigherBetter} {Default($"{VanillaData.NeutralUnemployment}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NeutralAvailableWorkplacePercentage)), "Neutral Free Workplaces Percentage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NeutralAvailableWorkplacePercentage)), $"{ConsNeutral("Free Workplaces")} {Default($"{VanillaData.NeutralAvailableWorkplacePercentage}%")}" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TaxEffect)), "Tax Effect" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TaxEffect)), $"{ImpToDemand("Taxes")} {HigherBetter} (with Low Tax) {ZeroVal("Taxes")} {Default($"{VanillaData.TaxEffect}")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StudentEffect)), "Student Effect" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StudentEffect)), $"{ImpToDemand("Students")} {HigherBetter} {ZeroVal("Students")} {Default($"{VanillaData.StudentEffect}")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HomelessEffect)), "Homeless Effect" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HomelessEffect)), $"{ImpToDemand("Homelessness")} {HigherBetter} {Default($"{VanillaData.HomelessEffect}")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NeutralHomelessness)), "Neutral Homelessness" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NeutralHomelessness)), $"{ConsNeutral("Homelessness")} {HigherBetter} {Default($"{VanillaData.NeutralHomelessness}%")}" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FreeResidentialRequirement_Low)), "Unoccupied Low Density Residential" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FreeResidentialRequirement_Low)), $"{NumUnoccupied("low density residential", "households")} {HigherBetter} {Default($"{VanillaData.FreeResidentialRequirement.x}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FreeResidentialRequirement_Medium)), "Unoccupied Medium Density Residential" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FreeResidentialRequirement_Medium)), $"{NumUnoccupied("medium density residential", "households")} {HigherBetter} {Default($"{VanillaData.FreeResidentialRequirement.y}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FreeResidentialRequirement_High)), "Unoccupied High Density Residential" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FreeResidentialRequirement_High)), $"{NumUnoccupied("high density residential", "households")} {HigherBetter} {Default($"{VanillaData.FreeResidentialRequirement.z}%")}" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CommercialBaseDemand)), "Commercial Demand" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CommercialBaseDemand)), $"The base commercial demand that will be multiplied with other factors. {HigherBetter} {Default($"{VanillaData.CommercialBaseDemand}")}" },
                //{ m_Setting.GetOptionLabelLocaleID(nameof(Setting.FreeCommercialProportion)), "Unoccupied Commercial" },
                //{ m_Setting.GetOptionDescLocaleID(nameof(Setting.FreeCommercialProportion)), $"{NumUnoccupied("commercial")} {HigherBetter} {Default($"{VanillaData.FreeCommercialProportion}")}" },
                //{ m_Setting.GetOptionLabelLocaleID(nameof(Setting.CommercialStorageMinimum)), "Commercial Storage Minimum" },
                //{ m_Setting.GetOptionDescLocaleID(nameof(Setting.CommercialStorageMinimum)), "" },
                //{ m_Setting.GetOptionLabelLocaleID(nameof(Setting.CommercialStorageEffect)), "Commercial Storage Effect" },
                //{ m_Setting.GetOptionDescLocaleID(nameof(Setting.CommercialStorageEffect)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HotelRoomPercentRequirement)), "Hotel Demand" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HotelRoomPercentRequirement)), $"The base motel/hotel demand that will be multiplied with other factors. {HigherBetter} {Default($"{VanillaData.HotelRoomPercentRequirement}")}" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.IndustrialBaseDemand)), "Industrial Demand" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.IndustrialBaseDemand)), $"The base industrial demand that will be multiplied with other factors. {HigherBetter} {Default($"{VanillaData.IndustrialBaseDemand}")}" },
                //{ m_Setting.GetOptionLabelLocaleID(nameof(Setting.FreeIndustrialProportion)), "Unoccupied Industrial" },
                //{ m_Setting.GetOptionDescLocaleID(nameof(Setting.FreeIndustrialProportion)), $"{NumUnoccupied("industrial")} {HigherBetter} {Default($"{VanillaData.FreeIndustrialProportion}")}" },
                //{ m_Setting.GetOptionLabelLocaleID(nameof(Setting.IndustrialStorageMinimum)), "Industrial Storage Minimum" },
                //{ m_Setting.GetOptionDescLocaleID(nameof(Setting.IndustrialStorageMinimum)), "" },
                //{ m_Setting.GetOptionLabelLocaleID(nameof(Setting.IndustrialStorageEffect)), "Industrial Storage Effect" },
                //{ m_Setting.GetOptionDescLocaleID(nameof(Setting.IndustrialStorageEffect)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ExtractorBaseDemand)), "Extractor Demand" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ExtractorBaseDemand)), $"The base extractor demand that will be multiplied with other factors. {HigherBetter} {Default($"{VanillaData.ExtractorBaseDemand}")}" },
                //{ m_Setting.GetOptionLabelLocaleID(nameof(Setting.StorageDemandMultiplier)), "Storage Demand Multiplier" },
                //{ m_Setting.GetOptionDescLocaleID(nameof(Setting.StorageDemandMultiplier)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CommuterWorkerRatioLimit)), "Commuter Worker Ratio Limit" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CommuterWorkerRatioLimit)), $"The rate which determines how many worker commuter to spawn.\r\n- Lower value = More Commuter Worker {Default($"{VanillaData.CommuterWorkerRatioLimit}")} {RealisticTripsCheck()}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CommuterSlowSpawnFactor)), "Commuter Slow Spawn Factor" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CommuterSlowSpawnFactor)), $"The rate which determines the amount of commuters to spawn.\r\n- Lower value = More Frequency {Default($"{VanillaData.CommuterSlowSpawnFactor}")}" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TeenSpawnPercentage)), "Teen Spawn Percentage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TeenSpawnPercentage)), $"A randomization probability to determine if a citizen spawned is a child or a teen.{Default($"{VanillaData.TeenSpawnPercentage * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CitizenOCSpawnParameters_Road)), "Citizen Preference by Road" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CitizenOCSpawnParameters_Road)), $"{Preference("citizen", "road")} {Default($"{VanillaData.CitizenOCSpawnParameters.x * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CitizenOCSpawnParameters_Train)), "Citizen Preference by Train" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CitizenOCSpawnParameters_Train)), $"{Preference("citizen", "rail")} {Default($"{VanillaData.CitizenOCSpawnParameters.y * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CitizenOCSpawnParameters_Air)), "Citizen Preference by Air" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CitizenOCSpawnParameters_Air)), $"{Preference("citizen", "air")} {Default($"{VanillaData.CitizenOCSpawnParameters.z * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CitizenOCSpawnParameters_Ship)), "Citizen Preference by Ship" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CitizenOCSpawnParameters_Ship)), $"{Preference("citizen", "water")} {Default($"{VanillaData.CitizenOCSpawnParameters.w * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CitizenPrefText)), "Current Citizen Preference" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CitizenPrefText)), "The overall citizen preference for all transport." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CommuterOCSpawnParameters_Road)), "Commuter Preference by Road" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CommuterOCSpawnParameters_Road)), $"{Preference("commuter", "road")} {Default($"{VanillaData.CommuterOCSpawnParameters.x * 100}%")} {RealisticTripsCheck()}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CommuterOCSpawnParameters_Train)), "Commuter Preference by Train" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CommuterOCSpawnParameters_Train)), $"{Preference("commuter", "rail")} {Default($"{VanillaData.CommuterOCSpawnParameters.y * 100}%")} {RealisticTripsCheck()}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CommuterOCSpawnParameters_Air)), "Commuter Preference by Air" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CommuterOCSpawnParameters_Air)), $"{Preference("commuter", "air")} {Default($"{VanillaData.CommuterOCSpawnParameters.z * 100}%")} {RealisticTripsCheck()}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CommuterOCSpawnParameters_Ship)), "Commuter Preference by Ship" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CommuterOCSpawnParameters_Ship)), $"{Preference("commuter", "water")} {Default($"{VanillaData.CommuterOCSpawnParameters.w * 100}%")} {RealisticTripsCheck()}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CommuterPrefText)), "Current Commuter Preference" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CommuterPrefText)), "The overall commuter preference for all transport." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TouristOCSpawnParameters_Road)), "Tourist Preference by Road" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TouristOCSpawnParameters_Road)), $"{Preference("tourist", "road")} {Default($"{VanillaData.TouristOCSpawnParameters.x * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TouristOCSpawnParameters_Train)), "Tourist Preference by Train" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TouristOCSpawnParameters_Train)), $"{Preference("tourist", "rail")} {Default($"{VanillaData.TouristOCSpawnParameters.y * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TouristOCSpawnParameters_Air)), "Tourist Preference by Air" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TouristOCSpawnParameters_Air)), $"{Preference("tourist", "air")} {Default($"{VanillaData.TouristOCSpawnParameters.z * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TouristOCSpawnParameters_Ship)), "Tourist Preference by Ship" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TouristOCSpawnParameters_Ship)), $"{Preference("tourist", "water")} {Default($"{VanillaData.TouristOCSpawnParameters.w * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TouristPrefText)), "Current Tourist Preference" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TouristPrefText)), "The overall tourist preference for all transport." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameIntervalForSpawning_Res)), "Residential Cooldown" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameIntervalForSpawning_Res)), $"The cooldown interval for spawining citizens.\r\n- Lower value = More Frequent.\r\n- Lower value can cause delayed simulation in high population city. {Default($"{VanillaData.FrameIntervalForSpawning.x}")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameIntervalForSpawning_Com)), "Commercial Cooldown" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameIntervalForSpawning_Com)), $"The cooldown interval for spawining commercial businesses.\r\n- Lower value = More Frequent.\r\n- Lower value can cause delayed simulation in high population city. {Default($"{VanillaData.FrameIntervalForSpawning.y}")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameIntervalForSpawning_Ind)), "Industrial Cooldown" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameIntervalForSpawning_Ind)), $"The cooldown interval for spawining industrial businesses.\r\n- Lower value = More Frequent.\r\n- Lower value can cause delayed simulation in high population city. {Default($"{VanillaData.FrameIntervalForSpawning.z}")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HouseholdSpawnSpeedFactor)), "Household" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HouseholdSpawnSpeedFactor)), $"A rate which is used to determine the amount of household required to spawn.\r\n- Lower value = More Frequency {Default($"{VanillaData.HouseholdSpawnSpeedFactor * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NewCitizenEducationParameters_Uneducated)), "Uneducated" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NewCitizenEducationParameters_Uneducated)), $"{NewCitizenEducationParameters("uneducated")} {Default($"{VanillaData.NewCitizenEducationParameters.x * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NewCitizenEducationParameters_PoorlyEducated)), "Poorly Uneducated" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NewCitizenEducationParameters_PoorlyEducated)), $"{NewCitizenEducationParameters("poorly educated")} {Default($"{VanillaData.NewCitizenEducationParameters.y * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NewCitizenEducationParameters_Educated)), "Educated" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NewCitizenEducationParameters_Educated)), $"{NewCitizenEducationParameters("educated")} {Default($"{VanillaData.NewCitizenEducationParameters.z * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NewCitizenEducationParameters_WellEducated)), "Well Educated" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NewCitizenEducationParameters_WellEducated)), $"{NewCitizenEducationParameters("well educated")} {Default($"{VanillaData.NewCitizenEducationParameters.w * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NewCitizenEducationParameters_HighlyEducated)), "Highly Educated" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NewCitizenEducationParameters_HighlyEducated)), $"{NewCitizenEducationParameters("highly educated")} {Default($"{VanillaData.NewCitizenEducationParameters_HighlyRaw * 100}%")}" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EducationParamText1)), "Current Levels" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EducationParamText1)), "The overall education level preference for incoming citizens." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EducationParamText2)), "" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EducationParamText2)), "" },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod Name" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Mod Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AuthorText)), "Author" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AuthorText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BMaCLink)), "Buy Me a Coffee" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BMaCLink)), "Support the author." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheMod)), $"About the Mod:\n{Mod.Name} is a very powerful mod. It allows players to modify a whole lot of parameters related to the demand system. However, this is not an infinite demand mod where buildings get built but nobody moves in.\nThis mod runs only while the simulation is running. That being said, this mod does not touch your save. All settings are global and players can use the button above to reset everything to vanilla in one shot.\nAs always, it is recommended to have reduntant save files just so if your city dies it can be recovered. Also, make sure to have autosave on.\nEnjoy!" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutTheMod)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Reset)), "Reset to Vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Reset)), "Reset all values to it's vanilla values." },
            };
        }

        public void Unload()
        {

        }
    }
}
