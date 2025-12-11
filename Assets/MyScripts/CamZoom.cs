using UnityEngine;

public class CamZoom : MonoBehaviour
{
    [Header("Zoom Settings")]
    public float minZoom = 2f;
    public float maxZoom = 6f;
    public float zoomSpeed = 5f;
    public float smoothTime = 0.08f;

    private float targetZ;
    private float zVelocity;
    private float defaultZ;

    void Start()
    {
        defaultZ = transform.localPosition.z;
        targetZ = defaultZ;
    }

    void LateUpdate()
    {
        HandleZoom();
        ApplyZoom();
    }

    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Approximately(scroll, 0f)) return;

        targetZ += -scroll * zoomSpeed;
        targetZ = Mathf.Clamp(targetZ, defaultZ - maxZoom, defaultZ - minZoom);
    }

    private void ApplyZoom()
    {
        Vector3 localPos = transform.localPosition;
        float newZ = Mathf.SmoothDamp(localPos.z, targetZ, ref zVelocity, smoothTime);
        transform.localPosition = new Vector3(localPos.x, localPos.y, newZ);
    }
}
