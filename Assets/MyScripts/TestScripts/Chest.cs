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
    public GameObject keyObject;

    [Header("Lid Settings")]
    public Transform lid;
    public float openSpeed = 2f;
    public float openAngle = -70f;

    public bool isOpen = false;

    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        initialRotation = lid.localRotation;
        targetRotation = Quaternion.Euler(lid.localEulerAngles + new Vector3(openAngle, 0, 0));
    }

    public void TryInteract(Inventory inv)
    {
        if (inv == null) return;

        // Chest locked?
        if (isLocked)
        {
            if (inv.HasKey(requiredKeyID))
            {
                isLocked = false;
                inv.RemoveKey(requiredKeyID);
                Debug.Log("Chest unlocked!");
            }
            else
            {
                Debug.Log("Chest is locked.");
                return;
            }
        }

        // Open chest
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Chest opened!");

            if (!keyGiven)
            {
                inv.AddKey(chestKeyID);
                keyGiven = true;
                Debug.Log("Player received key: " + chestKeyID);

                if (keyObject != null)
                    Destroy(keyObject);
            }
        }
    }

    private void Update()
    {
        if (isOpen)
        {
            lid.localRotation = Quaternion.Slerp(
                lid.localRotation, targetRotation, Time.deltaTime * openSpeed);
        }
    }
}
