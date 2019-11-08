using TopDownShooter.GameSystem;
using UnityEngine;

namespace TopDownShooter.Gameplay
{
    public class PlayerMovementController : MonoBehaviour
    {
        private Rigidbody rb;
        private InputData inputData;
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float rotationSpeed;
        [SerializeField]
        private float jumpForce;
        private bool jumpOn = true;
        private Vector3 direction;
        private bool forward;
        private float currentMoveSpeed;

        private void Awake()
        {
            GameContext.Instance.Player = gameObject;
            rb = GetComponent<Rigidbody>();
            inputData = GameContext.Instance.InputData;
            currentMoveSpeed = moveSpeed;
        }
        
        void FixedUpdate()
        {
            if (inputData.triggerLeft > 0f)
            {
                currentMoveSpeed = moveSpeed * 1.5f;
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }
            direction = Vector3.zero;
            if (inputData.leftArrow)
            {
                Quaternion deltaRotation = Quaternion.Euler(-Vector3.up * rotationSpeed * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            if (inputData.rightArrow)
            {
                Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotationSpeed * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            if (inputData.upArrow)
            {
                direction = transform.forward;
                rb.MovePosition(rb.transform.position + direction * currentMoveSpeed * Time.deltaTime);
                forward = true;
            }
            if (inputData.downArrow)
            {
                direction = -transform.forward;
                rb.MovePosition(rb.transform.position + direction * currentMoveSpeed * Time.deltaTime);
                forward = false;
            }
            if (inputData.leftStickX != 0f)
            {
                Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotationSpeed * inputData.leftStickX * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            if (inputData.leftStickY != 0)
            {
                forward = inputData.leftStickY > 0 ? true : false;
                direction = transform.forward * inputData.leftStickY;
                rb.MovePosition(rb.transform.position + direction * currentMoveSpeed * Time.deltaTime);
            }
            if (inputData.aButtonDown && jumpOn)
            {
                jumpOn = false;
                rb.AddForce(Vector3.up * jumpForce * 100f);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
                jumpOn = true;
        }

        public Vector3 GetDirection()
        {
            return direction;
        }

        public bool IsForward()
        {
            return forward;
        }

        public bool IsRunning()
        {
            return currentMoveSpeed > moveSpeed && direction != Vector3.zero;
        }

        public Vector3 GetVelocity()
        {
            return rb.velocity;
        }

    }
}