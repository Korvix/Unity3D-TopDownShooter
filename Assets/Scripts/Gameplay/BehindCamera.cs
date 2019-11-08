using TopDownShooter.GameSystem;
using UnityEngine;

namespace TopDownShooter.Gameplay
{
    public class BehindCamera : ICameraMode
    {
        private Transform target;
        private Transform targetObject;
        private Transform player;
        private float cameraSpeed = 5f;
        private float cameraRotationSpeed = 100f;
        private float rotationTimer = 0f;
        private bool rotationReset = false;

        private InputData inputData;

        public BehindCamera()
        {
            inputData = GameContext.Instance.InputData;
        }

        public void OnActivated(CameraTarget cameraTarget, Camera camera)
        {
            target = cameraTarget.behindCameraTarget;
            targetObject = cameraTarget.transform;
            camera.transform.position = target.position;
            camera.transform.rotation = target.rotation;
            camera.fieldOfView = cameraTarget.behindCameraFov;
            player = cameraTarget.playerPosition;
        }

        public void Update(Camera camera)
        {
            camera.transform.position = Vector3.Slerp(target.position, camera.transform.position, Time.deltaTime * cameraSpeed);
            camera.transform.rotation = Quaternion.Slerp(target.rotation, camera.transform.rotation, Time.deltaTime * cameraSpeed);

            if (inputData.rightStickX != 0f)
            {
                rotationReset = false;
                rotationTimer = 1f;
                targetObject.transform.Rotate(0, cameraRotationSpeed * inputData.rightStickX * Time.deltaTime, 0);
            }

            if (rotationTimer > 0)
            {
                rotationTimer -= Time.deltaTime;
                if (rotationTimer < 0)
                {
                    rotationReset = true;
                }
            }

            if (rotationReset == true)
            {
                targetObject.transform.rotation = Quaternion.Slerp(player.rotation, targetObject.transform.rotation, 0.0001f);
                if (targetObject.rotation == player.rotation)
                {
                    rotationReset = false;
                }
            }
        }
    }
}