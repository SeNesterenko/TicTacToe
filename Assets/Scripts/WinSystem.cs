using Leopotam.Ecs;

public class WinSystem : IEcsRunSystem
{
    private EcsFilter<Winner, TakenSign> _filter;
    private SceneData _sceneData;

    public void Run()
    {
        if (!_sceneData.UI.WinScreen.gameObject.activeInHierarchy)
        {
            foreach (var index in _filter)
            {
                ref var winnerSign = ref _filter.Get2(index);

                _sceneData.UI.WinScreen.Show(true);
                _sceneData.UI.WinScreen.SetWinner(winnerSign.Sign);

                _filter.GetEntity(index).Del<Winner>();
            }   
        }
    }
}