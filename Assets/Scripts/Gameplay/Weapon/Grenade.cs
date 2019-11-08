using UnityEngine;
using System.Collections;
using TopDownShooter.GameSystem;

namespace TopDownShooter.Gameplay.Weapon
{
    public class Grenade : Bullet
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
            rb.velocity += Vector3.up * 6f;
            StartCoroutine(HideAfterSecond(2f));
        }

        public override void StoreInObjectPool()
        {
            objectPool.StoreBullet(this);
            gameObject.SetActive(false);
        }
    }
}

