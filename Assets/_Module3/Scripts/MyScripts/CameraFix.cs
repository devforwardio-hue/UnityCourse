using UnityEngine;

// This script allows a camera to orbit smoothly around a player or object in third person view.
// It supports manual mouse control and automatic alignment when not rotating.

public class CameraFix : MonoBehaviour
{
    // The camera will follow the player.
    public Transform playercam;

    // The camera view look from above player.
    public Vector3 cameraview = new Vector3(0, 2f, 0);

    // The camera zoom distance from target.
    public float camdistance = 5f;

    // How fast the camera moves horizontally (left/right).
    public float xSpeed = 120f;

    // How fast the camera moves vertically (up/down).
    public float ySpeed = 80f;

    // How close the camera can get to the player.
    public float minDistance = 1.5f;

    // The camera can zoom out from player this far.
    public float maxDistance = 10f;

    // How fast the camera turns to face behind the player automatically.
    public float autoAlignSpeed = 2f;

    // The current horizontal rotation angle (around Y-axis).
    private float xRotation = 0f;

    // The current vertical rotation angle (around X-axis).
    private float yRotation = 20f;

    // Used to check if the player is actively moving the camera.
    private bool isRotating = false;

    void Start()
    {
        // Start by taking the current rotation of the camera in the scene.
        Vector3 angles = transform.eulerAngles;

        // Store the initial horizontal and vertical rotation angles.
        xRotation = angles.y;
        yRotation = angles.x;

        // Lock the mouse cursor so it stays centered during camera control.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // If there is no target, stop running the code.
        if (!playercam) return;

        // If the right mouse button is held down, we allow camera rotation.
        if (Input.GetMouseButton(1))
        {
            isRotating = true; // We are now rotating the camera.

            // Get how much the mouse moved horizontally and vertically this frame.
            float mouseX = Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

            // Add the horizontal mouse movement to the camera’s x rotation.
            xRotation += mouseX;

            // Subtract vertical movement so that moving the mouse up looks downward.
            yRotation -= mouseY;

            // Limit the up and down rotation so the camera doesn’t flip over the top.
            if (yRotation > 70f) yRotation = 70f;   // Upper limit
            if (yRotation < -10f) yRotation = -10f; // Lower limit
        }
        else
        {
            // When the mouse button is not held, start auto-aligning horizontally.

            float targetY = playercam.eulerAngles.y; // Get player’s facing direction.

            // Calculate how much we need to rotate horizontally to match the player.
            // This line ensures the difference stays between -180 and 180 degrees.
            float deltaY = (targetY - xRotation + 540f) % 360f - 180f;

            // Slowly rotate toward the target’s direction over time.
            xRotation += deltaY * Time.deltaTime * autoAlignSpeed;

            isRotating = false; // We are no longer manually rotating.
        }

        // Handle zoom in/out with the mouse scroll wheel.
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            // The camera moves closer or farther depending on scroll direction.
            camdistance -= scroll * 5f;
        }

        // Keep zoom within the allowed range.
        if (camdistance < minDistance) camdistance = minDistance;
        if (camdistance > maxDistance) camdistance = maxDistance;

        // Build the camera’s new rotation using our two angles.
        Quaternion rotation = Quaternion.Euler(yRotation, xRotation, 0);

        // Move the camera backward from the target by “distance” amount.
        Vector3 offset = rotation * new Vector3(0f, 0f, -camdistance);

        // Calculate where the camera should be placed in the world.
        Vector3 desiredPosition = playercam.position + cameraview + offset;

        // Set the camera’s position to that spot.
        transform.position = desiredPosition;

        // Make the camera look at the player smoothly, using world “up” as the up direction.
        transform.rotation = Quaternion.LookRotation((playercam.position + cameraview) - transform.position, Vector3.up);
    }
}