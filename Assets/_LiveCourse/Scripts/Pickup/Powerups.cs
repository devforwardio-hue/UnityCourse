using UnityEngine;


  public enum PowerupType
  {
    Movement,
    Jump,
    Scale
  }
public class Powerup : MonoBehaviour
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
            //in crease the players scale on x, y, and z, to the powerup value.
            Transform playerTransform = col.GetComponent<Transform>();
            if (playerTransform != null)
            {
            playerTransform.localScale = new Vector3(powerValue, powerValue, powerValue);
            }
            if (buff_scaleScript != null)
            {
                buff_scaleScript.maxTime = maxTime + Time.time;
                buff_scaleScript.isActive = true;
            }
                        //apply the buff_scaleScript management details
                        Debug.Log("Scale");
            Destroy(this.gameObject);
            
            break;
        }
        default:
        {
            Debug.Log("You forgot to set the powerup type");
          break;
        }
      }

      
    }
  }



}
