using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
  public float zoomSpeed = 2f;             
  public float inwardRange = 2f;           
  public float outwardRange = 4f;          
  public float smoothTime = 0.08f;         
  private float zVelocity;                 

  private float baseZ;                    
  private float targetZ;                   

  void Awake()
  {

    baseZ = transform.localPosition.z;
    targetZ = baseZ;
  }

  void Update()
  {
    HandleZoom();
    SmoothApply();
  }

  void HandleZoom()
  {
    float scroll = Input.GetAxis("Mouse ScrollWheel");
    if (Mathf.Approximately(scroll, 0f)) return;

    float delta = scroll * zoomSpeed;
    float minZ = baseZ - outwardRange;  // farther
    float maxZ = baseZ + inwardRange;   // closer
    targetZ = Mathf.Clamp(targetZ + delta, minZ, maxZ);
  }

  void SmoothApply()
  {
    Vector3 lp = transform.localPosition;
    float newZ = Mathf.SmoothDamp(lp.z, targetZ, ref zVelocity, smoothTime);
    transform.localPosition = new Vector3(lp.x, lp.y, newZ);
  }
}
