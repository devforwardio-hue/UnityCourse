using UnityEngine;

public class CameraVerticalPivot : MonoBehaviour
{
    public float rotateSensitivityY = 120f;
    public float minYAngle = -30f;
    public float maxYAngle = 60f;

    private float pitch = 0f;

    void LateUpdate()
    {
        bool rmb = Input.GetMouseButton(1);
        if (!rmb) return;

        float mouseY = Input.GetAxis("Mouse Y");

        // Increment pitch
        pitch -= mouseY * rotateSensitivityY * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minYAngle, maxYAngle);

        // Apply vertical rotation only
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
