using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyID;

    private void OnTriggerEnter(Collider other)
    {
        TryPickup(other);
    }

    private void OnTriggerStay(Collider other)
    {
        TryPickup(other);
    }

    private void TryPickup(Collider col)
    {
        Transform t = col.transform;
        Inventory inv = null;
        while(t != null)
        {
            if(t.CompareTag("Player"))
            {
                inv = t.GetComponentInParent<Inventory>();
                break;
            }
            t = t.parent;
        }

        if(inv != null)
        {
            inv.AddKey(keyID);
            Destroy(gameObject);
        }
    }
}
