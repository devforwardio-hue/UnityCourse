using UnityEngine;

public class TPCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 4f;
    public float height = 2f;
    public float rotationSpeed = 3f;
    public float smoothSpeed = 10f;
    public float minYAngle = -30f;
    public float maxYAngle = 60f;

    private float currentX = 0f;
    private float currentY = 0f;
    void LateUpdate()
    {
        if (!target)
            return;
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPostion = target.position - (rotation * Vector3.forward * distance) + (Vector3.up * height);
        transform.position = Vector3.Lerp(transform.position, desiredPostion, Time.deltaTime * smoothSpeed);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
