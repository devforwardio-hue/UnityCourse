using UnityEngine;

public class DoorSystem : MonoBehaviour
{

  public float openSpeed = 180f;
  public float openDegrees = -90f;

  public bool isOpen = false;
  public bool unlocked = true;
  public bool inRange = false;

  public GameObject interactUI;
  public CanvasGroup interactGroup;
  public Transform doorAnchor;

  Quaternion closedRot;
  Quaternion openRot;
  public GameObject doorCol;

  private void Awake()
  {
    interactUI = GameObject.Find("InteractUI");
    if (interactUI != null)
    {
      interactGroup = interactUI.GetComponent<CanvasGroup>();
      if (interactGroup != null)
      {
        interactGroup.alpha = 0f;
      }
    }
  }


    void Start()
    {
        closedRot = doorAnchor.rotation;
        openRot = closedRot * Quaternion.Euler(0f, openDegrees, 0f);//we check the math, to get the differnce, from our initial rotation. 
  
    }

    
    void Update()
    {
      HandleInteract();
      HandleRotate();
    }


  private void OnTriggerEnter(Collider obj)
  {
    bool isPlayer = obj.CompareTag("Player");

    if (!isPlayer) return;
    //never read further

    inRange = true;
    interactGroup.alpha = 1f;    
  }

  private void OnTriggerExit(Collider obj)
  {
    bool isPlayer = obj.CompareTag("Player");

    if (!isPlayer) return;
    //never read further

    inRange = false;
    interactGroup.alpha = 0f;
  }

  void HandleInteract()
  {
    if (!inRange) return;
    bool interactPress = Input.GetKeyDown(KeyCode.F);

    if (interactPress)
    {
      if (!unlocked) return;
      isOpen = !isOpen;
    }
  }

  void HandleRotate()
  {
    Quaternion target = isOpen ? openRot : closedRot;/// why do?
    float remaining = Quaternion.Angle(doorAnchor.rotation, target);
    bool isMoving = remaining > 0.1f; // safety check
    doorCol.SetActive(!isMoving);
    doorAnchor.rotation = Quaternion.RotateTowards(doorAnchor.rotation, target, openSpeed * Time.deltaTime);
  }
}
