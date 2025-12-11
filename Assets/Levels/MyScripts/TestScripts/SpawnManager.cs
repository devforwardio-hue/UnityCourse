using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [HideInInspector] public string spawnPointName = "";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("SpawnManager: created and DontDestroyOnLoad");
        }
        else if (Instance != this)
        {
            Debug.Log("SpawnManager: duplicate found - destroying this instance");
            Destroy(gameObject);
        }
    }

    // Use this setter to track writes and to avoid accidental empty overwrites
    public void SetSpawnPoint(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogWarning("SpawnManager: Attempted to set empty spawn name — ignoring.");
            return;
        }

        Debug.Log($"SpawnManager: SetSpawnPoint called. Old='{spawnPointName}' New='{name}'");
        spawnPointName = name;
    }

    // Helper to find existing SpawnManager in scene or create one if none exist
    public static void FindOrCreateInstance()
    {
        if (Instance != null) return;

        SpawnManager existing = FindFirstObjectByType<SpawnManager>();
        if (existing != null)
        {
            Instance = existing;
            Debug.Log("SpawnManager: Found existing instance in scene and set Instance.");
            return;
        }

        // Optionally create a GameObject if none found
        GameObject go = new GameObject("SpawnManager");
        Instance = go.AddComponent<SpawnManager>();
        DontDestroyOnLoad(go);
        Debug.Log("SpawnManager: No instance found, created new persistent SpawnManager.");
    }
}
