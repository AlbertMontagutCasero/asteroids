using UnityEngine;

namespace Asteroids
{
    public class AsteroidsCamera: MonoBehaviour, EngineCameraContext
    {
        private Camera cameraComponent;

        private void Awake()
        {
            this.cameraComponent = this.GetComponent<Camera>();
        }

        public float GetOrthographicSize()
        {
            return this.cameraComponent.orthographicSize;
        }

        public float GetAspectRatio()
        {
            return this.cameraComponent.aspect;
        }
    }
}