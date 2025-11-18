using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyID; // Unique name or number for each key

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inv = other.GetComponent<Inventory>();
            if (inv != null)
            {
                inv.AddKey(keyID);
                Destroy(gameObject); // Remove key from the world
            }
        }
    }
}
