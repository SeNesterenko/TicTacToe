using Components;
using Leopotam.Ecs;
using Services;
using UnityComponents;

namespace Systems
{
    public class CheckWinSystem : IEcsRunSystem
    {
        private EcsFilter<PositionComponent, TakenSignComponent, WinEventComponent> _filter;
        private Configuration _configuration;
        private GameStateComponent _gameStateComponent;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get1(index);

                var chainLength = _gameStateComponent.Cells.GetLongestChain(position.Value);
                if (chainLength >= _configuration.WinChaneLenght)
                {
                    _filter.GetEntity(index).Get<WinnerComponent>();
                }
            }
        }
    }
}