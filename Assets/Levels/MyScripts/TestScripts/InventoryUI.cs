using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("UI")]
    public GameObject inventoryPanel;

    [Header("Inventory")]
    public Inventory playerInventory;

    [Header("Key UI")]
    public Transform keyListContainer;
    public GameObject keySlotTemplate;

    [System.Serializable]
    public class KeyIconData
    {
        public string keyID;
        public Sprite icon;
    }

    [Header("Key Icons")]
    public List<KeyIconData> keyIcons;

    private readonly List<GameObject> activeKeySlots = new();

    void Start()
    {
        inventoryPanel.SetActive(false);
        Time.timeScale = 1f;
        RefreshKeys();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        bool isOpening = !inventoryPanel.activeSelf;
        inventoryPanel.SetActive(isOpening);
        Time.timeScale = isOpening ? 0f : 1f;
    }

    public void RefreshKeys()
    {
        foreach (GameObject slot in activeKeySlots)
        {
            Destroy(slot);
        }
        activeKeySlots.Clear();

        List<string> sortedKeys = new(playerInventory.keys);
        sortedKeys.Sort();

        foreach (string keyID in sortedKeys)
        {
            GameObject newSlot = Instantiate(keySlotTemplate, keyListContainer);
            newSlot.SetActive(true);

            Transform iconTransform = newSlot.transform.Find("KeyIcon");
            Transform textTransform = newSlot.transform.Find("KeyNameText");

            if (textTransform != null)
            {
                textTransform.GetComponent<TextMeshProUGUI>().text = keyID;
            }

            if (iconTransform != null)
            {
                Image img = iconTransform.GetComponent<Image>();
                img.sprite = GetIconForKey(keyID);
                img.enabled = img.sprite != null;
            }

            activeKeySlots.Add(newSlot);
        }
    }

    Sprite GetIconForKey(string keyID)
    {
        foreach (KeyIconData data in keyIcons)
        {
            if (data.keyID == keyID)
                return data.icon;
        }
        return null;
    }
}
