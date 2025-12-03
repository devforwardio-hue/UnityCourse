using UnityEngine;

public class CameraOrbiter : MonoBehaviour
{
  public Transform target;                
  public float rotateSensitivityX = 180f;  
  public bool lockCursorWhileRotating = true;

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

    float mx = Input.GetAxis("Mouse X");
    float deltaYaw = mx * rotateSensitivityX * Time.fixedDeltaTime;
    if (Mathf.Abs(deltaYaw) <= 0f) return;

    transform.RotateAround(target.position, Vector3.up, deltaYaw);
    transform.LookAt(target.position, Vector3.up);
  }
}
