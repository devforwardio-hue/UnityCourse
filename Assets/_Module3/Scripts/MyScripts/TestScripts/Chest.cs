using UnityEngine;

public class Chest : MonoBehaviour
{
    [Header("Key Required To Unlock Chest")]
    public string requiredKeyID;
    public bool isLocked = true;

    [Header("Key Inside Chest")]
    public string chestKeyID;
    public bool keyGiven = false;

    [Header("Optional 3D Key Object")]
    public GameObject keyObject;  // Drag your in-scene key object here

    [Header("Lid Settings")]
    public Transform lid;
    public float openSpeed = 2f;
    public float openAngle = -70f;

    private bool isOpen = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        initialRotation = lid.localRotation;
        targetRotation = Quaternion.Euler(
            lid.localEulerAngles + new Vector3(openAngle, 0, 0)
        );
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Inventory inv = other.GetComponent<Inventory>();

        // ===============================
        // LOCKED
        // ===============================
        if (isLocked)
        {
            if (inv != null && inv.HasKey(requiredKeyID))
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    isLocked = false;
                    inv.RemoveKey(requiredKeyID);
                    Debug.Log("Chest unlocked!");
                }
            }

            return;
        }

        // ===============================
        // UNLOCKED BUT CLOSED
        // ===============================
        if (!isOpen)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                isOpen = true;
                Debug.Log("Chest opened!");

                // Give key to player
                if (!keyGiven && inv != null)
                {
                    inv.AddKey(chestKeyID);
                    keyGiven = true;

                    Debug.Log("Player received key: " + chestKeyID);

                    // Destroy or hide the key object
                    if (keyObject != null)
                        Destroy(keyObject);
                }
            }
        }
    }

    private void Update()
    {
        if (isOpen)
        {
            lid.localRotation = Quaternion.Slerp(
                lid.localRotation,
                targetRotation,
                Time.deltaTime * openSpeed
            );
        }
    }
}
