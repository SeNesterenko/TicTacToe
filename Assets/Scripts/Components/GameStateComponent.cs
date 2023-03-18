using System.Collections.Generic;
using Leopotam.Ecs;
using Services;
using UnityEngine;

namespace Components
{
    public class GameStateComponent
    {
        public SignType CurrentSign = SignType.Cross;
        public readonly Dictionary<Vector2Int, EcsEntity> Cells = new ();
    }
}