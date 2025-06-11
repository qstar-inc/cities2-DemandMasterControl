using System.Linq;
using System.Reflection;
using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using DemandMasterControl.Systems;
using Game;
using Game.Modding;
using Game.SceneFlow;

namespace DemandMasterControl
{
    public class Mod : IMod
    {
        public static string Name = Assembly
            .GetExecutingAssembly()
            .GetCustomAttribute<AssemblyTitleAttribute>()
            .Title;
        public static string Version = Assembly
            .GetExecutingAssembly()
            .GetName()
            .Version.ToString(3);

        public static ILog log = LogManager
            .GetLogger($"{nameof(DemandMasterControl)}")
            .SetShowsErrorsInUI(false);
        public static Setting m_Setting;

        public void OnLoad(UpdateSystem updateSystem)
        {
            m_Setting = new Setting(this);
            m_Setting.RegisterInOptionsUI();
            AssetDatabase.global.LoadSettings(
                nameof(DemandMasterControl),
                m_Setting,
                new Setting(this)
            );
            if (GameManager.instance.modManager.ListModsEnabled().Contains("Time2Work"))
            {
                m_Setting.IsRealisticTripsRunning = true;
            }
            else
            {
                m_Setting.IsRealisticTripsRunning = false;
            }

            updateSystem.UpdateAfter<VanillaDataSystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateAt<DemandPrefabSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateBefore<UIUpdate>(SystemUpdatePhase.UIUpdate);
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(m_Setting));
        }

        public void OnDispose()
        {
            if (m_Setting != null)
            {
                m_Setting.UnregisterInOptionsUI();
                m_Setting = null;
            }
        }
    }
}
