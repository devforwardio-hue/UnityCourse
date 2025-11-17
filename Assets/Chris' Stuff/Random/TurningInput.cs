using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TurningInput : MonoBehaviour
{
    public Transform cameraTransform;
    public float rotationSpeed = 10f;

    private CharacterController characterController;
    private Vector3 moveDirection;
    private Vector3 playerVelocity;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            cameraForward.y = 0f;
            cameraRight.y = 0f;
            cameraForward.Normalize();
            cameraRight.Normalize();

            moveDirection = cameraForward * verticalInput + cameraRight * horizontalInput;
        }
    }
}
