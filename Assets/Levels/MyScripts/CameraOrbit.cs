using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [Header("Orbit Settings")]
    public float rotateSensitivityX = 180f;
    public float rotateSensitivityY = 120f;
    public float minYAngle = -30f;
    public float maxYAngle = 60f;

    private float yaw;
    private float pitch;

    void Start()
    {
        // Initialize yaw/pitch based on current rotation
        Vector3 angles = transform.localEulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void LateUpdate()
    {
        bool rmb = Input.GetMouseButton(1);
        if (!rmb) return;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yaw += mouseX * rotateSensitivityX * Time.deltaTime;
        pitch -= mouseY * rotateSensitivityY * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minYAngle, maxYAngle);

        // Rotate orbit object around local origin
        transform.localRotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
