using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform target;         // Assign your player transform here in the Inspector
    public Vector3 offset = new Vector3(0f, 10f, -10f);  // Offset from the player
    public float smoothSpeed = 5f;   // Smooth follow speed

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Optional: keep the camera always looking at the player
        transform.LookAt(target);
    }
}
