using UnityEngine;
using System.Collections;
using TopDownShooter.GameSystem;

namespace TopDownShooter.Gameplay.Weapon
{
    public class WeaponHandler
    {
        private BulletInfo[] bulletsInfo;
        private static readonly string BULLET_INFO_FOLDER = "BulletsInfo";
        private int actualWeaponIndex;
        private ObjectPool objectPool;


        public WeaponHandler()
        {
            objectPool = GameContext.Instance.ObjectPool;
            bulletsInfo = Resources.LoadAll<BulletInfo>(BULLET_INFO_FOLDER);
        }

        public void NextWeapon()
        {
            if (++actualWeaponIndex >= bulletsInfo.Length)
            {
                actualWeaponIndex = 0;
            }
        }

        public Bullet GetBullet()
        {
            return objectPool.GetBullet(bulletsInfo[actualWeaponIndex]);
        }
    }
}

