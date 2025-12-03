using UnityEngine;
public class FollowTarget : MonoBehaviour
{
    public Transform target;          
    public bool followRotation = false; 

    private Vector3 offset; 

    void Awake()
    {
        if (target != null)
        {
            offset = transform.position - target.position; 
        }
    }

    void LateUpdate()
    {
        if (target == null) return;
        transform.position = target.position + offset;
    }
}
