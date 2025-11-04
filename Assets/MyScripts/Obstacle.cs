using UnityEngine;

public class StrafingObstacle : MonoBehaviour
{
    public float minDistance = 1f; 
    public float maxDistance = 5f; 
    public float moveSpeed = 1f;
    
    public Transform obstacleTransform;
    
    public Vector3 startPosition;

    private int direction = 1; 

    void Awake()
    {
        obstacleTransform = GetComponent<Transform>();
        startPosition = obstacleTransform.position;
    }

    void Update()
    {
        ObstacleMovement();
    }

    public void ObstacleMovement()
    {
        float distanceFromStart = Vector3.Distance(obstacleTransform.position, startPosition);
        obstacleTransform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        if (distanceFromStart >= maxDistance)
        {
            direction = -1;
        }
        else if (distanceFromStart <= minDistance)
        {
            direction = 1;
        }
    }
}