using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float gravity = 9.81f;
    public float jumpForce = 10f;
    public float defaultSpeed = 10f;

    public Transform movementReference;

    public CharacterController controller;
    private Vector3 jumpVelocity;

    private Vector2 input;
    private bool jumpRequested;

    void Awake()
    {
        moveSpeed = defaultSpeed;
        //controller = GetComponent<CharacterController>();
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
            jumpRequested = true;
        }
    }

    private void ApplyMovement()
    {
        Transform refT = movementReference != null ? movementReference : transform;
        Vector3 refForward = Vector3.ProjectOnPlane(refT.forward, Vector3.up).normalized;
        Vector3 refRight = Vector3.ProjectOnPlane(refT.right, Vector3.up).normalized;
        Vector3 moveDir = refRight * input.x + refForward * input.y;
        if (moveDir.sqrMagnitude > 1f) moveDir.Normalize();
        moveDir *= moveSpeed;

        if (controller.isGrounded)
        {
            if (jumpVelocity.y < 0f) jumpVelocity.y = -2f;
            if (jumpRequested)
            {
                jumpVelocity.y = jumpForce;
            }
        }

        jumpRequested = false;
        jumpVelocity.y += -gravity * Time.fixedDeltaTime;

        Vector3 motion = new Vector3(moveDir.x, jumpVelocity.y, moveDir.z) * Time.fixedDeltaTime;
        controller.Move(motion);
    }
}
