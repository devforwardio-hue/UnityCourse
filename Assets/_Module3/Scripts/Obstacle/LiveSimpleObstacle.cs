using UnityEngine;

public class LiveSimpleObstacle : MonoBehaviour
{
public enum MovementAxis
{
  X, Y, Z
}

public enum RotationAxis
{
  X, Y, Z
}
  public MovementAxis moveAxis;
  public RotationAxis rotationAxis;
  public float moveDistance = 5f;
  public float moveSpeed = 1f;
  public float rotationSpeed = 100f;
  public Transform obstacleTransform;
  public Vector3 startPosition;
  private int obstacleDirection = 1;

  void Awake()
    {
      obstacleTransform = GetComponent<Transform>();
    }

    void Start()
    {
      // Record the initial position so we can compare movement along the selected axis
      startPosition = obstacleTransform.position;
    }

  // Update is called once per frame
  void Update()
    {
      ObstacleMovement();
      ObstacleRotation();
     }

  public void ObstacleMovement()
  {
    if (moveSpeed <= 0f) { return; }
    float posMoving = moveSpeed * obstacleDirection * Time.deltaTime;
    float currentAxisPosition = 0f;
    float offsetFromStart = 0f;
    float xpos = 0f;
    float ypos = 0f;
    float zpos = 0f;
    // Set movement along one axis explicitly
    switch (moveAxis)
    {
      case MovementAxis.X:
        xpos = posMoving;
        currentAxisPosition = obstacleTransform.position.x;
        offsetFromStart = obstacleTransform.position.x - startPosition.x;
        Debug.Log(offsetFromStart);
        break;
      case MovementAxis.Y:
        ypos = posMoving;
        currentAxisPosition = obstacleTransform.position.y;
        offsetFromStart = obstacleTransform.position.y - startPosition.y;
        break;
      case MovementAxis.Z:
        zpos = posMoving;
        currentAxisPosition = obstacleTransform.position.z;
        offsetFromStart = obstacleTransform.position.z - startPosition.z;
        break;
      default:
        xpos = posMoving;
        break;
    }


    obstacleTransform.position += new Vector3(xpos, ypos, zpos);
    if (offsetFromStart >= moveDistance)
    {
      obstacleDirection = -1;
    }
    else if (offsetFromStart <= -moveDistance)
    {
      obstacleDirection = 1;
    }
  }
  public void ObstacleRotation()
  {
    if (rotationSpeed <= 0f) { return; }//do nothing 
    float posRotation = rotationSpeed * Time.deltaTime;
    float xpos = 0f;
    float ypos = 0f;
    float zpos = 0f;

    switch (rotationAxis)
    {
      case RotationAxis.X:
        xpos = posRotation;
        break;
      case RotationAxis.Y:
        ypos = posRotation;
        break;
      case RotationAxis.Z:
        zpos = posRotation;
        break;
      default:
        xpos = posRotation;
        break;
    }

    Quaternion rotationValue = Quaternion.Euler(xpos, ypos, zpos);
    obstacleTransform.rotation = obstacleTransform.rotation * rotationValue;

  
  }
}
