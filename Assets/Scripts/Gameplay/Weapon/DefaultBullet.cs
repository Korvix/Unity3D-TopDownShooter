using System.Collections;
using System.Collections.Generic;
using TopDownShooter.GameSystem;
using UnityEngine;

namespace TopDownShooter.Gameplay.Weapon
{
    public class DefaultBullet : Bullet
    {
        private Rigidbody rb;

        private new void Awake()
        {
            base.Awake();
            rb = gameObject.GetComponent<Rigidbody>();
        }

        public override void Shoot(Vector3 direction)
        {
            gameObject.SetActive(true);
            rb.velocity = direction * 10f;
            StartCoroutine(HideAfterSecond(2f));
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(GameTag.ZOMBIE_SLOW))
            {
                StoreInObjectPool();
            }
        }

        public override void StoreInObjectPool()
        {
            objectPool.StoreBullet(this);
            gameObject.SetActive(false);
        }
    }
}

