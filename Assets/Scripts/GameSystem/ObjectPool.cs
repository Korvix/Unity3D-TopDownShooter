using UnityEngine;
using System.Collections.Generic;
using TopDownShooter.Gameplay;
using TopDownShooter.Gameplay.Weapon;

namespace TopDownShooter.GameSystem
{
    public class ObjectPool
    {
        private Dictionary<BulletType, List<Bullet>> bullets;
        private WeaponFactory weaponFactory;
        private Bullet bullet;

        public ObjectPool()
        {
            weaponFactory = new WeaponFactory();
            bullets = new Dictionary<BulletType, List<Bullet>>();
        }

        public Bullet GetBullet(BulletInfo bulletInfo)
        {
            if (bullets.ContainsKey(bulletInfo.bulletType))
            {
                if (bullets[bulletInfo.bulletType].Count <= 0)
                {
                    Debug.Log("Stworzone");
                    bullet = weaponFactory.CreateBullet(bulletInfo);
                }
                else
                {
                    bullet = bullets[bulletInfo.bulletType][0];
                    bullets[bullet.BulletType].RemoveAt(0);
                }
            }
            else
            {
                bullet = weaponFactory.CreateBullet(bulletInfo);
            }
            return bullet;
        }

        public void StoreBullet(Bullet bullet)
        {
            if (!bullets.ContainsKey(bullet.BulletType))
            {
                bullets.Add(bullet.BulletType, new List<Bullet>());
            }
            bullets[bullet.BulletType].Add(bullet);
        }
    }
}

