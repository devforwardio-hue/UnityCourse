using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float gravity = 9.81f;
    public float jumpForce = 10f;
    public float defaultSpeed = 10f;

  private CharacterController controller;
    private Vector3 jumpVelocity; 

    private Vector2 input;
    private bool jumpRequested;

    void Awake()
    {
      moveSpeed = defaultSpeed;
      controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ReadInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector2 raw = new(x, z);
        input = raw.sqrMagnitude > 1f ? raw.normalized : raw;

        if (Input.GetButtonDown("Jump"))
        {
            jumpRequested = true; // capture edge in Update so it isn't missed
        }
    }

    private void ApplyMovement()
    {
        Vector3 movementData = new Vector3(input.x, 0f, input.y) * moveSpeed;

        if (controller.isGrounded)
        {
            if (jumpVelocity.y < 0f) jumpVelocity.y = -2f; // keep grounded ?? 
            if (jumpRequested)
            {
                jumpVelocity.y = jumpForce;
            }
        }

        jumpRequested = false;
        jumpVelocity.y += -gravity * Time.fixedDeltaTime;
        Vector3 motion = new Vector3(movementData.x, jumpVelocity.y, movementData.z) * Time.fixedDeltaTime;
        controller.Move(motion);
    }
}
