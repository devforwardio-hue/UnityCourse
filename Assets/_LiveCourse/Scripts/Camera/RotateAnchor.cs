using UnityEngine;

public class RotateAnchor : MonoBehaviour
{
  public float yawSpeed = 180f;
  public float pitchSpeed = 140f;
  public float minPitch = -35f;
  public float maxPitch = 70f;
  


  void Update()
  {
    HandleRotations();      
  }

  void HandleRotations() 
  { 
    bool rmb = Input.GetMouseButton(1);

    Cursor.lockState = rmb ? CursorLockMode.Locked : CursorLockMode.None;


    //if (rmb)
    //{
    //  //HIDE our cursor, and LOCK the cursor from the screen.
    //  Cursor.visible = false;
    //  Cursor.lockState = CursorLockMode.Locked;
    //}else
    //{
    //  Cursor.visible = true;
    //  Cursor.lockState = CursorLockMode.None;
    //}
  }
}
