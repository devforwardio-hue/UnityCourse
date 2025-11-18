using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // This keeps the player across scenes
    }
}
