using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float minDistance = 1f;
    public float maxDistance = 5f;
    public Transform obstacleTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
      
    public void ObstacleMovement()
    {
        //I need to access the transform of the obstacle to move along the x axis
    

        //we need to set a obstacleSpeed

        //so when the transform reaches the maximum distance, return the other way to the minimum, and repeat this.

        //Figuring out where to start the obstacle at

    }


}
