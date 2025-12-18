using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class KeySystem : MonoBehaviour
{
  public GameObject keyItem;
  public Vector3 defaultKeyPos;
  public Vector3 pressedKeyPos;
  public DoorSystem doorSystem;

  public GameObject interactCanvas;
  private CanvasGroup interactGroup;
  public bool inRange;

  // Start is called once before the first execution of Update after the MonoBehaviour is created

  private void Awake()
  {
    defaultKeyPos = keyItem.transform.localPosition;
    pressedKeyPos = new (0f, 0.75f, 0f);

    interactGroup = interactCanvas.GetComponent<CanvasGroup>();
    if (interactGroup != null)
    {
      interactGroup.alpha = 0f;
    }
  }
  void Update()
  {
    HandleInteract();
  }

  private void FixedUpdate()
  {
    
  }

  private void OnTriggerEnter(Collider collision)
  {
    if (!collision.gameObject.CompareTag("Player")) return;

    inRange = true;
    interactGroup.alpha = 1f;

  }

  private void OnTriggerExit(Collider collision)
  {
    if (!collision.gameObject.CompareTag("Player")) return;

    inRange = false;
    interactGroup.alpha = 0f;

  }

  void HandleInteract()
  {
    if (!inRange || doorSystem.isOpen) return;
    if (Input.GetKeyDown(KeyCode.F))
    {
      doorSystem.unlocked = !doorSystem.unlocked;
      keyItem.transform.localPosition = doorSystem.unlocked ? pressedKeyPos : defaultKeyPos;
    }
  }
}
