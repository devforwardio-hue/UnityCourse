using UnityEngine;

public class KeySystem : MonoBehaviour
{

  public bool inRange = false;
  
  public GameObject keyItem;
  public Vector3 defaultKeyPos;
  public Vector3 pressKeyPos;

  public GameObject interactUI;
  public CanvasGroup interactGroup;
  public DoorSystem activeDoor;//actually incorrect atm.



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
    defaultKeyPos = keyItem.transform.localPosition;
    pressKeyPos = new (0f, 0.75f, 0f);

  }


  void Update()
  {
    HandleInteract();
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
    if (!inRange || activeDoor.isOpen) return;
    bool interactPress = Input.GetKeyDown(KeyCode.F);
    
    if (interactPress )
    {
      activeDoor.unlocked = !activeDoor.unlocked;
      keyItem.transform.localPosition = activeDoor.unlocked ? pressKeyPos : defaultKeyPos;
    }
  }
}
