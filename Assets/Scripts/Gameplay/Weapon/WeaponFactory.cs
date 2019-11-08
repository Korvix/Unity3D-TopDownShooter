using UnityEngine;

namespace TopDownShooter.Gameplay.Weapon
{
    public class WeaponFactory
    {
        private GameObject bulletGameObject;
        private Bullet bullet;

        public Bullet CreateBullet(BulletInfo bulletInfo)
        {
            bulletGameObject = GameObject.Instantiate(bulletInfo.prefab);
            switch (bulletInfo.bulletType)
            {
                case BulletType.DEFAULT:
                    {
                        bulletGameObject.AddComponent<DefaultBullet>();
                        break;
                    }
                case BulletType.GRENADE:
                    {
                        bulletGameObject.AddComponent<Grenade>();
                        break;
                    }
            }
            bullet = bulletGameObject.GetComponent<Bullet>();
            bullet.SetBulletInfo(bulletInfo);
            return bullet;
        }
    }
}

