using Components;
using Leopotam.Ecs;
using Services;
using Systems;
using UnityComponents;
using UnityEngine;

sealed class EcsStartup : MonoBehaviour 
{
    private EcsWorld _world;
    private EcsSystems _systems;

    [SerializeField] private SceneData _sceneData;
    [SerializeField] private Configuration _configuration;

    private void Start () 
    {
        _world = new EcsWorld ();
        _systems = new EcsSystems (_world);
        
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
        
        var gameState = new GameStateComponent();
        
        _systems
            .Add (new InitializeFieldSystem ())
            .Add (new CreateCellViewSystem ())
            .Add (new SetCameraSystem())
            .Add(new ControlSystem())
            .Add(new AnalyzeClickSystem())
            .Add(new CreateTakenSignViewSystem())
            .Add(new CheckWinSystem ())
            .Add(new WinSystem ())
            .Add(new DrawSystem ())
            
            .OneFrame<UpdateCameraEventComponent> ()
            .OneFrame<ClickedEventComponent> ()
            .OneFrame<WinEventComponent> ()    

            .Inject (_configuration)
            .Inject (_sceneData)
            .Inject(gameState)
            
            .Init ();
    }

    private void Update () 
    {
        _systems?.Run ();
    }

    private void OnDestroy () 
    {
        if (_systems != null) 
        {
            _systems.Destroy ();
            _systems = null;
            _world.Destroy ();
            _world = null;
        }
    }
}