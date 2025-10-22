using UnityEngine;

public class Buff_Jump : MonoBehaviour
{
  public float currentTime = 0;// where to put?
  public float maxTime = 0;
  public float powerValue = 0; // no longer need, but future ?
  public bool isActive = false;
  public JumpingOld jumpingOld;


  private void Awake()
  {
    jumpingOld = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpingOld>();
  }
  void Start()
  {
    if (jumpingOld != null)
    {
      Debug.Log("Jump Found");
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
      Debug.Log("Jump Timer start");
      currentTime = Time.time;

      if (currentTime > maxTime)
      {
        jumpingOld.jumpForce = jumpingOld.defaultForce;
        isActive = false;
        Debug.Log("Jump Time is out");
      }
      else
      {

      }
    }
  }
}
