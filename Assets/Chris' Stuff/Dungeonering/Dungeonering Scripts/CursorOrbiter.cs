using UnityEngine;

public class CursorOrbiter : MonoBehaviour
{

    public Transform target;
    public float orbitDistance = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitObject();
    }

    void OrbitObject()
    {
        // Get mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;
        // Convert mouse position to viewport space (0 to 1)
        Vector3 viewportPoint = Camera.main.ScreenToViewportPoint(mousePosition);
        // Map viewport coordinates to angles
        float horizontalAngle = (viewportPoint.x - 0.5f) * 360f; // Full horizontal rotation
        float verticalAngle = (viewportPoint.y - 0.5f) * 180f;   // Vertical rotation from -90 to +90
        // Calculate the new position using spherical coordinates
        float x = target.position.x + orbitDistance * Mathf.Cos(Mathf.Deg2Rad * verticalAngle) * Mathf.Sin(Mathf.Deg2Rad * horizontalAngle);
        float y = target.position.y + orbitDistance * Mathf.Sin(Mathf.Deg2Rad * verticalAngle);
        float z = target.position.z + orbitDistance * Mathf.Cos(Mathf.Deg2Rad * verticalAngle) * Mathf.Cos(Mathf.Deg2Rad * horizontalAngle);
        // Update the position of the orbiting object
        transform.position = new Vector3(x, y, z);
        // Always look at the target
        transform.LookAt(target);
    }
}
