using UnityEngine;

public class CameraOrbitTest : MonoBehaviour
{
    public Transform target;
    public float rotateSensitivityX = 180f;
    public float rotateSensitivityY = 120f;
    public float minYAngle = -30f; // How far below the anchor you can look
    public float maxYAngle = 60f;  // How far above the anchor you can look

    private float yaw;
    private float pitch;

    void FixedUpdate()
    {
        OrbitObject();
    }

    void OrbitObject()
    {
        if (target == null) return;

        bool rmb = Input.GetMouseButton(1);
        Cursor.lockState = rmb ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !rmb;
        if (!rmb) return;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Horizontal rotation
        yaw += mouseX * rotateSensitivityX * Time.fixedDeltaTime;
        // Vertical rotation (added)
        pitch -= mouseY * rotateSensitivityY * Time.fixedDeltaTime;
        pitch = Mathf.Clamp(pitch, minYAngle, maxYAngle);

        transform.position = target.position;
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
