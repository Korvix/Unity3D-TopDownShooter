using System.Collections;
using TopDownShooter.Gameplay;
using TopDownShooter.Gameplay.Weapon;
using TopDownShooter.GameSystem;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float coolDownTimeInSeconds;
    [SerializeField]
    private float bulletLifeTimeInSeconds;
    private InputData inputData;
    private bool isShootingEnabled;

    [SerializeField]
    private float explosionRadius;
    [SerializeField]
    private float explosionPower;


    private WeaponHandler weaponHandler;
    private Bullet bullet;

    private void Awake()
    {
        inputData = GameContext.Instance.InputData;
        isShootingEnabled = true;
        weaponHandler = new WeaponHandler();
    }

    private void FixedUpdate()
    {
        if ((inputData.space || inputData.triggerRight > 0f) && isShootingEnabled)
        {
            bullet = weaponHandler.GetBullet();
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.Shoot(transform.forward);

            isShootingEnabled = false;
            StartCoroutine(ActivateShootingWithDelay(coolDownTimeInSeconds));
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            weaponHandler.NextWeapon();
        }

        if (inputData.yButtonDown)
        {
            weaponHandler.NextWeapon();
        }
    }

    private void MakeExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(GameTag.ZOMBIE_SLOW))
            {
                Vector3 heading = transform.position - collider.transform.position;
                float distance = heading.magnitude;
                Vector3 direction = heading / distance;
                Debug.DrawLine(transform.position, collider.transform.position, Color.red, 5);
                collider.GetComponent<Rigidbody>().AddForce((Vector3.up * explosionPower) / (distance / 2));
                collider.GetComponent<Rigidbody>().AddForce((-direction * explosionPower) / 4);
            }
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, explosionRadius);
    //}

    private IEnumerator ActivateShootingWithDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        isShootingEnabled = true;
    }
}
