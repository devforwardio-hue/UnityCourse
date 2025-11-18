using UnityEngine;

public class PlayerMovementReal : MonoBehaviour
{
  public float moveSpeed = 10f;
  public float defaultSpeed = 10f;

  void Start()
    {
      moveSpeed = defaultSpeed;
    }

    void Update()
    {

      HandleRawMovement();
    }
private void HandleRawMovement()
{
    // STEP 1 — Get keyboard input (horizontal = A/D, vertical = W/S)
    float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Vertical");

    // STEP 2 — Combine the inputs into a single direction vector
    Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

    if (inputDirection.magnitude >= 0.1f)
    {
        // STEP 3 — Get the direction the camera is facing
        Transform cam = Camera.main.transform;

        // STEP 4 — Convert input direction from WORLD space into CAMERA space
        Vector3 moveDir =
            cam.forward * inputDirection.z +
            cam.right * inputDirection.x;

        moveDir.y = 0f; // keep movement flat
        moveDir.Normalize();

        // STEP 5 — Move the player
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        // STEP 6 — Rotate player to face the direction they are moving
        Quaternion targetRotation = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            10f * Time.deltaTime
        );
    }
}


  #region OldMovementCode
  //if a condition is met,
  //Do this things.
  //else, do this other thing. 

  //Vector3(x, y, z)

  //if (Input.GetKey(KeyCode.D))
  //{
  //  Vector3 movementRight = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
  //  transform.Translate(movementRight);
  //}

  // if (Input.GetKey(KeyCode.A)) 
  //{ 
  //   Vector3 movementLeft = new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
  //   transform.Translate(movementLeft);
  //}

  //if (Input.GetKey(KeyCode.W))
  //{
  //  Vector3 movementLeft = new Vector3(0f, 0f, moveSpeed * Time.deltaTime);
  //  transform.Translate(movementLeft);
  //}

  //if (Input.GetKey(KeyCode.S))
  //{
  //  Vector3 movementLeft = new Vector3(0f, 0f, -moveSpeed * Time.deltaTime);
  //  transform.Translate(movementLeft);
  //}
  #endregion

}
