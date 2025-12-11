using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    public float Spin = 1f;
    public float RotationSpeed = 100f;
    public Transform axisRotation;
    public Transform direction;
    public float maxHeight = 5f;
    public float minHeight = 1f;
    private int count = 0;
    private Vector3 spinDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        axisRotation = GetComponent<Transform>();
        direction = GetComponent<Transform>();

        spinDirection = new Vector3(
            Random.Range(-Spin, Spin),
            Random.Range(-Spin, Spin),
            Random.Range(-Spin, Spin)
        );
    }

    // Update is called once per frame
    void Update()
    {
        spinDirection += new Vector3(
            Random.Range(-0.5f, 0.5f),
            Random.Range(-0.5f, 0.5f),
            Random.Range(-0.5f, 0.5f)
        ) * Time.deltaTime;

        spinDirection = Vector3.ClampMagnitude(spinDirection, Spin);

        ObstacleMovement();
    }
    public void ObstacleMovement()
    {
        axisRotation.Rotate(spinDirection * Time.deltaTime * RotationSpeed);

        switch(count)
        {
            case 0:

                direction.position += new Vector3(0f, 1, 0f) * Spin * Time.deltaTime;

                if (direction.position.y >= maxHeight)
                {
                    count = 1;
                }
                break;
            
            case 1:

                direction.position -= new Vector3(0f, 1, 0f) * Spin * Time.deltaTime;

                if (direction.position.y <= minHeight)
                {
                    count = 0;
                }
                break;
        }
    }
}
