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
    //CHALLENGE:
    //RESEARCH: Vector3.Distance
    //RESEARCH: Vector3.Normalize
    //RESEARCH: Making an object, move left to right.

    //FIX THE CODE TO COMPLETE THE LEFT RIGHT FUNCTIONALITY
    //DONT ADD OTHER SHIT. 

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