using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform; // Drag your Camera object here in the Inspector
    public float rotationSpeed = 10f; // Speed for the player model to rotate

    private CharacterController characterController;
    private Vector3 moveDirection;
    private Vector3 playerVelocity;
    public float gravity = 0f; // Add gravity

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // Lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get input from keyboard/joystick
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Apply gravity
        if (characterController.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        playerVelocity.y += gravity * Time.deltaTime;

        // Calculate movement direction relative to the camera
        Vector3 inputDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            // Get camera's forward and right vectors
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            // Project vectors onto the horizontal plane (ignore Y axis) and normalize
            cameraForward.y = 0f;
            cameraRight.y = 0f;
            cameraForward.Normalize();
            cameraRight.Normalize();

            // Calculate desired world space movement direction
            moveDirection = cameraForward * verticalInput + cameraRight * horizontalInput;

            // Rotate the player model to face the movement direction smoothly
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Apply movement
        characterController.Move((moveDirection * moveSpeed + playerVelocity) * Time.deltaTime);
    }
}
