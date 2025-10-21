using UnityEngine;


  public enum PowerupType
  {
    Movement,
    Jump,
    Scale
  }
public class LivePowerup : MonoBehaviour
{
  public PowerupType type;
  public float powerValue = 100f;
  public float maxTime = 10f;
  public GameObject buffManagerObject;
  private Buff_Movement buff_movementScript;
  private Buff_Jump buff_jumpScript;
  private Buff_Scale buff_scaleScript;


  // Start is called once before the first execution of Update after the MonoBehaviour is created
  
  void Start()
  {
    buffManagerObject = GameObject.Find("BuffManager");
    if(buffManagerObject != null)
    {
      buff_movementScript = buffManagerObject.GetComponent<Buff_Movement>();
      buff_jumpScript = buffManagerObject.GetComponent<Buff_Jump>();
      buff_scaleScript = buffManagerObject.GetComponent<Buff_Scale>();
    }
  }

  // Update is called once per frame
  void Update()
  {
    
  }

  private void OnTriggerEnter(Collider col)
  {
    if (col.CompareTag("Player"))
    {




      switch (type)
      {
        case PowerupType.Movement:
        {
            
            PlayerMovementOld playerMovement = col.GetComponent<PlayerMovementOld>();
          if (playerMovement != null)
          {
            float defaultSpeed = playerMovement.defaultSpeed;
            playerMovement.moveSpeed = defaultSpeed + powerValue;
          }

            if (buff_movementScript != null)
            {
              buff_movementScript.maxTime = maxTime + Time.time;
              buff_movementScript.isActive = true;
            }

            Destroy(this.gameObject);
          break;
        }

        case PowerupType.Jump:
        {
            JumpingOld jumpingScript = col.GetComponent<JumpingOld>();
            if (jumpingScript != null)
            {
              float defaultForce = jumpingScript.defaultForce;
              jumpingScript.jumpForce = defaultForce + powerValue;
            }

            if (buff_jumpScript != null)
            {
              buff_jumpScript.maxTime = maxTime + Time.time;
              buff_jumpScript.isActive = true;
            }
            Debug.Log("Jump");
            Destroy(this.gameObject);
          break;
        }

        case PowerupType.Scale:
                    {
                        //in crease the players scale on x, y, and z, to t
                        //he powerup value.
                        //apply the buff_scaleScript management details
public class Buff_Scale : MonoBehaviour
    {
        public float currentTime = 0;// where to put?
        public float maxTime = 0;
        public float defaultscale = 1; // no longer need, but future ?
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
                Debug.Log("Scale Timer start");
                currentTime = Time.time;

                if (currentTime > maxTime)
                {
                    playerTransform.localScale = new Vector3(defaultscale, defaultscale, defaultscale);
                    isActive = false;
                    Debug.Log("Scale Time is out");
                }
                else
                {

                }
            }
        }


    }



}
  }



}
