using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using DemandMasterControl.Systems;
using Game;
using Game.Modding;
using Game.SceneFlow;
using System.Linq;

namespace DemandMasterControl
{
    public class Mod : IMod
    {
        public static string Name = "Demand Master Control";
        public static string Version = "2.0.2";
        public static string Author = "StarQ";

        public static ILog log = LogManager.GetLogger($"{nameof(DemandMasterControl)}").SetShowsErrorsInUI(false);
        private static readonly VanillaData VanillaData = new(); 
        public static Setting m_Setting;

        public void OnLoad(UpdateSystem updateSystem)
        {
            //log.Info(nameof(OnLoad));

            //if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                //log.Info($"Current mod asset at {asset.path}");

            m_Setting = new Setting(this);
            m_Setting.RegisterInOptionsUI();
            AssetDatabase.global.LoadSettings(nameof(DemandMasterControl), m_Setting, new Setting(this));
            if (GameManager.instance.modManager.ListModsEnabled().Contains("Time2Work"))
            {
                m_Setting.IsRealisticTripsRunning = true;
            }
            else
            {
                m_Setting.IsRealisticTripsRunning = false;
            }

            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(m_Setting));

            updateSystem.UpdateAt<DemandPrefabSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateBefore<UIUpdate>(SystemUpdatePhase.UIUpdate);
        }

        public void OnDispose()
        {
            //log.Info(nameof(OnDispose));
            if (m_Setting != null)
            {
                m_Setting.UnregisterInOptionsUI();
                m_Setting = null;
            }
        }
    }
}
