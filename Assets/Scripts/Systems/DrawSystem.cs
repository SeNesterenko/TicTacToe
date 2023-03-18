using Components;
using Leopotam.Ecs;
using UnityComponents;

namespace Systems
{
    public class DrawSystem : IEcsRunSystem
    {
        private EcsFilter<CellComponent>.Exclude<TakenSignComponent> _freeCells;
        private EcsFilter<WinnerComponent> _winner;
        private SceneData _sceneData;

        public void Run()
        {
            if (_freeCells.IsEmpty() && _winner.IsEmpty())
            {
                _sceneData.UI.LoseScreen.Show(true);
            }
        }
    }
}