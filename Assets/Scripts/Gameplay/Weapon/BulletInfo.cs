using UnityEngine;
using System.Collections;

namespace TopDownShooter.Gameplay.Weapon
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Weapons/Bullet", order = 1)]
    public class BulletInfo : ScriptableObject
    {
        public BulletType bulletType;
        public float speed;
        public bool explosive;
        public float damage;
        public float lifeDuration;
        public float weight;
        public GameObject prefab;
    }
}