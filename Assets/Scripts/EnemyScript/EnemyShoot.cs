using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireDelay = 1.5f;
    public float projectileSpeed = 20f;
    public string targetTag = "Player";

    public SentryBehavior isChasing; // Reference to SentryBehavior

    private Transform player;
    private Coroutine shootingCoroutine;

    void Update()
    {
        if (isChasing != null && isChasing.IsPlayerDetected)
        {
            if (shootingCoroutine == null)
            {
                GameObject playerObj = GameObject.FindGameObjectWithTag(targetTag);
                if (playerObj != null)
                {
                    player = playerObj.transform;
                    StartShooting();
                }
            }
        }
        else
        {
            StopShooting();
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
        shootingCoroutine = StartCoroutine(ShootAtPlayer());
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
