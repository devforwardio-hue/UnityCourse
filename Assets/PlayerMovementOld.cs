using UnityEngine;

public class PlayerMovementOld : MonoBehaviour
{
  public float moveSpeed = 10f;
  public float defaultSpeed = 10f;

  void Start()
    {
      moveSpeed = defaultSpeed;
    }

    void Update()
    {

      HandleRawMovement();
    }

  private void HandleRawMovement()
  {
    if (Input.GetKey(KeyCode.W))
    {
      transform.position = transform.position + Vector3.forward * (moveSpeed * Time.deltaTime);
    }
    if (Input.GetKey(KeyCode.S))
    {
     transform.position = transform.position + Vector3.back * (moveSpeed * Time.deltaTime);
    }
    if (Input.GetKey(KeyCode.A))
    {
      transform.position = transform.position + Vector3.left * (moveSpeed * Time.deltaTime);
    }
    if (Input.GetKey(KeyCode.D))
    {
      transform.position = transform.position + Vector3.right * (moveSpeed * Time.deltaTime);
    }
  }


  #region OldMovementCode
  //if a condition is met,
  //Do this things.
  //else, do this other thing. 

  //Vector3(x, y, z)

  //if (Input.GetKey(KeyCode.D))
  //{
  //  Vector3 movementRight = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
  //  transform.Translate(movementRight);
  //}

  // if (Input.GetKey(KeyCode.A)) 
  //{ 
  //   Vector3 movementLeft = new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
  //   transform.Translate(movementLeft);
  //}

  //if (Input.GetKey(KeyCode.W))
  //{
  //  Vector3 movementLeft = new Vector3(0f, 0f, moveSpeed * Time.deltaTime);
  //  transform.Translate(movementLeft);
  //}

  //if (Input.GetKey(KeyCode.S))
  //{
  //  Vector3 movementLeft = new Vector3(0f, 0f, -moveSpeed * Time.deltaTime);
  //  transform.Translate(movementLeft);
  //}
  #endregion

}
