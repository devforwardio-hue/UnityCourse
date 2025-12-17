using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Lock Settings")]
    public string requiredKeyID = "";   // Key required to unlock (empty = no key)
    public bool isLocked = true;        // Starts locked?

    [Header("Door Movement")]
    public float openSpeed = 2f;        // How fast door opens/closes
    public float openAngle = 90f;       // How far door swings

    [Header("Auto Close Settings")]
    public float autoCloseDelay = 3f;   // Seconds before door closes

    private bool isOpen = false;        // Is door currently open?
    private bool isMoving = false;      // Prevents spam input

    private Quaternion closedRotation;  // Door closed rotation
    private Quaternion targetRotation;  // Door open rotation

    private float closeTimer = 0f;      // Auto-close countdown

    private void Start()
    {
        // Save the closed rotation
        closedRotation = transform.rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        // Only react to the player (or children of player)
        if (!IsPlayer(other)) return;

        // Enter key required for ALL doors
        if (!Input.GetKeyDown(KeyCode.Return)) return;

        // Prevent re-triggering while moving or already open
        if (isMoving || isOpen) return;

        // Attempt to get Inventory
        Inventory inv = other.GetComponentInParent<Inventory>();

        // ---------- LOCK CHECK ----------
        if (isLocked && requiredKeyID != "")
        {
            if (inv == null || !inv.HasKey(requiredKeyID))
                return;

            inv.RemoveKey(requiredKeyID);
            isLocked = false; // Permanently unlocked
        }

        // ---------- DETERMINE OPEN DIRECTION ----------
        int direction = 1;

        // FRONT trigger → open AWAY from player
        if (other.gameObject.name.Contains("Front"))
        {
            direction = -1;
        }

        // BACK trigger → open TOWARD player
        if (other.gameObject.name.Contains("Back"))
        {
            direction = 1;
        }

        // Calculate open rotation
        targetRotation = Quaternion.Euler(
            transform.eulerAngles + new Vector3(0, openAngle * direction, 0)
        );

        // Open door
        isOpen = true;
        isMoving = true;
        closeTimer = autoCloseDelay;
    }

    private void Update()
    {
        // ---------- OPENING ----------
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * openSpeed
            );

            // Check if door is almost fully open
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f)
            {
                isMoving = false;
            }

            // Start auto-close countdown
            closeTimer -= Time.deltaTime;

            if (closeTimer <= 0f)
            {
                isOpen = false;
                isMoving = true;
            }
        }
        // ---------- CLOSING ----------
        else if (isMoving)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                closedRotation,
                Time.deltaTime * openSpeed
            );

            // Stop movement when fully closed
            if (Quaternion.Angle(transform.rotation, closedRotation) < 0.5f)
            {
                isMoving = false;
            }
        }
    }

    private bool IsPlayer(Collider col)
    {
        Transform t = col.transform;

        while (t != null)
        {
            if (t.CompareTag("Player"))
                return true;

            t = t.parent;
        }

        return false;
    }
}
