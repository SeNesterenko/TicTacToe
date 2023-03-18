using Components;
using Leopotam.Ecs;
using Services;
using UnityComponents;

namespace Systems
{
    public class AnalyzeClickSystem : IEcsRunSystem
    {
        private EcsFilter<CellComponent, ClickedEventComponent>.Exclude<TakenSignComponent> _filter;
        private GameStateComponent _gameStateComponent;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var ecsEntity = ref _filter.GetEntity(index);
            
                ecsEntity.Get<TakenSignComponent>().Sign = _gameStateComponent.CurrentSign;
                ecsEntity.Get<WinEventComponent>();
            
                _gameStateComponent.CurrentSign = _gameStateComponent.CurrentSign == SignType.Cross ? SignType.Ring : SignType.Cross;
            }
        }
    }
}