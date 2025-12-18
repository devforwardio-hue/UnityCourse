using UnityEngine;

public class DoorSystem : MonoBehaviour
{
  public float openSpeed = 180f;
  public float openDegrees = -90f;
  public float keyID = 123f;

  public bool isOpen = false;
  public bool unlocked = false;
  public bool inRange = false;

  private GameObject interactUI;
  private CanvasGroup interactGroup; 
  public GameObject doorCol;
  
  public Transform doorAnchor;

  Quaternion closedRot;
  Quaternion openRot;

  void Awake()
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
    else
    {
      Debug.Log("No InteractUI Found");
    }
  }

  void Start()
  {
      closedRot = doorAnchor.rotation;
      openRot = closedRot * Quaternion.Euler(0f, openDegrees, 0f);
  }

  void Update()
  {
     HandleInteract();
  }

  private void FixedUpdate()
  {
    HandleRotate();
  }

  private void OnTriggerEnter(Collider collision)
  {
    if (!collision.gameObject.CompareTag("Player")) return;

    inRange = true;
    if (interactGroup != null)
    {
      interactGroup.alpha = 1f;
      interactGroup.interactable = true;
      interactGroup.blocksRaycasts = true;
    }
  }

  private void OnTriggerExit(Collider collision)
  {
    if (!collision.gameObject.CompareTag("Player")) return;

    inRange = false;
    if (interactGroup != null)
    {
      interactGroup.alpha = 0f;
      interactGroup.interactable = false;
      interactGroup.blocksRaycasts = false;
    }
  }

  void HandleInteract()
  {
    if (!inRange) return;
    if (Input.GetKeyDown(KeyCode.F))
    {
      if (!unlocked) return;
      isOpen = !isOpen;
    }
  }

  void HandleRotate()
  {
    
    Quaternion target = isOpen ? openRot : closedRot;

    float remaining = Quaternion.Angle(doorAnchor.rotation, target);
    bool isMoving = remaining > 0.1f; //unlikely to ever see a perfect 0

    doorCol.SetActive(!isMoving); 

    doorAnchor.rotation = Quaternion.RotateTowards(
        doorAnchor.rotation,
        target,
        openSpeed * Time.deltaTime
    );
  }
}
