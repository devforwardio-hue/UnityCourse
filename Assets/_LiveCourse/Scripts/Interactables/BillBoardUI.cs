using UnityEngine;

public class BillboardUI : MonoBehaviour
{
  public GameObject camObj;
  public Camera mCamera;
  public Canvas canvas;

  void Awake()
  {
    canvas = GetComponent<Canvas>();
    camObj = GameObject.Find("MainCamera");
    mCamera = camObj.GetComponent<Camera>();
    if (canvas != null && mCamera != null)
    {
      canvas.worldCamera = mCamera;
    }
  }

  void LateUpdate()
  {
    if (mCamera == null) return;
    transform.rotation = Quaternion.LookRotation(
        transform.position - mCamera.transform.position,
        Vector3.up
    );
  }
}
