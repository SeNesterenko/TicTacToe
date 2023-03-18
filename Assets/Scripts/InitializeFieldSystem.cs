using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

internal class InitializeFieldSystem : IEcsInitSystem
{
    private EcsWorld _world;
    private Configuration _configuration;
    private GameState _gameState;
    
    public void Init()
    {
        for (var x = 0; x < _configuration.LevelWidth; x++)
        {
            for (var y = 0; y < _configuration.LevelHeight; y++)
            {
                var cellEntity = _world.NewEntity();
                cellEntity.Get<Cell>();

                var position = new Vector2Int(x, y);
                
                cellEntity.Get<Position>().Value = position;
                _gameState.Cells.Add(position, cellEntity);
            }
        }

        _world.NewEntity().Get<UpdateCameraEvent>();
    }
}