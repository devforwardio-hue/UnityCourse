using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerFull : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Walking speed in units/sec")]
    public float moveSpeed = 10f;
    public float defaultSpeed = 10f;

    [Header("Auto-Rotate (when idle)")]
    [Tooltip("Reference to the CameraManager (parent of orbit/zoom). Player will align away from this.")]
    public Transform orbiterRef; // set this to CameraManager in inspector

    [Tooltip("Degrees per second when using RotateTowards (if turnSmoothTime == 0)")]
    public float turnSpeed = 360f;

    [Tooltip("Delay (seconds) before starting to auto-rotate once idle.")]
    public float turnStartDelay = 0.1f;

    [Tooltip("Minimum degrees difference to start auto-turning.")]
    public float startTurnThreshold = 2f;

    [Tooltip("If > 0, uses SmoothDampAngle with this time; otherwise uses RotateTowards at turnSpeed.")]
    public float turnSmoothTime = 0.08f;

    // internals
    private Rigidbody rb;
    private Vector3 moveDir;
    private float yawVelocity;
    private float delayTimer;
    private bool turningActive;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = defaultSpeed;
        // Keep upright
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRawMovement();
    }

    void FixedUpdate()
    {
        ApplyMovement();

        // Only auto-rotate when not providing movement input
        if (moveDir.sqrMagnitude < 0.01f)
        {
            AlignBackToOrbiter(); // uses orbiterRef
        }
        else
        {
            // When player moves, cancel any pending auto-rotation
            turningActive = false;
            delayTimer = 0f;
        }
    }

    // Read raw input relative to camera
    private void HandleRawMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(horizontal, 0f, vertical).normalized;

        if (input.magnitude >= 0.1f)
        {
            Transform cam = Camera.main ? Camera.main.transform : null;
            if (cam == null)
            {
                // Fallback to world axes
                moveDir = input;
                return;
            }

            Vector3 camForward = cam.forward;
            camForward.y = 0f;
            camForward.Normalize();

            Vector3 camRight = cam.right;
            camRight.y = 0f;
            camRight.Normalize();

            moveDir = camForward * input.z + camRight * input.x;
            moveDir.Normalize();
        }
        else
        {
            moveDir = Vector3.zero;
        }
    }

    // Move via Rigidbody for stable physics collisions
    private void ApplyMovement()
    {
        if (moveDir.sqrMagnitude > 0.01f)
        {
            Vector3 newPos = rb.position + moveDir * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPos);

            // Smoothly rotate toward movement direction
            Quaternion targetRot = Quaternion.LookRotation(moveDir, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, 10f * Time.fixedDeltaTime));
        }
    }

    // Auto-rotate the player so their forward points AWAY from orbiterRef (i.e., player faces away from camera)
    private void AlignBackToOrbiter()
    {
        if (orbiterRef == null)
        {
            turningActive = false;
            delayTimer = 0f;
            return;
        }

        // vector from player to orbiter (cameraManager)
        Vector3 toOrbiter = orbiterRef.position - transform.position;
        // desired forward is away from orbiter, projected onto XZ plane
        Vector3 desiredForward = Vector3.ProjectOnPlane(-toOrbiter, Vector3.up);

        if (desiredForward.sqrMagnitude < 1e-6f)
        {
            turningActive = false;
            delayTimer = 0f;
            return;
        }

        Quaternion targetRot = Quaternion.LookRotation(desiredForward, Vector3.up);

        float currentYaw = transform.eulerAngles.y;
        float targetYaw = targetRot.eulerAngles.y;
        float angle = Mathf.DeltaAngle(currentYaw, targetYaw);
        float absAngle = Mathf.Abs(angle);

        // If already close enough, stop
        if (absAngle < startTurnThreshold)
        {
            turningActive = false;
            delayTimer = 0f;
            return;
        }

        // Start delay before turning
        if (!turningActive)
        {
            delayTimer += Time.fixedDeltaTime;
            if (delayTimer < turnStartDelay) return;

            turningActive = true;
            yawVelocity = 0f;
        }

        // Perform rotation either smoothly or at fixed speed
        if (turnSmoothTime > 0f)
        {
            float smoothedYaw = Mathf.SmoothDampAngle(currentYaw, targetYaw, ref yawVelocity, turnSmoothTime, Mathf.Infinity, Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(0f, smoothedYaw, 0f);
        }
        else
        {
            float maxStep = turnSpeed * Time.fixedDeltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, maxStep);
        }

        // If close to target, stop turning
        float remaining = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetYaw));
        if (remaining < startTurnThreshold * 0.5f)
        {
            turningActive = false;
            delayTimer = 0f;
        }
    }
}
