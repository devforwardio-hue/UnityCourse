using UnityEngine;

public class ThreeCrystalKeyPickup : MonoBehaviour
{
    public enum CrystalKeyType
    {
        RedCrystal, BlueCrystal, GreenCrystal
    }

    //public enum CrystalDoorType
    //{
    //    RedCrystalDoor, BlueCrystalDoor, GreenCrystalDoor, ColoredCrystalDoor
    //}
    public GameObject RedCrystalDoor, BlueCrystalDoor, GreenCrystalDoor, ColoredCrystalDoor;

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
        RedCrystalDoor = GameObject.FindGameObjectWithTag("RedCrystalDoor");
        BlueCrystalDoor = GameObject.FindGameObjectWithTag("BlueCrystalDoor");
        GreenCrystalDoor = GameObject.FindGameObjectWithTag("GreenCrystalDoor");
        ColoredCrystalDoor = GameObject.FindGameObjectWithTag("ColoredCrystalDoor");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            switch (this.gameObject.name)
            {
                case "RedCrystalKey":
                    Destroy(this.gameObject);
                    Destroy(RedCrystalDoor);
                    break;
                case "GreenCrystalKey":
                    Destroy(this.gameObject);
                    Destroy(GreenCrystalDoor);
                    Destroy(ColoredCrystalDoor);
                    break;
                case "BlueCrystalKey":
                    Destroy(this.gameObject);
                    Destroy(BlueCrystalDoor);
                    break;
            }
        }
    }

}
