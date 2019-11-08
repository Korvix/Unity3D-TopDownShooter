using UnityEngine;

namespace TopDownShooter.Gameplay
{
    public class TopDownCamera : ICameraMode
    {
        private Transform target;
        private float cameraSpeed = 5f;
        public void OnActivated(CameraTarget cameraTarget, Camera camera)
        {
            target = cameraTarget.topDownCameraTarget;
            camera.transform.position = target.position;
            camera.transform.rotation = target.rotation;
            camera.fieldOfView = cameraTarget.behindCameraFov;
        }

        public void Update(Camera camera)
        {
            camera.transform.position = Vector3.Lerp(target.position, camera.transform.position, Time.deltaTime * cameraSpeed);
            camera.transform.rotation = Quaternion.Lerp(target.rotation, camera.transform.rotation, Time.deltaTime * cameraSpeed);
        }
    }
}