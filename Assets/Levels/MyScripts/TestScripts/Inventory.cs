using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> keys = new List<string>();

    // Add a key and refresh the UI
    public void AddKey(string keyID)
    {
        if (!keys.Contains(keyID))
        {
            keys.Add(keyID);
            Debug.Log("Picked up key: " + keyID);

            // Refresh the UI whenever a key is added
            InventoryUI ui = FindFirstObjectByType<InventoryUI>();
            if (ui != null)
            {
                ui.RefreshKeys();
            }
        }
    }

    // Check if inventory contains a key
    public bool HasKey(string keyID)
    {
        return keys.Contains(keyID);
    }

    // Remove a key and refresh the UI
    public void RemoveKey(string keyID)
    {
        if (keys.Contains(keyID))
        {
            keys.Remove(keyID);
            Debug.Log("Used key: " + keyID);

            // Refresh the UI whenever a key is removed
            InventoryUI ui = FindFirstObjectByType<InventoryUI>();
            if (ui != null)
            {
                ui.RefreshKeys();
            }
        }
    }
}
