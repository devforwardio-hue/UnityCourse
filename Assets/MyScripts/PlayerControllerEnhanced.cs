using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerEnhanced : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;              // Normal walking speed
    public float runSpeed = 10f;              // Running speed if needed
    public float acceleration = 10f;          // How fast player speeds up
    public float deceleration = 15f;          // How fast player slows down
    public float gravity = 9.81f;
    public float jumpForce = 5f;
    
    [Header("References")]
    public Transform movementReference;       // Usually the camera or anchor
    private CharacterController controller;

    // Current movement state
    private Vector3 moveVelocity;             // Current velocity vector
    private Vector3 externalVelocity;         // For knockback / push
    private bool jumpRequested = false;

    private float verticalVelocity = 0f;      // Gravity and jumping
    private bool isGrounded = false;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        ReadInput();
        HandleJumpInput();
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    #region Input
    private Vector2 input;

    private void ReadInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector2 raw = new Vector2(x, z);
        input = raw.sqrMagnitude > 1f ? raw.normalized : raw;
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }
    #endregion

    #region Movement
    private void ApplyMovement()
    {
        // Determine reference axes (camera or anchor)
        Transform refT = movementReference != null ? movementReference : transform;
        Vector3 refForward = Vector3.ProjectOnPlane(refT.forward, Vector3.up).normalized;
        Vector3 refRight = Vector3.ProjectOnPlane(refT.right, Vector3.up).normalized;

        // Desired movement direction
        Vector3 targetMove = (refRight * input.x + refForward * input.y).normalized;

        // Smooth acceleration / deceleration
        float targetSpeed = targetMove.magnitude > 0f ? walkSpeed : 0f;
        Vector3 horizontalVelocity = new Vector3(moveVelocity.x, 0f, moveVelocity.z);

        if (targetMove.magnitude > 0f)
        {
            // Accelerate toward target direction
            horizontalVelocity = Vector3.MoveTowards(horizontalVelocity, targetMove * targetSpeed, acceleration * Time.fixedDeltaTime);
        }
        else
        {
            // Decelerate to zero
            horizontalVelocity = Vector3.MoveTowards(horizontalVelocity, Vector3.zero, deceleration * Time.fixedDeltaTime);
        }

        moveVelocity.x = horizontalVelocity.x;
        moveVelocity.z = horizontalVelocity.z;

        #region Gravity & Jump
        isGrounded = controller.isGrounded;

        if (isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f; // Small downward to keep grounded
        }

        if (jumpRequested)
        {
            verticalVelocity = jumpForce;
            jumpRequested = false;
        }

        verticalVelocity -= gravity * Time.fixedDeltaTime;
        moveVelocity.y = verticalVelocity;
        #endregion

        #region Apply External Forces (Knockback / Push)
        if (externalVelocity.magnitude > 0.01f)
        {
            moveVelocity += externalVelocity;
            // Gradually reduce external forces over time
            externalVelocity = Vector3.Lerp(externalVelocity, Vector3.zero, 5f * Time.fixedDeltaTime);
        }
        #endregion

        // Move player
        controller.Move(moveVelocity * Time.fixedDeltaTime);

        // Smoothly rotate player toward movement direction
        Vector3 horizontalMove = new Vector3(moveVelocity.x, 0f, moveVelocity.z);
        if (horizontalMove.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(horizontalMove, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 10f * Time.fixedDeltaTime);
        }
    }
    #endregion

    #region External Forces
    /// <summary>
    /// Apply a knockback or push to the player
    /// </summary>
    /// <param name="force">Direction and strength</param>
    public void ApplyExternalForce(Vector3 force)
    {
        externalVelocity += force;
    }
    #endregion
}
