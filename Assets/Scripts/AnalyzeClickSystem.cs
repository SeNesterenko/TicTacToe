using Leopotam.Ecs;

public class AnalyzeClickSystem : IEcsRunSystem
{
    private EcsFilter<Cell, ClickedEvent>.Exclude<TakenSign> _filter;
    private GameState _gameState;

    public void Run()
    {
        foreach (var index in _filter)
        {
            ref var ecsEntity = ref _filter.GetEntity(index);
            
            ecsEntity.Get<TakenSign>().Sign = _gameState.CurrentSign;
            ecsEntity.Get<CheckWinEvent>();
            
            _gameState.CurrentSign = _gameState.CurrentSign == SignType.Cross ? SignType.Ring : SignType.Cross;
        }
    }
}