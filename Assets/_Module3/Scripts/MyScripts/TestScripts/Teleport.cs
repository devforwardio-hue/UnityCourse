using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Teleport : MonoBehaviour
{
    public string sceneToLoad;
    public string spawnPointName;

    private bool isTeleporting = false;

    private void OnTriggerEnter(Collider other)
    {
        // Get the root object that represents the player (handles child colliders)
        GameObject root = other.attachedRigidbody ? other.attachedRigidbody.gameObject : other.gameObject;

        if (!root.CompareTag("Player")) return;

        if (isTeleporting) return;
        isTeleporting = true;

        Debug.Log($"TELEPORTER: Player entered. Will set spawn to '{spawnPointName}' and load '{sceneToLoad}'.");

        if (SpawnManager.Instance == null)
        {
            Debug.LogWarning("TELEPORTER: SpawnManager.Instance is NULL. Trying to find one in scene...");
            SpawnManager.FindOrCreateInstance();
        }

        if (SpawnManager.Instance != null)
        {
            SpawnManager.Instance.SetSpawnPoint(spawnPointName);
            Debug.Log($"TELEPORTER: SpawnManager now has spawnPointName='{SpawnManager.Instance.spawnPointName}'");
        }
        else
        {
            Debug.LogError("TELEPORTER: SpawnManager still null. Aborting teleport.");
            isTeleporting = false;
            return;
        }

        // Use async load to avoid tight timing issues
        StartCoroutine(LoadSceneAsync(sceneToLoad));
    }

    private IEnumerator LoadSceneAsync(string name)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(name);
        op.allowSceneActivation = true;
        while (!op.isDone)
        {
            yield return null;
        }
    }
}
