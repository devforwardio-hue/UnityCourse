using UnityEngine;

public class CameraZooming : MonoBehaviour
{
  public float maxZoom = 4f;
  public float minZoom = 2f;
  public float zoomSpeed = 2f;
  public float smoothTime = 0.08f;

  private float defaultZ;
  private float targetZ;
  private float zVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
      defaultZ = transform.localPosition.z;
      targetZ = defaultZ;
    }

    // Update is called once per frame
    void Update()
    {
      HandleZoom();
      SmoothApply();
    }

    void HandleZoom()
    {
      float scroll = Input.GetAxis("Mouse ScrollWheel");
    if (Mathf.Approximately(scroll, 0f)) return;
    {
      
    }
    Debug.Log(scroll);
      float scrollChange = scroll * zoomSpeed;
      float minZ = defaultZ - minZoom;
      float maxZ = defaultZ + maxZoom;
      targetZ = Mathf.Clamp(targetZ + scrollChange, minZ, maxZ);
    }

    void SmoothApply()
    {
      Vector3 localP = transform.localPosition;
      float newZ = Mathf.SmoothDamp(localP.z, targetZ, ref zVelocity, smoothTime);
      transform.localPosition = new Vector3(localP.x, localP.y, newZ);
    }
    
}
