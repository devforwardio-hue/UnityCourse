using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxDistance = 5.0f;
    public float moveSpeed = 1.0f;
    public Transform obstacleTransform;
    public Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obstacleTransform = GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMovement();

    }
    public void ObstacleMovement()
        {

        obstacleTransform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        //move along the x axis

        //we need to set a obstacleSpeed

        //so when the transform reaches the maximum distance, return the other way to the minimum, and repeat this.

        //Figuring out where to start the obstacle at
    }



}