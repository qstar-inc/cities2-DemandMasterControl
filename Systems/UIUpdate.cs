using Colossal.Entities;
using Colossal.Serialization.Entities;
using Game.City;
using Game;
using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Game.Simulation;
using Game.Citizens;

namespace DemandMasterControl.Systems
{
    public partial class UIUpdate : GameSystemBase
    {
        private EntityQuery populationQuery;
        public double PopulationValue = 0;
        private readonly Setting settings = Mod.m_Setting;

        protected override void OnCreate()
        {
            base.OnCreate();

            populationQuery = GetEntityQuery(new EntityQueryDesc()
            {
                All = new[] {
                    ComponentType.ReadOnly<Population>()
                }
            });
            RequireForUpdate(populationQuery);
        }

        protected override void OnGamePreload(Colossal.Serialization.Entities.Purpose purpose, GameMode mode)
        {
            base.OnGamePreload(purpose, mode);

            if ($"{mode}" == "Game")
            {
                settings.NotGameMode = false;
                Enabled = true;
            }
            else
            {
                settings.NotGameMode = true;
                Enabled = false;
            }
        }

        protected override void OnUpdate()
        {
            try
            {
                var entities = populationQuery.ToEntityArray(Allocator.Temp);
                foreach (Entity entity in entities)
                {
                    if (EntityManager.TryGetComponent(entity, out Population population))
                    {
                        int num4 = math.max(settings.MinimumHappiness, population.m_AverageHappiness);
                        float num6 = settings.HappinessEffect * (float)(num4 - settings.NeutralHappiness) / 1000;
                        num6 *= population.m_AverageHappiness / 100;
                        settings.CurrentHappinessValue = $"{population.m_AverageHappiness}% (boosted to {num6}%)";
                    }
                }
            }
            catch (Exception e)
            {
                Mod.log.Info($"[ERROR]: {e}");
            }
        }
    }
}
