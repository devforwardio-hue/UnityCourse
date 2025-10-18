using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Buff_Scale : MonoBehaviour
{
    public float currentTime = 0;// where to put?
    public float maxTime = 10f;
    public float powerValue = 0; // no longer need, but future ?
    public bool isActive = false;
    public Transform playerTransform;
    Vector3 defaultScale = new(1, 1, 1);


    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Start()
    {
        if (playerTransform != null)
        {
            Debug.Log("Transform found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartTimer();

    }

    public void StartTimer()
    {
        if (isActive)
        {
            Debug.Log("Scale timer start");
            currentTime = Time.time;

            if (currentTime >= maxTime)
            {
                playerTransform.localScale = defaultScale;
                isActive = false;
                Debug.Log("Jump Time is out");
            }
            else
            {

            }
        }
    }

}
