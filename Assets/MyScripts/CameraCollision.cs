using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraCollision : MonoBehaviour
{
    [Tooltip("The transform the camera is targeting (usually player)")]
    public Transform target;

    [Tooltip("How quickly to move the camera when collision occurs")]
    public float smoothSpeed = 10f;

    [Tooltip("Small offset so the camera doesn't sit exactly on the hit point")]
    public float collisionOffset = 0.2f;

    [Tooltip("Layers to consider as obstacles (default to everything)")]
    public LayerMask collisionMask = ~0;

    private Vector3 desiredLocalPosition;
    private Vector3 currentLocalPosition;

    void Start()
    {
        currentLocalPosition = transform.localPosition;
        desiredLocalPosition = currentLocalPosition;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Desired world position = orbit position (parent) + local position (includes zoom)
        Vector3 parentPos = transform.parent.position; // orbit transform world position
        Vector3 desiredWorldPos = transform.parent.TransformPoint(transform.localPosition);

        Vector3 dir = desiredWorldPos - target.position;
        float distance = dir.magnitude;
        Vector3 dirNorm = dir.normalized;

        // Raycast from target towards desired camera position
        if (Physics.SphereCast(target.position, 0.2f, dirNorm, out RaycastHit hit, distance, collisionMask, QueryTriggerInteraction.Ignore))
        {
            // place camera slightly in front of hit point
            Vector3 hitPos = hit.point + hit.normal * collisionOffset;
            Vector3 localHit = transform.parent.InverseTransformPoint(hitPos);
            desiredLocalPosition = localHit;
        }
        else
        {
            // no obstruction
            desiredLocalPosition = transform.localPosition;
        }

        // Smoothly move camera local position to desired
        currentLocalPosition = Vector3.Lerp(currentLocalPosition, desiredLocalPosition, Mathf.Clamp01(Time.deltaTime * smoothSpeed));
        transform.localPosition = currentLocalPosition;
    }
}
