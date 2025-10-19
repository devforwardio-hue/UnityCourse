using UnityEngine;
using UnityEngine.UIElements;

public class Buff_Scale : MonoBehaviour
{
  public float currentTime = 0;// where to put?
  public float maxTime = 0;
  public float powerValue = 0; // no longer need, but future ?
  public bool isActive = false;

  public ScaleOld scaleOld;
  //make sure it returns to the default scale, which is always the default object scale of 1.
  private void Awake()
  {
    scaleOld = GameObject.FindGameObjectWithTag("Player").GetComponent<ScaleOld>();
  }
  void Start()
  {
    if (scaleOld != null)
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
      //Debug.Log("Size Timer start");
      currentTime = Time.time;

      if (currentTime > maxTime)
      {
        // Smoothly return to default size instead of snapping
        scaleOld.TriggerGrowth(scaleOld.defaultSize);
        isActive = false;
        Debug.Log("Size Time is out");
      }
    }
  }
}
