using System.Collections;
using System.Collections.Generic;
using TopDownShooter.GameSystem;
using UnityEngine;

namespace TopDownShooter.Gameplay
{
    public class ZombieMovementController : MonoBehaviour
    {
        [SerializeField]
        private float minPlayerDistance;
        private float playerDistance;

        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float rotationSpeed;

        [SerializeField]
        private Transform playerTransform;
        [SerializeField]
        private Transform navMeshAgentTransform;

        private Quaternion navMeshRotation;

        private Rigidbody rb;

        private bool dealedDamage;
        private float damageTimer = 1f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            playerDistance = Vector3.Distance(playerTransform.position, transform.position);

            Quaternion navMeshRotation = Quaternion.Euler(transform.eulerAngles.x, navMeshAgentTransform.transform.eulerAngles.y, transform.eulerAngles.z);
            Quaternion slowRotation = Quaternion.Lerp(transform.rotation, navMeshRotation, Time.deltaTime * rotationSpeed);
            rb.MoveRotation(slowRotation);

            if (playerDistance > minPlayerDistance)
            {
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed);
            }
        }

        private void Update()
        {
            if (dealedDamage)
            {
                damageTimer -= Time.deltaTime;
                if (damageTimer <= 0)
                {
                    dealedDamage = false;
                    damageTimer = 1f;
                }
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag(GameTag.PLAYER))
            {
                PlayerInfo playerInfo = collision.gameObject.GetComponent<PlayerInfo>();
                if (!dealedDamage)
                {
                    playerInfo.ReceiveDamage(10);
                    
                    dealedDamage = true;
                }
            }
        }
    }
}

