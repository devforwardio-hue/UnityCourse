using UnityEngine;
public class RotatingObstacle : MonoBehaviour
{
    public float minDistance = 1f;
    public float maxDistance = 5f;
    public float moveSpeed = 1f;
    public float rotationSpeed = 90f;

    public Transform obstacleTransform;
    
    public Vector3 startPosition;

    private int direction = 0;

    void Awake()
    {
        obstacleTransform = GetComponent<Transform>();
        startPosition = obstacleTransform.position;
    }

    private void Update()
    {
        ObstacleMovement();
        ObstacleRotation();
    }

    public void ObstacleMovement() 
    {
        float distanceFormStart = Vector3.Distance(obstacleTransform.position, startPosition);
        obstacleTransform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        if (distanceFormStart >= maxDistance)
        {
           direction = -1;
        }
        else if (distanceFormStart <= minDistance)
        {
            direction = 1;       
        }
    }
    public void ObstacleRotation() 
    {
        Vector3 rotationThisFrame = new Vector3(0f, rotationSpeed * direction * Time.deltaTime, 0f);
        obstacleTransform.Rotate(rotationThisFrame, Space.Self);
    }
}


