using UnityEngine;

public class Door : MonoBehaviour
{
    public string requiredKeyID;
    public bool isLocked = true;
    public bool isOpen = false;
    public float openSpeed = 2f;
    public float openAngle = -90f; // negative to swing left away
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inv = other.GetComponent<Inventory>();

            if (isLocked)
            {
                if (inv != null && inv.HasKey(requiredKeyID))
                {
                    // Display UI message here: "Press Enter to unlock door"
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        isLocked = false;
                        inv.RemoveKey(requiredKeyID);
                        Debug.Log("Door unlocked!");
                    }
                }
                else
                {
                    // Display message: "Door is locked, need a key"
                }
            }
            else if (!isOpen)
            {
                // Door already unlocked, allow opening
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    isOpen = true;
                    Debug.Log("Door opened!");
                }
            }
        }
    }

    private void Update()
    {
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
        }
    }
}
