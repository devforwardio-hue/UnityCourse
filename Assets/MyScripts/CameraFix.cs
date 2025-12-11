using UnityEngine;

public class CameraFix : MonoBehaviour
{
    public Transform playercam;              // Player target
    public Vector3 cameraview = new Vector3(0, 2f, 0);
    public float camdistance = 5f;
    public float xSpeed = 120f;
    public float ySpeed = 80f;
    public float minDistance = 1.5f;
    public float maxDistance = 10f;
    public float autoAlignSpeed = 2f;

    private float xRotation = 0f;
    private float yRotation = 20f;
    private bool isRotating = false;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        xRotation = angles.y;
        yRotation = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (!playercam) return;

        // 1️⃣ Mouse input for rotation
        if (Input.GetMouseButton(1))
        {
            isRotating = true;

            float mouseX = Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

            xRotation += mouseX;
            yRotation -= mouseY;

            yRotation = Mathf.Clamp(yRotation, -10f, 70f);
        }
        else
        {
            isRotating = false;

            // 2️⃣ Auto-align only if player is moving
            Vector3 horizontalVelocity = new Vector3(playercam.GetComponent<Rigidbody>().linearVelocity.x, 0f, playercam.GetComponent<Rigidbody>().linearVelocity.z);
            if (horizontalVelocity.magnitude > 0.1f)
            {
                float targetY = playercam.eulerAngles.y;
                float deltaY = (targetY - xRotation + 540f) % 360f - 180f;
                xRotation += deltaY * Time.deltaTime * autoAlignSpeed;
            }
        }

        // 3️⃣ Zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        camdistance = Mathf.Clamp(camdistance - scroll * 5f, minDistance, maxDistance);

        // 4️⃣ Calculate camera rotation & position
        Quaternion rotation = Quaternion.Euler(yRotation, xRotation, 0f);
        Vector3 offset = rotation * new Vector3(0f, 0f, -camdistance);
        Vector3 desiredPosition = playercam.position + cameraview + offset;

        transform.position = desiredPosition;
        transform.rotation = Quaternion.LookRotation((playercam.position + cameraview) - transform.position, Vector3.up);
    }
}
