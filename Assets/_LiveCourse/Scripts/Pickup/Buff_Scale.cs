using UnityEngine;

public class Buff_Scale : MonoBehaviour

{
  public float currentTime = 0;// where to put?
    public float maxTime = 0;
    public float defaultScale = 1f;
    public bool isActive = false;
    public Transform playerTransform;
    

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Start()
    {
        if (playerTransform != null)
        {
            Debug.Log("Player Found");
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
            //Debug.Log("Scale Timer start");
            currentTime = Time.time;

            if (currentTime > maxTime)
            {
                playerTransform.localScale = new Vector3(defaultScale, defaultScale, defaultScale);
                isActive = false;
                //Debug.Log("Scale Time is out");
            }
            else
            {

            }
        }
    }


}
