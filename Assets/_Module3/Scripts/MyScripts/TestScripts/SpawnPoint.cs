using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

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
            rb.position = spawnPoint.transform.position;
            rb.rotation = spawnPoint.transform.rotation;

            SceneManager.MoveGameObjectToScene(gameObject, scene);

            Debug.Log($"SpawnPointSetter: Moved player to spawn '{spawnName}' in scene {scene.name}");

            SpawnManager.Instance.spawnPointName = "";
        }
        else
        {
            Debug.LogWarning($"SpawnPointSetter: Could not find spawn '{spawnName}' in scene {scene.name}");
        }
    }
}
