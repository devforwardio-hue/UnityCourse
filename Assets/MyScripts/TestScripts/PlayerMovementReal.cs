using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementReal : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float defaultSpeed = 10f;

    private Rigidbody rb;
    private Vector3 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = defaultSpeed;

        rb.freezeRotation = true; // prevent tipping over
    }

    void Update()
    {
        HandleRawMovement();
    }

    private void FixedUpdate()
    {
        // Use physics movement
        if (moveDir.sqrMagnitude > 0.01f)
        {
            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.fixedDeltaTime));
        }
    }

    private void HandleRawMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            Transform cam = Camera.main.transform;

            Vector3 camForward = cam.forward;
            camForward.y = 0f;
            camForward.Normalize();

            Vector3 camRight = cam.right;
            camRight.y = 0f;
            camRight.Normalize();

            moveDir = 
                camForward * inputDirection.z +
                camRight * inputDirection.x;

            moveDir.Normalize();
        }
        else
        {
            moveDir = Vector3.zero;
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
