using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door Settings")]
    public string requiredKeyID = ""; 
    public bool isLocked = true;      
    private bool isOpen = false;      
    public float openSpeed = 2f;      
    public float openAngle = -90f;    

    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    private void OnTriggerStay(Collider other)
    {
        if (!IsPlayer(other)) return;

        Inventory inv = other.GetComponentInParent<Inventory>();
        if (inv == null) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isLocked && requiredKeyID != "")
            {
                if (inv.HasKey(requiredKeyID))
                {
                    inv.RemoveKey(requiredKeyID);
                    isLocked = false;
                }
                else
                {
                    return; // Locked and no key
                }
            }

            isOpen = true;
        }
    }

    private void Update()
    {
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
        }
    }

    private bool IsPlayer(Collider col)
    {
        Transform t = col.transform;
        while(t != null)
        {
            if(t.CompareTag("Player")) return true;
            t = t.parent;
        }
        return false;
    }
}
