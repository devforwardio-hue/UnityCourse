using UnityEngine;

public class AdvanceObstacle : MonoBehaviour
{
    public enum ObstacleType
    {
        X, Y, Z
    }

    public ObstacleType type;
    public float moveDistance = 5f;
    public float moveSpeed = 1f; // degrees per second applied to each axis
    public Transform obstacleTransform;
    public Vector3 startPosition;

    // incremental rotation angles (in degrees) applied since start
    public float xrotate = 0f;
    public float yrotate = 0f;
    public float zrotate = 0f;

    // store starting rotation as Euler angles
    private Vector3 startrotate;

    void Start()
    {
        // Ensure we have the transform reference
        obstacleTransform = GetComponent<Transform>();

        // capture starting position and rotation (euler angles)
        startPosition = obstacleTransform.position;
        startrotate = obstacleTransform.eulerAngles;

        // Do not overwrite configured rotation-speed/offset fields here.
        // xrotate, yrotate, zrotate remain as incremental angles (default 0).
    }

    void Update()
    {
        Obstaclerotate();
    }

    public void Obstaclerotate()
    {
        // Increment rotation angles by moveSpeed degrees per second
        float delta = moveSpeed * Time.deltaTime;
        xrotate += delta;
        yrotate += delta;
        zrotate += delta;

        // Keep angles within 0..360 to avoid large values
        xrotate = xrotate % 360f;
        yrotate = yrotate % -360f;
        zrotate = zrotate % 360f;

        // Apply rotation relative to the starting rotation
        Vector3 newEuler = startrotate + new Vector3(xrotate, yrotate, zrotate);
        obstacleTransform.eulerAngles = newEuler;
    }
}
