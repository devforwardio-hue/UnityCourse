using UnityEngine;

public class ComponentKey : MonoBehaviour
{
    public GameManager gameManager;
    bool canInteract = false;

    private void Update()
    {
        EnableKey();
    }

    void EnableKey()
    {
        if (gameManager == null)
        {
            return;
        }

        if (!canInteract) 
        { 
            return; 
        }
        if (Input.GetButtonDown("e") && canInteract)
        {
            if (gameObject.CompareTag("Key"))
            { 
            gameManager.hasKey = true;
            gameManager.numberOfKeys += 1;
            Destroy(gameObject);
            }
            
        }

    }

}
