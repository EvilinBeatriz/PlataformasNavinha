using UnityEngine;

public class Armas : MonoBehaviour
{
    [Header("Configurações de Disparo")]
    public GameObject bulletPrefab;
    public GameObject[] weaponPrefabs;
    public Transform firePoint;
    public float fireRate = 5f;
    public Foguete foguete;
    private int currentWeaponIndex = 0;
    private float nextFireTime = 0f;
    public GameObject fogueteobj;
    void Start()
    {
        if (weaponPrefabs.Length == 0)
        {
            Debug.LogError("O Arsenal está vazio. Adicione os prefabs de tiro.");
            enabled = false;
        }
        if (firePoint == null)
        {
            Debug.LogError("Fire Point não configurado.");
        }

        Debug.Log($"Arma inicial: {currentWeaponIndex}");
    }
    public void Shoot()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            // Pega o prefab ativo da lista
            GameObject activePrefab = weaponPrefabs[currentWeaponIndex];

            // Instancia o projétil
            GameObject projectile = Instantiate(activePrefab, firePoint.position, firePoint.rotation);

            // Se for o foguete, precisamos atribuir o alvo
            if (currentWeaponIndex == 1) // Assumindo que o Foguete é o índice 1
            {
                foguete = projectile.GetComponent<Foguete>();
                if (foguete != null)
                {
                    // Tenta encontrar o alvo (função auxiliar precisa existir)
                    Transform target = FindNearestEnemy();
                    foguete.target = target;
                    if (target == null) Debug.Log("Foguete disparado sem alvo!");
                }
            }

        }
    }
    private Transform FindNearestEnemy()
    {
        // Lógica simplificada de busca de alvo
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            return enemies[0].transform;
        }
        return null;
    }

    public void ChangeWeaponType()
    {
        Debug.Log("Arma trocada.");
    }
    public void UseSpecialAbility()
    {
        Debug.Log("Habilidade especial ativada.");
    }
    public void FireHomingMissile(Transform targetToLock)
    {
        GameObject missileGO = Instantiate(fogueteobj, firePoint.position, firePoint.rotation);
        foguete = missileGO.GetComponent<Foguete>();
        if (foguete != null)
        {
            foguete.target = targetToLock;
        }
    }
}
