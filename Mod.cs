using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using DemandMasterControl.Systems;
using Game;
using Game.Modding;
using Game.SceneFlow;
using Unity.Entities;
using static Game.Rendering.Debug.RenderPrefabRenderer;

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

        //public static Mod Instance { get; private set; }
        public static Setting m_Setting;

        public static string State = "";

        public void OnLoad(UpdateSystem updateSystem)
        {
            //Instance = this;
            VanillaDataSystem.CollectVanillaData();
            //Task.Run(() => VanillaDataSystem.WaitForECSAndCollectData());
            m_Setting = new Setting(this);
            m_Setting.RegisterInOptionsUI();
            if (GameManager.instance.modManager.ListModsEnabled().Contains("Time2Work"))
            {
                m_Setting.IsRealisticTripsRunning = true;
            }
            else
            {
                m_Setting.IsRealisticTripsRunning = false;
            }

            m_Setting.VanillaDataFromStorage = VanillaDataStorage.VanillaData;
            //World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<VanillaDataSystem>();
            //updateSystem.UpdateAfter<VanillaDataSystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateAt<DemandPrefabSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateBefore<UIUpdate>(SystemUpdatePhase.UIUpdate);
            AssetDatabase.global.LoadSettings(
                nameof(DemandMasterControl),
                m_Setting,
                new Setting(this)
            );
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(m_Setting));
            //VanillaDataSystem.OnVanillaDataLoaded += () =>
            //{
            //    m_Setting.ReloadFromVanillaData();
            //    log.Info("Reloaded settings from VanillaData.");
            //};
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
