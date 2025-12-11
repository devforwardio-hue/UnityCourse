using UnityEngine;

public class Obstacle : MonoBehaviour
{
  public float minDistance = 1f;//? to tell it to go back
  public float maxDistance = 5f;
  public float moveSpeed = 1f;
  public Transform obstacleTransform;
  public Vector3 startPosition;
  private int direction = 1; // 1 = right, -1 = left

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Awake()
    {
      obstacleTransform = GetComponent<Transform>();
      startPosition = obstacleTransform.position;
    }

  // Update is called once per frame
  void Update()
    {
      ObstacleMovement();
    }

  public void ObstacleMovement()
  {
    //great work. 
    //This is basically how the shorthand version works as well functionality wise.
    //You figured out exactly what I was trying to do during the class. great job.

    obstacleTransform.position += new Vector3(direction, 0, 0) * moveSpeed * Time.deltaTime;

    if (obstacleTransform.position.x >= startPosition.x + maxDistance)
    {      
      direction = -1;
    }
    else if (obstacleTransform.position.x <= startPosition.x - maxDistance)
    {
      direction = 1;
    }
  }

}