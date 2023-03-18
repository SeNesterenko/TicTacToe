using Leopotam.Ecs;
using UnityEngine;

public class CreateTakenSignViewSystem : IEcsRunSystem
{
    private EcsFilter<TakenSign, CellViewRef>.Exclude<TakenSignRef> _filter;
    private Configuration _configuration;

    public void Run()
    {
        foreach (var index in _filter)
        {
            var position = _filter.Get2(index).CellView.transform.position;
            var takenType = _filter.Get1(index).Sign;

            var signView = takenType switch
            {
                SignType.Cross => _configuration.CrossView,
                SignType.Ring => _configuration.RingView,
                _ => null
            };

            var instance = Object.Instantiate(signView, position, Quaternion.identity);
            _filter.GetEntity(index).Get<TakenSignRef>().SignView = instance;
        }
    }
}