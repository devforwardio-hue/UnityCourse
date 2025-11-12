using UnityEngine;

public class AdvancedObstacle : MonoBehaviour
{
    public ObstacleType type;
    public float moveDistance = 5f; 
    public float moveSpeed = 1f; 
    public Transform obstacleTransform;
    private Vector3 startPosition;
    private int obstacleDirection = 1;

    [Header("Rotation Settings")]
    public bool enableRotation = true;
    public Vector3 rotationAxis = new Vector3(0f, 1f, 0f);
    public float rotationSpeed = 90f; 
    public bool rotateInLocalSpace = true;
    private float debugOffset = 0f;

    public enum ObstacleType
    {
        X, Y, Z
    }

    void Awake()
    {
        if (obstacleTransform == null)
        {
            obstacleTransform = this.GetComponent<Transform>();
        }
    }

    void Start()
    {
        startPosition = obstacleTransform.position;
    }

    void Update()
    {
        ObstacleMovement();
        if (enableRotation)
        {
            ObstacleRotation();
        }
    }

    public void ObstacleMovement()
    {
        float posMoving = moveSpeed * obstacleDirection * Time.deltaTime;

        Vector3 currentPosition = obstacleTransform.position;
        float offsetFromStart = 0f;

        if (type == ObstacleType.X)
        {
            float newX = currentPosition.x + posMoving;
            currentPosition.x = newX;
            offsetFromStart = currentPosition.x - startPosition.x;
        }
        else if (type == ObstacleType.Y)
        {
            float newY = currentPosition.y + posMoving;
            currentPosition.y = newY;
            offsetFromStart = currentPosition.y - startPosition.y;
        }
        else
        {
            float newZ = currentPosition.z + posMoving;
            currentPosition.z = newZ;
            offsetFromStart = currentPosition.z - startPosition.z;
        }

        obstacleTransform.position = currentPosition;

        if (offsetFromStart >= moveDistance)
        {
            obstacleDirection = -1;
        }
        else if (offsetFromStart <= -moveDistance)
        {
            obstacleDirection = 1;
        }
    }

    public void ObstacleRotation()
    {
        float degreesThisFrame = rotationSpeed * Time.deltaTime;

        Vector3 eulerDelta = new Vector3(rotationAxis.x * degreesThisFrame,
                                         rotationAxis.y * degreesThisFrame,
                                         rotationAxis.z * degreesThisFrame);

        Quaternion deltaQuat = Quaternion.Euler(eulerDelta);

        if (rotateInLocalSpace)
        {
            Quaternion currentRot = obstacleTransform.localRotation;
            Quaternion newLocalRot = currentRot * deltaQuat;
            obstacleTransform.localRotation = newLocalRot;

        }
        else
        {
            Quaternion currentRotWorld = obstacleTransform.rotation;
            Quaternion newWorldRot = deltaQuat * currentRotWorld;
            obstacleTransform.rotation = newWorldRot;

        }
    }
}
