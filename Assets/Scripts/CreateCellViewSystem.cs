using Leopotam.Ecs;
using UnityEngine;

public class CreateCellViewSystem : IEcsRunSystem
{
    private EcsFilter<Cell, Position>.Exclude<CellViewRef> _filter;
    private Configuration _configuration;
    
    public void Run()
    {
        foreach (var index in _filter)
        {
            var offset = _configuration.Offset;
            ref var position = ref _filter.Get2(index);
            
            var cellView = Object.Instantiate(_configuration.CellView);
            cellView.transform.position = new Vector2(position.Value.x + offset.x * position.Value.x, position.Value.y + offset.y * position.Value.y);
            cellView.Entity = _filter.GetEntity(index);
            
            _filter.GetEntity(index).Get<CellViewRef>().CellView = cellView;
        }
    }
}