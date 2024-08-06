using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;

namespace DemandMaster
{
    public class Mod : IMod
    {
        public static string Name = "Demand Master Pro";
        public static string Version = "1.0.0 - Alpha";
        public static string Author = "StarQ";

        public static ILog log = LogManager.GetLogger($"{nameof(DemandMaster)}").SetShowsErrorsInUI(false);
        private static readonly VanillaData VanillaData = new(); 
        public static Setting m_Setting;
        

        public void OnLoad(UpdateSystem updateSystem)
        {
            //log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                //log.Info($"Current mod asset at {asset.path}");

            m_Setting = new Setting(this);
            m_Setting.RegisterInOptionsUI();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(m_Setting));


            AssetDatabase.global.LoadSettings(nameof(DemandMaster), m_Setting, new Setting(this));

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
