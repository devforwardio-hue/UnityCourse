using Unity.VisualScripting;
using UnityEngine;

public class ThreeCrystalKeyPickup : MonoBehaviour
{
    enum CrystalKeyType
    {
        RedCrystal, BlueCrystal, GreenCrystal
    }


    public GameObject RedCrystalDoors, BlueCrystalDoors, GreenCrystalDoors, ColoredCrystalDoors;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        RedCrystalDoors = GameObject.FindGameObjectWithTag("RedCrystalDoor");
        BlueCrystalDoors = GameObject.FindGameObjectWithTag("BlueCrystalDoor");
        GreenCrystalDoors = GameObject.FindGameObjectWithTag("GreenCrystalDoor");
        ColoredCrystalDoors = GameObject.FindGameObjectWithTag("ColoredCrystalDoor");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            switch (this.gameObject.name)
            {
                case "RedCrystalKey":
                    Destroy(this.gameObject);
                    Destroy(RedCrystalDoors);
                    Debug.Log("No Touch.");
                    break;
                case "GreenCrystalKey":
                    Destroy(this.gameObject);
                    Destroy(GreenCrystalDoors);
                    Destroy(ColoredCrystalDoors);
                    break;
                case "BlueCrystalKey":
                    Destroy(this.gameObject);
                    Destroy(BlueCrystalDoors);
                    break;
            }
        }
    }

}
