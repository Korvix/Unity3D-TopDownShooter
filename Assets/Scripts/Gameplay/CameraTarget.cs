using UnityEngine;
using System.Collections;

namespace TopDownShooter.Gameplay
{
    public class CameraTarget : MonoBehaviour
    {
        [SerializeField]
        public Transform behindCameraTarget;
        [SerializeField]
        public float behindCameraFov;
        [SerializeField]
        public Transform topDownCameraTarget;
        [SerializeField]
        public float topDownCameraFov;
        [SerializeField]
        public Transform playerPosition;
    }
}

