using UnityEngine;

namespace TopDownShooter.Gameplay
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private Animator animator;
        private PlayerMovementController playerMovementController;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            playerMovementController = GetComponent<PlayerMovementController>();
        }

        void Update()
        {
            if (playerMovementController.GetDirection() != Vector3.zero)
            {
                if (playerMovementController.IsRunning())
                {
                    animator.SetBool("Run", true);
                    animator.SetBool("Walk", false);
                }
                else
                {
                    animator.SetBool("Run", false);
                    animator.SetBool("Walk", true);
                }
            }
            else
            {
                animator.SetBool("Run", false);
                animator.SetBool("Walk", false);
            }
            animator.SetBool("Forward", playerMovementController.IsForward());

            if (playerMovementController.GetVelocity().y > 3)
            {
                animator.SetBool("JumpStart", true);
                animator.SetBool("Jump", false);

                animator.SetBool("Run", false);
                animator.SetBool("Walk", false);

            }
            if (playerMovementController.GetVelocity().y > -3 && playerMovementController.GetVelocity().y < 3)
            {
                animator.SetBool("Jump", true);
            }

            if (playerMovementController.GetVelocity().y < -3)
            {
                animator.SetBool("JumpStart", false);
                animator.SetBool("Jump", false);
            }

            if (playerMovementController.GetVelocity().y < -5)
            {
                animator.SetBool("FallDown", true);
                animator.SetBool("Run", false);
                animator.SetBool("Walk", false);
            }

            if (playerMovementController.GetVelocity().y > -5)
            {
                animator.SetBool("FallDown", false);
            }
        }
    }
}