using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //create minDistance, maxDistance as floats because I need decimal access.
    public float minDistance = 1.0f;
    public float maxDistance = 5.0f;
    public float moveSpeed = 2.0f;
    

    private Transform obstacleTransform;
    private int obstacleDirection = 1;

    // OLD PESDO CODE BELOW - DELETE LATER
    // Take 3d object and make it move a along the x and z axis, be able to control the speed of the movement
    // Take the same object and make it move along the y axis, be able to control the speed of the movement
    // Rotate the object along any axis, be able to control the speed of the rotation

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        obstacleTransform = GetComponent<Transform>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacle();
    }

    public void MoveObstacle()
    {
        //I need to access the transform of the obstacle to move along the x axis
        obstacleTransform.position += new Vector3(moveSpeed * obstacleDirection * Time.deltaTime, 0f, 0f);

        if (obstacleTransform.position.x >= maxDistance)
        {
            obstacleDirection = -1;
        }
        else if (obstacleTransform.position.x <= minDistance)
        {
            obstacleDirection = 1;
        }


        //so when the transform reaches the maximum distance, return the other way to the minimum, and repeat this.

        //Figuring out where to start the obstacle at

    }
}


        //Old advanced move using Mathf.PingPong
        //float x = Mathf.PingPong(Time.time * moveSpeed, maxDistance - minDistance) + minDistance;
        //float y = Mathf.PingPong(Time.time * moveSpeed, maxDistance - minDistance) + minDistance;
        //float z = Mathf.PingPong(Time.time * moveSpeed, maxDistance - minDistance) + minDistance;
