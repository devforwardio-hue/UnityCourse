using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Obsticle : MonoBehaviour
{
    public float maxDistance = 1.0f; // may not need
    public float minDistance = 5.0f;
    public float moveSpeed = 1.0f;
    public Transform obstacleTransform;
    public Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obstacleTransform = GetComponent<Transform>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        obstacleTransform.position = new Vector3(Mathf.PingPong(moveSpeed * Time.time, minDistance), obstacleTransform.position.y, obstacleTransform.position.z);
        Debug.Log(startPosition);
    }
    public void ObstacleMovement()
    {

        //Vector3.Distance is used calculate a distance between two set positions such as setting a if within set Vector3.Distance then something happens
        //Vector3.Normalize is used to keep a constant value such as moving diagonally with a value of 1 to match x and z planes 

    }
}
