using UnityEngine;

public class AIMadeMover : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float moveDistance = 5f; // max distance before switching direction

    [Header("Rotation Settings")]
    public float rotateSpeed = 100f;

    [Header("Runtime Info (Read Only)")]
    [SerializeField] private string currentMoveDirection = "X+";
    [SerializeField] private string currentRotateAxis = "Y";

    private Vector3 moveAxis;
    private Vector3 rotateAxis;
    private int direction = 1;
    private float distanceTraveled = 0f;
    private float totalRotation = 0f;

    // Bounds
    private readonly float minX = -5f, maxX = 5f;
    private readonly float minY = 1f, maxY = 5f;
    private readonly float minZ = -3f, maxZ = 10f;

    void Start()
    {
        PickNewMoveAxis();
        PickNewRotateAxis();
    }

    void Update()
    {
        MoveObject();
        RotateObject();
    }

    void MoveObject()
    {
        float moveStep = moveSpeed * Time.deltaTime * direction;
        Vector3 newPosition = transform.position + (moveAxis * moveStep);

        // Check bounds and reverse direction if hitting a limit
        if (newPosition.x < minX)
        {
            newPosition.x = minX;
            if (moveAxis == Vector3.right) direction = 1;
            PickNewMoveAxis();
        }
        else if (newPosition.x > maxX)
        {
            newPosition.x = maxX;
            if (moveAxis == Vector3.right) direction = -1;
            PickNewMoveAxis();
        }

        if (newPosition.y < minY)
        {
            newPosition.y = minY;
            if (moveAxis == Vector3.up) direction = 1;
            PickNewMoveAxis();
        }
        else if (newPosition.y > maxY)
        {
            newPosition.y = maxY;
            if (moveAxis == Vector3.up) direction = -1;
            PickNewMoveAxis();
        }

        if (newPosition.z < minZ)
        {
            newPosition.z = minZ;
            if (moveAxis == Vector3.forward) direction = 1;
            PickNewMoveAxis();
        }
        else if (newPosition.z > maxZ)
        {
            newPosition.z = maxZ;
            if (moveAxis == Vector3.forward) direction = -1;
            PickNewMoveAxis();
        }

        transform.position = newPosition;
        distanceTraveled += Mathf.Abs(moveStep);

        // After traveling set distance, pick a new random axis
        if (distanceTraveled >= moveDistance)
        {
            distanceTraveled = 0f;
            PickNewMoveAxis();
        }
    }

    void RotateObject()
    {
        float rot = rotateSpeed * Time.deltaTime;
        totalRotation += Mathf.Abs(rot);

        transform.Rotate(rotateAxis * rot);

        // Pick new rotation axis after a full 360° rotation
        if (totalRotation >= 360f)
        {
            totalRotation = 0f;
            PickNewRotateAxis();
            rotateSpeed = Random.Range(80f, 150f);
        }
    }

    void PickNewMoveAxis()
    {
        int randomAxis = Random.Range(0, 3);
        direction = Random.value > 0.5f ? 1 : -1;

        switch (randomAxis)
        {
            case 0:
                moveAxis = Vector3.right;
                currentMoveDirection = direction > 0 ? "X+" : "X-";
                break;
            case 1:
                moveAxis = Vector3.up;
                currentMoveDirection = direction > 0 ? "Y+" : "Y-";
                break;
            case 2:
                moveAxis = Vector3.forward;
                currentMoveDirection = direction > 0 ? "Z+" : "Z-";
                break;
        }

        moveSpeed = Random.Range(2f, 6f);
    }

    void PickNewRotateAxis()
    {
        int randomAxis = Random.Range(0, 3);
        switch (randomAxis)
        {
            case 0:
                rotateAxis = Vector3.right;
                currentRotateAxis = "X";
                break;
            case 1:
                rotateAxis = Vector3.up;
                currentRotateAxis = "Y";
                break;
            case 2:
                rotateAxis = Vector3.forward;
                currentRotateAxis = "Z";
                break;
        }
    }
}
