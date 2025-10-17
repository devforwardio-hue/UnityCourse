using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Buff_Scale : MonoBehaviour
{
    //public float maxTime = 10f;
    public Vector3 deafaultScale = new Vector3(1f,1f,1f);
    public Vector3 maxScale = new Vector3(3f, 3f, 3f);
    public bool isActive = false;

    //make sure it returns to the default scale, which is always the default object scale of 1.
    private void Awake()
    {
        Debug.Log(isActive);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
