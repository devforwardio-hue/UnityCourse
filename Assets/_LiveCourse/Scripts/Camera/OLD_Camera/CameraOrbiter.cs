using UnityEngine;

public class CameraOrbiter : MonoBehaviour
{
    [Tooltip("The target the camera orbits (player)")]
    public Transform target;

    [Header("Sensitivity")]
    public float sensitivityX = 180f;
    public float sensitivityY = 180f;

    [Header("Pitch Limits")]
    public float minPitch = -40f;
    public float maxPitch = 70f;

    [Header("Orbit Settings")]
    [Tooltip("Starting orbit distance (computed from current position if 0)")]
    public float distance = 6f;

    private float yaw;
    private float pitch;

    void Start()
    {
        if (target != null)
        {
            Vector3 dir = transform.position - target.position;
            distance = dir.magnitude;

            // compute initial yaw/pitch so current camera position is preserved
            Vector3 normalized = dir.normalized;
            pitch = Mathf.Asin(normalized.y) * Mathf.Rad2Deg * -1f; // approximate pitch
            yaw = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            // fallback if weird values:
            // yaw = transform.eulerAngles.y; pitch = transform.eulerAngles.x;
        }
    }

    void LateUpdate()
    {
        FullOrbit();
    }

    void FullOrbit()
    {
        if (target == null) return;

        bool rmb = Input.GetMouseButton(1);

        Cursor.lockState = rmb ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !rmb;

        if (rmb)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            yaw += mouseX * sensitivityX * Time.deltaTime;
            pitch -= mouseY * sensitivityY * Time.deltaTime;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        }

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 offset = rotation * new Vector3(0f, 0f, -distance);

        transform.position = target.position + offset;
        transform.rotation = rotation;
    }
}
