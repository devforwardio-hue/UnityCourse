using System;
using UnityEngine;

public class _RotateAnchor : MonoBehaviour
{
  //The goal is to hold down the right mouse button, to activate camera rotation, by rotating the anchor object and view around the player.
  //we know that cinemachine, will orbit the anchor, so we DONT need to mess with the camera itself, we only need to control the anchor. 

  //What do we need ?

  public float yawSpeed = 180f;
  public float pitchSpeed = 140f;
  public float minPitch = -35f;
  public float maxPitch = 70F;

  public bool invertY = false;
  public bool requireRightClick = false;//not using this out the gate. 

  public Vector3 defaultCameraPos;
  public Quaternion defaultCameraRot;

    void Awake()
    {
        defaultCameraPos = transform.position;
        defaultCameraRot = transform.rotation;// ?
    }

    // Update is called once per frame
    void Update()
    {
      HandleRotation();
    }

    void HandleRotation()
    {
      bool rmb = Input.GetMouseButton(1);
      Cursor.lockState = rmb ? CursorLockMode.Locked : CursorLockMode.None;
      Cursor.visible = !rmb;

      if (!rmb) return;
      //cant happen unless we click right.
      float mouseX = Input.GetAxis("Mouse X");
      float mouseY = Input.GetAxis("Mouse Y");

    Debug.Log("Mouse X" + mouseX);
    Debug.Log("Mouse Y" + mouseY);
    if(Mathf.Approximately(mouseX, 0f) && Mathf.Approximately (mouseY, 0f)) return;

    if (!Mathf.Approximately(mouseX, 0f))
    {
      float deltaYaw = mouseX * yawSpeed * Time.deltaTime;
      transform.Rotate(0f, deltaYaw, 0f, Space.World);
    }

    if (!Mathf.Approximately(mouseY, 0f))
    {
      float deltaPitch = mouseY * yawSpeed * Time.deltaTime;
      Vector3 euler = transform.localEulerAngles;
      float eulerX = euler.x;
      if (eulerX > 180f) eulerX -= 360F;
      eulerX = Mathf.Clamp(eulerX + deltaPitch, minPitch, maxPitch);

      transform.localRotation = Quaternion.Euler(eulerX, transform.localEulerAngles.y, 0f);//
    }



  }
}
