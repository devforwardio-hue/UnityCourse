using UnityEngine;

public enum ObstacleSpinType { X, Y, Z }

public class AdvancedObstacle : MonoBehaviour
{
    public ObstacleSpinType type;
    public float moveSpeed = 180f;

    void Update()
    {
        float rotating = moveSpeed * Time.deltaTime;

        switch (type)
        {
            case ObstacleSpinType.X:
                transform.Rotate(rotating, 0f, 0f);
                break;
            case ObstacleSpinType.Y:
                transform.Rotate(0f, rotating, 0f);
                break;
            case ObstacleSpinType.Z:
                transform.Rotate(0f, 0f, rotating);
                break;
        }
    }
}
