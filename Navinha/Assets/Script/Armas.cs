using UnityEngine;

public class Armas : MonoBehaviour
{
    public GameObject[] weaponPrefabs;
    public Transform firePoint;
    public float fireRate = 5f;
    public int missileAmmo = 5;
    public int maxMissileAmmo = 10;

    private int currentWeaponIndex = 0;
    private float nextFireTime = 0f;

    void Start()
    {
        if (weaponPrefabs.Length < 2)
        {
            enabled = false;
        }
    }

    public void Shoot()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            if (currentWeaponIndex == 0)
            {
                FireBasicShot();
            }
            else if (currentWeaponIndex == 1)
            {
                FireHomingMissile();
            }
        }
    }

    public void ChangeWeaponType()
    {
        currentWeaponIndex = (currentWeaponIndex + 1) % weaponPrefabs.Length;
    }

    public void CollectMissileAmmo(int amount)
    {
        missileAmmo += amount;
        missileAmmo = Mathf.Min(missileAmmo, maxMissileAmmo);
    }

    public void UseSpecialAbility()
    {

    }

    private void FireBasicShot()
    {
        GameObject basicPrefab = weaponPrefabs[0];
        Instantiate(basicPrefab, firePoint.position, firePoint.rotation);
    }

    public void FireHomingMissile()
    {
        if (missileAmmo <= 0)
        {
            FireBasicShot();
            return;
        }

        Transform target = FindNearestEnemy();

        if (target != null)
        {
            GameObject missilePrefab = weaponPrefabs[1];
            GameObject projectile = Instantiate(missilePrefab, firePoint.position, firePoint.rotation);

            Foguete missile = projectile.GetComponent<Foguete>();
            if (missile != null)
            {
                missile.target = target;
            }

            missileAmmo--;
        }
    }

    private Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            return enemies[0].transform;
        }
        return null;
    }
}