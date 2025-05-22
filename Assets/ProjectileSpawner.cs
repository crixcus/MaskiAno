using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate bullet at the player's position with default rotation
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
