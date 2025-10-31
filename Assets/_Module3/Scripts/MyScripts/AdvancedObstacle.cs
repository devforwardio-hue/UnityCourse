using UnityEngine;

public class AdvancedObstacle : MonoBehaviour
{
    public ObstacleType type;
    public float moveDistance = 5f;
    public float moveSpeed = 1f;
    public Transform obstacleTransform;
    public Vector3 startPosition;
    public float rotationSpeed = 20f; // so that i can set the rotation speed via inspector
    private int obstacleDirection = 1;
    public enum ObstacleType
    { 
        PX, PY, PZ, RX, RY, RZ
    }

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
    }

    public void ObstacleMovement()
    {
        ObstacleMovement(obstacleTransform);
    }

    public void ObstacleMovement(Transform obstacleTransform)
    {
        float posMoving = moveSpeed * obstacleDirection * Time.deltaTime;
        float currentAxisPosition = 0f;
        float offsetFromStart = 0f;
        float xpos = 0f;
        float ypos = 0f;
        float zpos = 0f;
        float posRotating = rotationSpeed * Time.deltaTime; // calculation for rotation speed
        float xrot = 0f;
        float yrot = 0f;
        float zrot = 0f;
        
        switch (type)
        {
            case ObstacleType.PX:
                xpos = posMoving;
                currentAxisPosition = obstacleTransform.position.x;
                offsetFromStart = obstacleTransform.position.x - startPosition.x;
                
                break;
            case ObstacleType.PY:
                ypos = posMoving;
                currentAxisPosition = obstacleTransform.position.y;
                offsetFromStart = obstacleTransform.position.y - startPosition.y;
                
                break;
            case ObstacleType.PZ:
                zpos = posMoving;
                currentAxisPosition = obstacleTransform.position.z;
                offsetFromStart = obstacleTransform.position.z - startPosition.z;
                
                break;
            case ObstacleType.RX:  //my added
                xrot = posRotating;
                break;
            case ObstacleType.RY:
                yrot = posRotating;
                break;
            case ObstacleType.RZ:
                zrot = posRotating;
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

        obstacleTransform.Rotate(new Vector3(xrot, yrot, zrot));
        

    }
}
