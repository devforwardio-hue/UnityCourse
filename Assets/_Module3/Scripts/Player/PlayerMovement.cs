using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    private Rigidbody rb;
    private Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 
    }

    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
   
        Vector3 desiredXZ = new Vector3(input.x, 0f, input.y) * moveSpeed;

      
        Vector3 v = rb.linearVelocity; 

        Vector3 moveDir = desiredXZ.sqrMagnitude > 0.0001f ? desiredXZ.normalized : Vector3.zero;
        if (moveDir != Vector3.zero)
        {
            float distance = desiredXZ.magnitude * Time.fixedDeltaTime;
         
            if (rb.SweepTest(moveDir, out RaycastHit hit, distance + 0.01f))
            {
                Vector3 slide = Vector3.ProjectOnPlane(desiredXZ, hit.normal);
                desiredXZ = slide;
            }
        }

        v.x = desiredXZ.x;
        v.z = desiredXZ.z;
        rb.linearVelocity = v;
    }

    public void RawInput()
  {
    float x = Input.GetAxisRaw("Horizontal");
    float z = Input.GetAxisRaw("Vertical");

    Vector2 raw = new(x, z);
    input = raw.sqrMagnitude > 1f ? raw.normalized : raw;
  }
}
