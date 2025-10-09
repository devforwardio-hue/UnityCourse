using UnityEngine;

public class JumpingOld : MonoBehaviour
{

  public Rigidbody rb;
  public float jumpForce = 10f;
  public bool isGrounded = false;

    
   
    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        JumpSystem();
    }

  public void JumpSystem()
  {

    if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
    {
     isGrounded = false;
      rb.AddForce(new(0,jumpForce, 0), ForceMode.Impulse);

    }
  }

  void OnCollisionEnter(Collision collision)
  {
    Debug.Log(collision.gameObject.name);
    if (collision.gameObject.CompareTag("Floor"))
    {
      isGrounded = true;
    }
  }
}
