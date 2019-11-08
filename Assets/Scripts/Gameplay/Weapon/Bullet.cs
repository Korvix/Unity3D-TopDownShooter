using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using TopDownShooter.GameSystem;

namespace TopDownShooter.Gameplay.Weapon
{
    public abstract class Bullet : MonoBehaviour
    {
        private BulletType bulletType;
        private float speed;
        private bool explosive;
        private float damage;
        private float lifeDuration;
        private float weight;
        private GameObject prefab;

        protected ObjectPool objectPool;

        protected void Awake()
        {
            objectPool = GameContext.Instance.ObjectPool;
        }

        public BulletType BulletType { get => bulletType; }

        public abstract void Shoot(Vector3 direction);
        public abstract void StoreInObjectPool();

        public void SetBulletInfo(BulletInfo bulletInfo)
        {
            bulletType = bulletInfo.bulletType;
            speed = bulletInfo.speed;
            explosive = bulletInfo.explosive;
            damage = bulletInfo.damage;
            lifeDuration = bulletInfo.lifeDuration;
            weight = bulletInfo.weight;
            prefab = bulletInfo.prefab;
        }

        protected IEnumerator HideAfterSecond(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            StoreInObjectPool();
        }
    }
}

