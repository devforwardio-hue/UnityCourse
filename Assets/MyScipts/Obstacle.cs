using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // layer 1
    // Obstacle cube is to movement left to right from starting position.  and rotate around and around.
    // obstacle cube movement to the left (X)  till max and reverse to right (X) till max 
    // and reverse again at max.

    // set max and min value for movement
    //  set speed for movement

    // layer 2
    // create minMovement and maxMovement float variable
    // change the x value of the obstacle position
    // create speed variable to control the speed of movement
    // when the tansform.position.x is greater than maxMovement reverse the direction
    // when the tansform.position.x is less than minMovement reverse the direction


    // layer 3

    public float step = 1f;
    public float maxMovementNeg = -5f;  
    public float maxMovement = 5f;
    public float movespeed = 1f;
    public Transform obstacleTransform;
    public Vector3 startPosition;

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

        // change the x value of the obstacle position
        
        // create speed variable to control the speed of movement

        // when the tansform.position.x is greater than maxMovement reverse the direction

        // when the tansform.position.x is less than minMovement reverse the direction
        


            if (startPosition.x + transform.position.x <= maxMovement)
            {
                obstacleTransform.position += new Vector3(step, 0, 0) * movespeed * Time.deltaTime;
            }

        if (startPosition.x + transform.position.x >= maxMovementNeg)
        {
            obstacleTransform.position += new Vector3(step, 0, 0) * movespeed * Time.deltaTime;
        }


        if (startPosition.x + transform.position.x >= maxMovement)
            {
            step = -step;
            }
       
        
        if (startPosition.x + transform.position.x <= maxMovementNeg)
            {
            step = -step;
            }



    }
}
