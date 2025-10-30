using UnityEngine;
using NUnit.Framework.Internal;
using UnityEngine.UIElements;
using Unity.Mathematics;
public class AdvancedObstacle : MonoBehaviour
{


    public Transform rotationAxis;
    public Vector3 startPosition;

    public Transform direction;
    public float maxHeight = 5;
    public float minHeight = 2;
    public float speed = 1;
    //public quaternion rotate1;
    private int count = 0;
    public enum ObstacleType
    {
        X, Y, Z
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        rotationAxis = GetComponent<Transform>();
        direction = GetComponent<Transform>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ObstacleRotation();
    }


    public void ObstacleRotation()
    {

        rotationAxis.Rotate(speed, speed, speed);

        //don't know what the fuck this does yet 👇🏽
        //rotationAxis.rotation += Quaternion.Quaternion(speed, speed, speed,speed);
        switch(count)
        {
            case 0:

                direction.position += new Vector3(0f, 1, 0f) * speed * Time.deltaTime;

                if (direction.position.y >= maxHeight)
                {
                    Debug.Log("going up");
                    count = 1;
                }
                break;
            case 1:

                direction.position -= new Vector3(0f, 1, 0f) * speed * Time.deltaTime ;
                if (direction.position.y <= minHeight)
                {   
                    Debug.Log("going down");
                    count = 0;
                }
                break;
                

        }
        
    }




}
