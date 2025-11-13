using Unity.VisualScripting;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    enum KeyColor
    {
        RedKey, GreenKey, BlueKey
    }

    public GameObject RedDoor, GreenDoor, BlueDoor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Awake()
    {
        RedDoor = GameObject.FindGameObjectWithTag("RedDoor");
        GreenDoor = GameObject.FindGameObjectWithTag("GreenDoor");
        BlueDoor = GameObject.FindGameObjectWithTag("BlueDoor");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            switch (this.gameObject.name)
            {
                case "RedKey":
                    Destroy(this.gameObject);
                    Destroy(RedDoor);
                    break;
                case "GreenKey":
                    Destroy(this.gameObject);
                    Destroy(GreenDoor);
                    break;
                case "BlueKey":
                    Destroy(this.gameObject);
                    Destroy(BlueDoor);
                    break;
            }
        }
    }
}
