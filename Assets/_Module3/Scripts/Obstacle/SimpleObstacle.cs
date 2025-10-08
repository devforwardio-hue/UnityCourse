using UnityEngine;

public class SimpleObstacle : MonoBehaviour
{
  public Vector3 direction = Vector3.forward;
  public float speed = 1f;
  public Vector3 rotationDirection = Vector3.up;
  public float rotationSpeed = 1f;
  public float maxMoveDistance = 5f;
  private Vector3 startPosition;
  private float moveDirection = 1f;


  void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {
   
    transform.position += direction.normalized * speed * moveDirection * Time.deltaTime;
    transform.Rotate(rotationDirection.normalized * rotationSpeed * Time.deltaTime);

    if (Vector3.Distance(startPosition, transform.position) >= maxMoveDistance)
    {
        moveDirection *= -1f; 
    }
  }
}
