using UnityEngine;

public class CameraOrbiting : MonoBehaviour
{

  public Transform target;
  public float rotateSensitivityX = 180f;
  public Vector3 defaultPos;

  void Awake()
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
    Cursor.lockState = rmb ? CursorLockMode.Locked : CursorLockMode.None;
    Cursor.visible = !rmb;
    if (!rmb) return;
    //cant go beyond, if rmb is false.

    float mouseX = Input.GetAxis("Mouse X");
    //figure out, the math, of the camera looking at the object for any angle, to then begin rotating around - so the yaw needs to be known according to our orbiting direction.
    float expectedYaw = mouseX * rotateSensitivityX * Time.fixedDeltaTime;
    if (Mathf.Abs(expectedYaw) <= 0f) return;

    transform.RotateAround(target.position, Vector3.up, expectedYaw);
    transform.LookAt(target.position, Vector3.up);
  }
}
