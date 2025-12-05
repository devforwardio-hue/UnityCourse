using UnityEngine;

public class SampleCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offest;

    void Awake()
    {
        if (target == null)
        {
            //offset is off of the target and the camera
            offest = transform.position - target.position;
        }
    }

    
    void LateUpdate()
    {
        transform.position = target.position + offest;
    }
}
