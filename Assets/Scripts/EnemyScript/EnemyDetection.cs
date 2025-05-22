using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public enum Shape { Sphere, Cube }
    public Shape detectionShape = Shape.Sphere;
    public float radius = 3f;
    public Vector3 boxSize = new Vector3(3f, 3f, 3f);
    public string targetTag = "Player";

    private bool playerDetected = false;
    public SentryBehavior willChase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            playerDetected = true;
            willChase.Chase();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            playerDetected = false;
            willChase.StopChase();
            
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = playerDetected ? Color.red : Color.green;

        if (detectionShape == Shape.Sphere)
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
        else if (detectionShape == Shape.Cube)
        {
            Gizmos.DrawWireCube(transform.position, boxSize);
        }
    }

    private void OnValidate()
    {
        SetupCollider();
    }

    void SetupCollider()
    {
        Collider currentCollider = GetComponent<Collider>();

        if (detectionShape == Shape.Sphere)
        {
            // Check if current collider is SphereCollider
            SphereCollider sc = currentCollider as SphereCollider;
            if (sc == null)
            {
                if (currentCollider != null) DestroyImmediate(currentCollider);
                sc = gameObject.AddComponent<SphereCollider>();
            }
            sc.isTrigger = true;
            sc.radius = radius;
        }
        else if (detectionShape == Shape.Cube)
        {
            // Check if current collider is BoxCollider
            BoxCollider bc = currentCollider as BoxCollider;
            if (bc == null)
            {
                if (currentCollider != null) DestroyImmediate(currentCollider);
                bc = gameObject.AddComponent<BoxCollider>();
            }
            bc.isTrigger = true;
            bc.size = boxSize;
        }
    }

}
