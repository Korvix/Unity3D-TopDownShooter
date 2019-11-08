using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TopDownShooter.GameSystem;

namespace TopDownShooter.Gameplay
{
    public class ZombieSlowController : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        private Transform playerTransform;

        [SerializeField]
        private Transform rigibodyTransform;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            playerTransform = GameContext.Instance.Player.transform;
        }

        private void FixedUpdate()
        {
            navMeshAgent.SetDestination(playerTransform.position);
            transform.position = new Vector3(rigibodyTransform.position.x, rigibodyTransform.position.y + 1.741f, rigibodyTransform.position.z);
        }
    }
}

