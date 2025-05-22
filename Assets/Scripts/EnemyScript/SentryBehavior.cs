using UnityEngine;

public class SentryBehavior : MonoBehaviour
{
    public Transform target;                 // The player or target to chase
    public EnemyShoot shooting;             // Reference to EnemyShoot

    public float speed = 5f;                // Movement speed
    public bool isChasing = false;          // Is the sentry currently chasing?

    public bool IsPlayerDetected => isChasing; // Public property for detection status

    void Start()
    {
        if (shooting == null)
        {
            shooting = GetComponent<EnemyShoot>();
        }
    }

    void Update()
    {
        if (isChasing && target != null)
        {
            // Move toward the target
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Rotate to face target (ignoring Y axis to prevent tilting)
            Vector3 lookDirection = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(lookDirection);
        }
    }

    // Call this to begin chasing
    public void Chase()
    {
        isChasing = true;
    }

    // Call this to stop chasing
    public void StopChase()
    {
        isChasing = false;
    }
}
