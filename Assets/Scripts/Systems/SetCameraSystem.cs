using Components;
using Leopotam.Ecs;
using Services;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class SetCameraSystem : IEcsRunSystem
    {
        private EcsFilter<UpdateCameraEventComponent> _filter;
        private SceneData _sceneData;
        private Configuration _configuration;

        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                var height = _configuration.LevelHeight;
                var width = _configuration.LevelWidth;
                var xOffset = _configuration.Offset.x;
                var yOffset = _configuration.Offset.y;

                var camera = _sceneData.Camera;
                camera.orthographic = true;
                camera.orthographicSize = CalculateOffsetByAxis(height, yOffset);

                _sceneData.CameraTransform.position = new Vector3(CalculateOffsetByAxis(width, xOffset),CalculateOffsetByAxis(height, yOffset));
            }
            
        }

        private static float CalculateOffsetByAxis(int axis, float offset)
        {
            return axis / 2f + (axis - 1) * offset / 2;
        }
    }
}