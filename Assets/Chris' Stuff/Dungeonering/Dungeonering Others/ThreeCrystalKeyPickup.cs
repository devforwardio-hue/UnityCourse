using UnityEngine;

public class ThreeCrystalKeyPickup : MonoBehaviour
{
    enum CrystalKeyType
    {
        RCK,
        BCK,
        GCK
    }

    public GameObject 
        RedCrystalDoorSet, 
        BlueCrystalDoorSet,
        GreenCrystalDoorSet,
        ColoredCrystalDoorSet;
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
        RedCrystalDoorSet = GameObject.FindGameObjectWithTag("RedCrystalDoor");
        BlueCrystalDoorSet = GameObject.FindGameObjectWithTag("BlueCrystalDoor");
        GreenCrystalDoorSet = GameObject.FindGameObjectWithTag("GreenCrystalDoor");
        ColoredCrystalDoorSet = GameObject.FindGameObjectWithTag("ColoredCrystalDoor");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            switch (this.gameObject.name)
            {
                case "RCK":
                    Destroy(this.gameObject);
                    Destroy(RedCrystalDoorSet);
                    break;
                case "BCK":
                    Destroy(this.gameObject);
                    Destroy(BlueCrystalDoorSet);
                    break;
                case "GCK":
                    Destroy(this.gameObject);
                    Destroy(GreenCrystalDoorSet);
                    Destroy(ColoredCrystalDoorSet);
                    break;
            }
        }
    }
}
