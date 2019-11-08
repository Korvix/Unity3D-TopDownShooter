using UnityEngine;
using System.Collections;
using System;

namespace TopDownShooter.Gameplay
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField]
        private float hp = 100f;

        public void ReceiveDamage(float damage)
        {
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
                KilledAction();
            }
        }

        private void KilledAction()
        {
            Debug.Log("Killed");
        }

        public float GetHP()
        {
            return hp;
        }
    }
}

