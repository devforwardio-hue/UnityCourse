using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [Tooltip("Target to follow (player transform)")]
    public Transform target;

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
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
