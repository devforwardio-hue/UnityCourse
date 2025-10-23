using UnityEngine;

public class SimpleObstacle : MonoBehaviour
{
  public Vector3 direction = Vector3.forward;
  public Vector3 rotationDirection = Vector3.up;
  private Vector3 startPosition;
  
  public float speed = 1f;
  public float rotationSpeed = 1f;
  public float maxMoveDistance = 5f;
  private float moveDirection = 1f;


  void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {

    TranslateObstacle();
    }

  public void TranslateObstacle()
  {
    transform.position += direction.normalized * speed * moveDirection * Time.deltaTime;
    transform.Rotate(rotationDirection.normalized * rotationSpeed * Time.deltaTime);
    if (Vector3.Distance(startPosition, transform.position) >= maxMoveDistance)
    {
      moveDirection *= -1f;
    }
  }
}
