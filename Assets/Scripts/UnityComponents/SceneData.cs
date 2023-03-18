using UnityEngine;

namespace UnityComponents
{
    public class SceneData : MonoBehaviour
    {
        public Transform CameraTransform => _cameraTransform;
        public Camera Camera => _camera;
        public UI UI => _uI;

        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Camera _camera;
        [SerializeField] private UI _uI;
    }
}