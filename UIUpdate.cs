using Colossal.Entities;
using Colossal.Serialization.Entities;
using Game.City;
using Game;
using System;
using Unity.Collections;
using Unity.Entities;

namespace DemandMaster
{
    public partial class UIUpdate : GameSystemBase
    {
        private EntityQuery populationQuery;
        public double PopulationValue = 0;
        private Setting settings = Mod.m_Setting;

        protected override void OnCreate()
        {
            base.OnCreate();

            populationQuery = GetEntityQuery(new EntityQueryDesc()
            {
                All = [
                    ComponentType.ReadOnly<Population>()
                    ]
            });
            RequireForUpdate(populationQuery);

        }

        protected override void OnGamePreload(Purpose purpose, GameMode mode)
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
                    if (EntityManager.TryGetComponent(entity, out Population data))
                    {
                        settings.HappinessValue = data.m_AverageHappiness;
                    }
                }
            }
            catch (Exception e)
            {
                Mod.log.Error(e);
            }
        }
    }
}
