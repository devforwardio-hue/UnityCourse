using UnityEngine;

public class SampleCameraOrbiter : MonoBehaviour
{
    public Transform target;
    public float rotationSensitivity = 180f;
    public Vector3 defaultPos;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        OrbitObject();
    }
    void OrbitObject()
    {
        bool rmb = Input.GetMouseButton(1);
        
        if (target == null) return;
        
        //create orbit
        //Lock and hide cursor
        Cursor.visible = !rmb;
        Cursor.lockState = rmb? CursorLockMode.Locked : CursorLockMode.None;
        if (!rmb) return;
        //can't go if returned false
        float mouseX = Input.GetAxis("Mouse X");
        //yaw used for angle 
        float yaw = mouseX * rotationSensitivity * Time.fixedDeltaTime;
        if (Mathf.Abs(yaw) <= 0f) return;

        transform.RotateAround(target.position, Vector3.up, yaw);
        transform.LookAt(target.position, Vector3.up);
    }

}
