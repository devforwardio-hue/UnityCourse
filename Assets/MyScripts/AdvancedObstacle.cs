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
    public float rotationSpeed = 200f;
    public Transform obstacleTransform;
    public Vector3 startPosition;
    private int obstacleDirection = 1;

    void Awake()
    {
        obstacleTransform = GetComponent<Transform>();
    }

    void Start()
    {
        // Record the initial position so we can compare movement along the selected axis
        startPosition = obstacleTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMovement();

        ObstacleRotation();
    }

    public void ObstacleMovement()
    {
        float posMoving = moveSpeed * obstacleDirection * Time.deltaTime;
        float currentAxisPosition = 0f;
        float offsetFromStart = 0f;
        float xpos = 0f;
        float ypos = 0f;
        float zpos = 0f;
        Debug.Log(currentAxisPosition);
        // Set movement along one axis explicitly
        switch (type)
        {
            case ObstacleType.X:
                xpos = posMoving;
                currentAxisPosition = obstacleTransform.position.x;
                offsetFromStart = obstacleTransform.position.x - startPosition.x;
                Debug.Log(offsetFromStart);
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
        switch (type)
        {
            case ObstacleType.X:
                obstacleTransform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
                break;
            case ObstacleType.Y:
                obstacleTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
                break;
            case ObstacleType.Z:
                obstacleTransform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                break;
            default:
                obstacleTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
                break;
        }
    }
}
