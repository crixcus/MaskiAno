using UnityEngine;
using UnityEngine.EventSystems;

public class buttonScript : MonoBehaviour
{
    [Header("Scale Settings")]
    public Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1.2f); // Editable per axis
    public float scaleSpeed = 5f;

    private Vector3 originalScale;
    private Vector3 targetScale;

    private void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }

    // These are used by the EventTrigger component
    public void PointerEnter()
    {
        targetScale = new Vector3(
            originalScale.x * hoverScale.x,
            originalScale.y * hoverScale.y,
            originalScale.z * hoverScale.z
        );
    }

    public void PointerExit()
    {
        targetScale = originalScale;
    }

    public void PointerClick()
    {
        // Optional click logic
        Debug.Log("Object clicked!");
    }
}
