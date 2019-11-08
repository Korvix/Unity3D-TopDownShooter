using UnityEngine;
using System.Collections;
using TopDownShooter.GameSystem;

namespace TopDownShooter.Gameplay
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private CameraTarget cameraTarget;
        private ICameraMode[] cameraModes;
        private int actualCameraNumber;
        private Camera mainCamera;

        private InputData inputData;

        private void Awake()
        {
            mainCamera = Camera.main;
            CreateCameraModes();
            ChangeCamera();
            inputData = GameContext.Instance.InputData;
        }

        private void LateUpdate()
        {
            cameraModes[actualCameraNumber].Update(mainCamera);
            if (inputData.backButtonDown)
            {
                if (actualCameraNumber == 0)
                {
                    actualCameraNumber = 1;
                }
                else
                {
                    actualCameraNumber = 0;
                }
                ChangeCamera();
            }
        }

        private void CreateCameraModes()
        {
            cameraModes = new ICameraMode[] { new BehindCamera(), new TopDownCamera() };
        }

        private void ChangeCamera()
        {
            cameraModes[actualCameraNumber].OnActivated(cameraTarget, mainCamera);
        }
    }
}

