using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float minDistance = 1f;
    public float maxDistance = 5f;
    public float moveSpeed = 1f;
    public Transform obstacleTransform;
    public Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       obstacleTransform = GetComponent<Transform>();
       // capture the starting position so movement is relative to it
       startPosition = transform.position;
    }
    
    
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMovement();
    }

    public void ObstacleMovement()
    {
        // ensure distances make sense
        float range = maxDistance - minDistance;
        if (range <= 0f)
            return;

        // PingPong produces a value that moves back and forth between 0 and range.
        // Add minDistance so the final X oscillates between startPosition.x + minDistance and startPosition.x + maxDistance.
        float offset = Mathf.PingPong(Time.time * moveSpeed, range) + minDistance;
        Vector3 pos = startPosition;
        pos.x = startPosition.x + offset;
        obstacleTransform.position = pos;
    }
}
