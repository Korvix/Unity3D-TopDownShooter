using UnityEngine;

namespace TopDownShooter.Gameplay
{
    public interface ICameraMode
    {
        void OnActivated(CameraTarget cameraTarget, Camera camera);
        void Update(Camera camera);
    }
}

