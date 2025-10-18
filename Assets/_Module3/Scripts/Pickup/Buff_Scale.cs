using UnityEngine;
using UnityEngine.UIElements;

public class Buff_Scale : MonoBehaviour
{
    public float currentTime = 0;// where to put?
    public float maxTime = 0;
    public float powerValue = 0; // no longer need, but future ?
    public bool isActive = false;
    public Transform playerTransform;
    public int defaultScale = 1;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Start()
    {
        if (playerTransform != null)
        {
            Debug.Log("Transform Found");
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
            Debug.Log("Transform Timer start");
            currentTime = Time.time;

            if (currentTime > maxTime)
            {
                //bringing player scale back to default

                playerTransform.localScale = new Vector3(defaultScale, defaultScale, defaultScale);
                isActive = false;
                Debug.Log("Transform Time is out");
            }
            else
            {

            }
        }
    }
}