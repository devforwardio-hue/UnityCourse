using UnityEngine;
public class RotateAnchor : MonoBehaviour
{

    public float yawSpeed = 180f;    
    public float pitchSpeed = 140f;  
    public float minPitch = -35f;    
    public float maxPitch = 70f;     
    public bool invertY = false;

    void Update()
    {
        bool rmb = Input.GetMouseButton(1);
        Cursor.lockState = rmb ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !rmb;
        if (!rmb) return;
        
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        if (Mathf.Approximately(mx, 0f) && Mathf.Approximately(my, 0f)) return;
        if (!Mathf.Approximately(mx, 0f))
        {
            float deltaYaw = mx * yawSpeed * Time.deltaTime;
            transform.Rotate(0f, deltaYaw, 0f, Space.World);
        }

        if (!Mathf.Approximately(my, 0f))
        {
            float yDir = invertY ? 1f : -1f; 
            float deltaPitch = my * pitchSpeed * Time.deltaTime * yDir;

            Vector3 euler = transform.localEulerAngles;
            float x = euler.x;
            if (x > 180f) x -= 360f;
            x = Mathf.Clamp(x + deltaPitch, minPitch, maxPitch);
            transform.localRotation = Quaternion.Euler(x, transform.localEulerAngles.y, 0f);
        }
    }
}
