using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float movementSpeed = 10f;
    private Vector3 moveDirection;

    void Start()
    {
        // Get mouse position in world space using raycast
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);

            // Calculate direction on XZ plane
            moveDirection = (targetPoint - transform.position).normalized;

            // Rotate projectile to face the target direction
            Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = lookRotation;
        }

        // Destroy the projectile after 3 seconds
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // Move the projectile forward
        transform.position += moveDirection * movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            // Destroy the enemy
            Debug.Log("nagtatama");
            Destroy(collision.collider.gameObject);

            // Destroy the bullet
            Destroy(gameObject);

            // Add score
            GameManager.Instance.UpdateScore(10);
        }
    }


}
