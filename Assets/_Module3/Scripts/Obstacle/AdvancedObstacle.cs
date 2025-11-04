using UnityEngine;

public class AdvancedObstacle : MonoBehaviour
{
    public enum ObstacleType
    {
        X, Y, Z
    }
    public ObstacleType type;
    public float moveDistance = 5f;
    public float moveSpeed = 1f;
    public float rotationMultiplier = 30f; // New: tuning for spin effect
    public Transform obstacleTransform;
    public Vector3 startPosition;
    private int obstacleDirection = 1;
    private Vector3 lastPosition; // New: track last frame's position

    void Awake()
    {
        obstacleTransform = GetComponent<Transform>();
    }

    void Start()
    {
        startPosition = obstacleTransform.position;
        lastPosition = obstacleTransform.position; // New: initialize
    }

    void Update()
    {
        ObstacleMovement();
    }

    public void ObstacleMovement()
    {
        float posMoving = moveSpeed * obstacleDirection * Time.deltaTime;
        float currentAxisPosition = 0f;
        float offsetFromStart = 0f;
        float xpos = 0f;
        float ypos = 0f;
        float zpos = 0f;

        switch (type)
        {
            case ObstacleType.X:
                xpos = posMoving;
                currentAxisPosition = obstacleTransform.position.x;
                offsetFromStart = obstacleTransform.position.x - startPosition.x;
                break;
            case ObstacleType.Y:
                ypos = posMoving;
                currentAxisPosition = obstacleTransform.position.y;
                offsetFromStart = obstacleTransform.position.y - startPosition.y;
                break;
            case ObstacleType.Z:
                zpos = posMoving;
                currentAxisPosition = obstacleTransform.position.z;
                offsetFromStart = obstacleTransform.position.z - startPosition.z;
                break;
            default:
                xpos = posMoving;
                break;
        }

        obstacleTransform.position += new Vector3(xpos, ypos, zpos);
        //obstacleTransform.rotation += new Vector3(5, 1, 1);

        // --- Rotation tangent to movement ---
        //Vector3 movement = obstacleTransform.position - lastPosition;
        //if (movement.sqrMagnitude > 0.0001f)
        //{
        //    // Tangent axis for rotation 
        //    Vector3 tangentAxis = Vector3.Cross(movement.normalized, Vector3.up);
        //    float angle = movement.magnitude * rotationMultiplier;
        //    // Only apply rotation if tangent is significant
        //    if (tangentAxis.sqrMagnitude > 0.0001f)
        //    {
        //        obstacleTransform.Rotate(tangentAxis, angle, Space.World);
        //    }
        //}

        // --- Quaternion rotation tangent to movement, no Mathf used ---
        Vector3 movement = obstacleTransform.position - lastPosition;
        if (movement.sqrMagnitude > 0.0001f)
        {
            // Rotate to align a forward vector with the movement direction
            Quaternion deltaRotation = Quaternion.FromToRotation(Vector3.right, movement.normalized);
            // Use rotationMultiplier for effect, scaling by movement magnitude
            obstacleTransform.rotation = Quaternion.Slerp(obstacleTransform.rotation, deltaRotation * obstacleTransform.rotation, movement.magnitude * rotationMultiplier * Time.deltaTime);
        }
        lastPosition = obstacleTransform.position;
        // -----------------------------------

        if (offsetFromStart >= moveDistance)
        {
            obstacleDirection = -1;
        }
        else if (offsetFromStart <= -moveDistance)
        {
            obstacleDirection = 1;
        }
    }
}
