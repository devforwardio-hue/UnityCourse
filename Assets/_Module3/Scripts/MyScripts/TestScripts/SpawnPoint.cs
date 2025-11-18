using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SpawnManager.Instance == null) return;

        string spawnName = SpawnManager.Instance.spawnPointName;
        if (string.IsNullOrEmpty(spawnName)) 
        {
            Debug.Log("SpawnPointSetter: spawnName empty on scene load.");
            return;
        }

        Debug.Log($"SpawnPointSetter: Scene loaded: {scene.name}. Looking for '{spawnName}'.");
        GameObject spawnPoint = GameObject.Find(spawnName);

        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position;
            transform.rotation = spawnPoint.transform.rotation;

            // Move player into the loaded scene so it shows under that scene's hierarchy
            SceneManager.MoveGameObjectToScene(gameObject, scene);

            Debug.Log($"SpawnPointSetter: Moved player to spawn '{spawnName}' in scene {scene.name}");
            // Clear spawn to avoid accidental reuse
            SpawnManager.Instance.spawnPointName = "";
        }
        else
        {
            Debug.LogWarning($"SpawnPointSetter: Could not find spawn '{spawnName}' in scene {scene.name}");
        }
    }
}
