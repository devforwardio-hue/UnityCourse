using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool canInteract = false;
    public bool hasKey = false;
    public float numberOfKeys = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void KeysNeeded()
    {
        Debug.Log(numberOfKeys);
        if (hasKey && numberOfKeys == 2)
        {
            Debug.Log(numberOfKeys);
        }
    }
}
