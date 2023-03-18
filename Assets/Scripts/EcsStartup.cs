using Leopotam.Ecs;
using UnityEngine;

sealed class EcsStartup : MonoBehaviour {
    private EcsWorld _world;
    private EcsSystems _systems;

    [SerializeField] private SceneData _sceneData;
    [SerializeField] private Configuration _configuration;

    void Start () 
    {
        
        _world = new EcsWorld ();
        _systems = new EcsSystems (_world);
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
        var gameState = new GameState();
        
        _systems
            // register your systems here, for example:
            .Add (new InitializeFieldSystem ())
            .Add (new CreateCellViewSystem ())
            .Add (new SetCameraSystem())
            .Add(new ControlSystem())
            .Add(new AnalyzeClickSystem())
            .Add(new CreateTakenSignViewSystem())
            .Add(new CheckWinSystem ())
            .Add(new WinSystem ())
            .Add(new DrawSystem ())

            // register one-frame components (order is important), for example:
            .OneFrame<UpdateCameraEvent> ()
            .OneFrame<ClickedEvent> ()
            .OneFrame<CheckWinEvent> ()    
            // inject service instances here (order doesn't important), for example:
            .Inject (_configuration)
            .Inject (_sceneData)
            .Inject(gameState)
            .Init ();
    }

    void Update () {
        _systems?.Run ();
    }

    private void OnDestroy () 
    {
        if (_systems != null) {
            _systems.Destroy ();
            _systems = null;
            _world.Destroy ();
            _world = null;
        }
    }
}

internal class DrawSystem : IEcsRunSystem
{
    private EcsFilter<Cell>.Exclude<TakenSign> _freeCells;
    private EcsFilter<Winner> _winner;
    private SceneData _sceneData;

    public void Run()
    {
        if (_freeCells.IsEmpty() && _winner.IsEmpty())
        {
            _sceneData.UI.LoseScreen.Show(true);
        }
    }
}