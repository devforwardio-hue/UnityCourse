using UnityEngine;

public class LiveSimpleObstacle : MonoBehaviour
{
    public float speed = 2f;      // Speed of Object
    public float distance = 3f;   // Range of Object
    public float rotationSpeed = 90f;  // Degrees per second for  any axis rotation

    private Vector3 startPosition;

    void Start()
    {
        // Store the starting position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the object along X and Z using sine and cosine 
        float x = Mathf.Sin(Time.time * speed) * distance;
        float z = Mathf.Cos(Time.time * speed) * distance;

        // Apply the new position
        transform.position = startPosition + new Vector3(x, 0, z);

        //transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);  //X-Axis Movement spin
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime, Space.Self);    //Z-Axis diagonal spin
    }
}
