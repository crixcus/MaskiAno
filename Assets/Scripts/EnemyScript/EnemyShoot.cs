using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform firePoint;         
    public float fireDelay = 1.5f;      
    public float projectileSpeed = 20f; 
    public string targetTag = "Player"; 

    private Transform player;
    public GameObject playerObj;
    public SentryBehavior isChasing;
    private Coroutine shootingCoroutine;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag(targetTag);
        
    }

    public void ShootCommence()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag(targetTag);
        if (playerObj != null)
        {
            player = playerObj.transform;
            StartShooting();
        }
        else
        {
            Debug.LogWarning("Player not found. Make sure the player has the correct tag.");
        }
    }

    IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            if (player != null)
            {
                GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

                Vector3 direction = (player.position - firePoint.position).normalized;

                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = direction * projectileSpeed;
                }

                Destroy(bullet, 5f);
            }

            yield return new WaitForSeconds(fireDelay);
        }
    }
    public void StartShooting()
    {
        if (shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ShootAtPlayer());
        }
    }

    public void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }
}
