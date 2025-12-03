using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door Settings")]
    public string requiredKeyID = ""; // leave empty if no key required
    public bool isLocked = true;      // true if door starts locked
    private bool isOpen = false;      // tracks if door has been opened
    public float openSpeed = 2f;      // speed of door swing
    public float openAngle = -90f;    // negative = left swing

    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        // Store the door's starting rotation
        initialRotation = transform.rotation;

        // Calculate the rotation when fully open
        targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    private void OnTriggerStay(Collider other)
    {
        // Only interact with objects tagged as "Player"
        if (!other.CompareTag("Player")) return;

        // Try to get the Inventory component from the player
        Inventory inv = other.GetComponent<Inventory>();

        // --------- LOGIC FOR ENTER PRESS ---------
        // Wait for the Enter key
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Case 1: Door is locked and requires a key
            if (isLocked && requiredKeyID != "")
            {
                if (inv != null && inv.HasKey(requiredKeyID))
                {
                    // Use the key and unlock the door
                    inv.RemoveKey(requiredKeyID);
                    isLocked = false;      // permanently unlock
                }
                else
                {
                    // Player does not have the required key, cannot open
                    return;
                }
            }

            // Case 2: Door is unlocked OR player used the key
            isOpen = true; // open the door
        }
    }

    private void Update()
    {
        // Smoothly rotate the door toward the open position if open
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
        }
    }
}
