using UnityEngine;

public class Buff_Movement : MonoBehaviour
{
  public float currentTime = 0;// where to put?
  public float maxTime = 0;
  public float powerValue = 0; // no longer need, but future ?
  public bool isActive = false;
  public PlayerMovementOld playerMovementOld;


  private void Awake()
  {
    playerMovementOld = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementOld>();
  }
  void Start()
    {
      if(playerMovementOld != null)
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
        //Debug.Log("Move Timer start");
        currentTime = Time.time;

        if (currentTime > maxTime)
        {
        playerMovementOld.moveSpeed = playerMovementOld.defaultSpeed;
        isActive = false;
        //Debug.Log("Move Time is out");
        }
        else 
        { 
        
        }
      }
    }
    
    
}
