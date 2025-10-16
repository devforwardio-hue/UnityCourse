using UnityEngine;

public class LookingCamera : MonoBehaviour
{
    //float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivty = 15f;
     void Update()
    {
        //rotationX += Input.GetAxis("Mouse Y") * sensitivty;
        rotationY += Input.GetAxis("Mouse X") * +1 * sensitivty;
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
    }
}
