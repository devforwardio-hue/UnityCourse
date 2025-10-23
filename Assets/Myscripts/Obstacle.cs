using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class Obstacle : MonoBehaviour
{


    // public float speed = 1;
    public float minDistance = 1.0f;
    public float maxDistance = 5.0f;
    public float moveSpeed = 1.0f;
    public Transform obstacleTransform;
    public Vector3 startPosition;
    private int count = 0;  
    // Start is called once before the first execution of Update after the MonoBehavior is created

    void Awake()
    {
        obstacleTransform = GetComponent<Transform>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // create a function to look access components for movement
        ObstacleMovement();
    }
    public void ObstacleMovement()
    {
        // the obstacle to move along the x axis up to our max
        
        switch(count)
        {
            case 0:
                obstacleTransform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
                if (transform.position.x >= maxDistance)
                {
                    
                    count = 1;
                }
                break;

            case 1:
                obstacleTransform.position -= new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
                if (transform.position.x <= minDistance)
                {
                    
                    count = 0;
                    
                }
                break;
                
        }
        
        
        



        //so when the transform reaches the maximum distance, return the other way to the minimum, and repeat this.

        //Figuring out where to start th

    }
}






#region-comments 
//need to create a  public variable for speed, left, right, up, down, rotation. 


// could have mutiple functions inside the main function. functions could seperate the variables or the public settings
// varibles need to access the transform componet to have access to the position. 



// create a if statment to help break up the min and max distance, 
//private void Movement ()
//{




//}



#endregion