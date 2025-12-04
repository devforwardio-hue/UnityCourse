using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceDown : MonoBehaviour
{
    //[Tooltip("Name of the scene to load when the player touches this door.")]
    public string sceneName = "DungeonEntrance";

    //[Tooltip("Tag used to identify the player GameObject.")]
    public string playerTag = "Player";

    // Prevent double-loading if the player collides multiple times quickly.
    private bool isLoading = false;

    // Use this when the door collider is a trigger (recommended).
    private void OnTriggerEnter(Collider other)
    {
        TryLoadScene(other.gameObject);
    }
    private void TryLoadScene(GameObject obj)
    {
        if (isLoading) return;
        if (obj == null) return;

        // Check tag to ensure it's the player (configurable in inspector).
        if (obj.CompareTag(playerTag))
        {
            isLoading = true;
            Debug.Log($"Loading scene '{sceneName}' because player touched {name}.");
            SceneManager.LoadScene(sceneName);
        }
    }
}
