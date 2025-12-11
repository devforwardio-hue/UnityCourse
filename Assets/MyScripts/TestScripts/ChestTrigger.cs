using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    public Chest chest;
    private Inventory playerInventory;
    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            playerInventory = other.GetComponentInParent<Inventory>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            playerInventory = null;
        }
    }

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.Return))
        {
            chest.TryInteract(playerInventory);
        }
    }
}
