using Leopotam.Ecs;

public class CheckWinSystem : IEcsRunSystem
{
    private EcsFilter<Position, TakenSign, CheckWinEvent> _filter;
    private Configuration _configuration;
    private GameState _gameState;

    public void Run()
    {
        foreach (var index in _filter)
        {
            ref var position = ref _filter.Get1(index);
            ref var type = ref _filter.Get2(index);

            var chainLength = _gameState.Cells.GetLongestChain(position.Value);
            if (chainLength >= _configuration.WinChaneLenght)
            {
                _filter.GetEntity(index).Get<Winner>();
            }
        }
    }
}