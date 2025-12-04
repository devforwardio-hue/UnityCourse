using UnityEngine;

public class cameraOrbit : MonoBehaviour
{

    public Transform target;
    public float rotateSensitivityX = 100f;
    public Vector3 defaultPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitObject();
    }

    void OrbitObject()
    {
        bool rmb = Input.GetMouseButton(1);
        if (!rmb) return;
        if (target == null)
            if (rmb)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        
        
    }
}
