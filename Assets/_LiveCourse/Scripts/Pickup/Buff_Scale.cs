using System;
using UnityEngine;

public class Buff_Scale : MonoBehaviour
{
    public float currentTime = 0;
    public float maxTime = 0;
    public float defaultScale = 1;
    public bool isActive = false;
    public Transform playerTransform;

    public Buff_Scale()
    {
    }

    private void Awake()
  {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
  void Start()
  {
        if (playerTransform != null)
        {
            Debug.Log("Transform found");
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

            Debug.Log("Scale Timer start");
            currentTime = Time.time;
            if (currentTime > maxTime)
            {
                playerTransform.localScale = new Vector3(defaultScale, defaultScale, defaultScale);
                isActive = false;
                Debug.Log("Scale Time is out");
            }
            else
            {

            }
        }
    }
}
