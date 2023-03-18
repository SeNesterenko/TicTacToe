using Components;
using Leopotam.Ecs;
using Services;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    internal class InitializeFieldSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private Configuration _configuration;
        private GameStateComponent _gameStateComponent;
    
        public void Init()
        {
            for (var x = 0; x < _configuration.LevelWidth; x++)
            {
                for (var y = 0; y < _configuration.LevelHeight; y++)
                {
                    var cellEntity = _world.NewEntity();
                    cellEntity.Get<CellComponent>();

                    var position = new Vector2Int(x, y);
                
                    cellEntity.Get<PositionComponent>().Value = position;
                    _gameStateComponent.Cells.Add(position, cellEntity);
                }
            }

            _world.NewEntity().Get<UpdateCameraEventComponent>();
        }
    }
}