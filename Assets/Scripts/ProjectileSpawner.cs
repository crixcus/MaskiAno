using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float delayedBulletTime = 0.1f;   // Delay between each extra bullet
    public float fireCooldown = 0.5f;        // Delay between shots

    private bool canShoot = true;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(FireRoutine());
        }
    }

    IEnumerator FireRoutine()
    {
        canShoot = false;

        // Play firing sound
        audioManager.Instance.PlaySFX("laser");

        // Calculate how many bullets to fire (1 base + 1 per 100 points)
        int score = GameManager.Instance.GetScore();
        int bulletCount = 1 + (score / 100); // 0-99 = 1, 100-199 = 2, etc.

        for (int i = 0; i < bulletCount; i++)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);

            // Add delay only between bullets, not after the last one
            if (i < bulletCount - 1)
                yield return new WaitForSeconds(delayedBulletTime);
        }

        // Wait for cooldown before next shot
        yield return new WaitForSeconds(fireCooldown);
        canShoot = true;
    }
}
