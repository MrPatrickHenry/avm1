using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform target;  // Assign your player here
    public Vector2 offset = new Vector2(2f, 1f);  // Adjust for a better view
    public float smoothSpeed = 0.1f;  // Lower = smoother movement

    private void LateUpdate()
    {
        if (target == null) return;

        // Ensure camera does not rotate (keep rotation fixed)
        transform.rotation = Quaternion.identity;

        // Calculate new position (Lock Z position)
        Vector3 targetPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

        // Smoothly transition to the new position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
