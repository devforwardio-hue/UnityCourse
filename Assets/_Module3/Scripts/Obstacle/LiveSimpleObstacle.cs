using UnityEngine;

/*public class LiveSimpleObstacle : MonoBehaviour
{
  public float minDistance = 1f;//? to tell it to go back
  public float maxDistance = 5f;
  public float moveSpeed = 1f;
  public Transform obstacleTransform;
  public Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
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

    
    if (startPosition.x + transform.position.x <= maxDistance ) 
    {
      obstacleTransform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
    }

    }







}
*/