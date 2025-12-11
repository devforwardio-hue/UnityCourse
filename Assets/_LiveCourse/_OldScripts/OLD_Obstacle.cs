using UnityEngine;

public class OLD_Obstacle : MonoBehaviour
{
    public enum Axis { X, Y, Z }

    public bool move = true;
    public Axis moveAxis = Axis.Y;
    public float moveDistance = 1f;   
    public float moveSpeed = 1f;      


    public bool rotate = false;
    public Axis rotateAxis = Axis.Y;
    public float rotateAngle = 90f;   
    public float rotateSpeed = 1f;     

    private Vector3 _startPos;
    private Quaternion _startRot;

    void Awake()
    {
        _startPos = transform.localPosition;
        _startRot = transform.localRotation;
    }

    void Update()
    {
        if (move) MoveObject();
        if (rotate) RotateObject();
    }

    private void MoveObject()
    {
       
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        Vector3 axis = AxisVector(moveAxis);
        transform.localPosition = _startPos + axis * offset;
    }

    private void RotateObject()
    {
        float angle = Mathf.Sin(Time.time * rotateSpeed) * rotateAngle;
        Vector3 axis = AxisVector(rotateAxis);
        transform.localRotation = _startRot * Quaternion.AngleAxis(angle, axis);
    }

    private static Vector3 AxisVector(Axis axis)
    {
        switch (axis)
        {
            case Axis.X: return Vector3.right;
            case Axis.Y: return Vector3.up;
            default: return Vector3.forward;
        }
    }
}
