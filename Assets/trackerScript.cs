using UnityEngine;

public class trackerScript : MonoBehaviour
{
    [Header("Read-Only Child Count (Runtime Only)")]
    [SerializeField] private int currentChildCount;

    void Update()
    {
        // Update the child count every frame
        currentChildCount = transform.childCount;

        // If no more children, destroy this GameObject
        if (currentChildCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
