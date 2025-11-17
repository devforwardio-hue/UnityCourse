using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoving : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float gravity = 9.81f;
    public float jumpForce = 10f;

    private CharacterController controller;
    private Vector3 velocity;

    private Vector2 input;
    private bool jumpRequested;

    void Awake()
    {
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

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX);

    }

    private void ApplyMovement()
    {
        float dt = Time.fixedDeltaTime;
        Vector3 horizontal = new Vector3(input.x, 0f, input.y) * moveSpeed;

        if (controller.isGrounded)
        {
            if (velocity.y < 0f) velocity.y = -2f; // keep grounded
            if (jumpRequested)
            {
                velocity.y = jumpForce;
            }
        }

        jumpRequested = false;
        velocity.y += -gravity * dt;
        Vector3 motion = new Vector3(horizontal.x, velocity.y, horizontal.z) * dt;
        controller.Move(motion);
    }
}
