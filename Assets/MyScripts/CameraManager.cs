using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Follow Settings")]
    public Transform target;                     // Player anchor
    public Vector3 offset = new Vector3(0f, 2f, 0f); // Offset relative to anchor
    public float followSmoothTime = 0.1f;

    private Vector3 velocity;

    void LateUpdate()
    {
        if (target == null) return;

        // Smoothly follow the target's position with offset
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSmoothTime);
    }
}
