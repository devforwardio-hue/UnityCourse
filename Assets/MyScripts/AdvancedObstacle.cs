using UnityEngine;

public enum ObstacleAxis
{
    X, Y, Z
}

public class AdvancedObstacle : MonoBehaviour
{
    public ObstacleAxis moveAxis = ObstacleAxis.X;
   
    public float moveDistance = 5f;
    public float moveSpeed = 1f;
    public float rotationSpeed = 90f;
    
    public bool enableMovement = true;
    public bool enableRotation = true;
   
    public Vector3 rotationAxis = Vector3.up;
    private Vector3 startPosition;
    
    private Transform obstacleTransform;
    
    private int moveDirection = 1;
    void Awake()
    {
        obstacleTransform = GetComponent<Transform>();
    }
    void Start()
    {
        startPosition = obstacleTransform.position;
    }
    void Update()
    {
        if (enableMovement)
            HandleMovement();
        if (enableRotation)
            HandleRotation();
    }
    private void HandleMovement()
    {
        Vector3 movement = Vector3.zero;
        float offsetFromStart = 0f;

        switch (moveAxis)
        {
            case ObstacleAxis.X:
                movement = Vector3.right * moveSpeed * moveDirection * Time.deltaTime;
                offsetFromStart = obstacleTransform.position.x - startPosition.x;
                break;
            case ObstacleAxis.Y:
                movement = Vector3.up * moveSpeed * moveDirection * Time.deltaTime;
                offsetFromStart = obstacleTransform.position.y - startPosition.y;
                break;
            case ObstacleAxis.Z:
                movement = Vector3.forward * moveSpeed * moveDirection * Time.deltaTime;
                offsetFromStart = obstacleTransform.position.z - startPosition.z;
                break;
        }

        obstacleTransform.position += movement;

        if (offsetFromStart >= moveDistance)
        {
            moveDirection = -1;
        }
        else if (offsetFromStart <= -moveDistance)
        {
            moveDirection = 1;
        }
    }

    private void HandleRotation()
    {
        Vector3 rotationThisFrame = rotationAxis.normalized * rotationSpeed * moveDirection * Time.deltaTime;
        obstacleTransform.Rotate(rotationThisFrame, Space.Self);
    }
}