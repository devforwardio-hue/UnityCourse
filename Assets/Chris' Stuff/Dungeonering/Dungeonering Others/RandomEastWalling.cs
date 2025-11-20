using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;

public class RandomEastWalling : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnRandomEastWallArray;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRandomWall();
    }
    public void SpawnRandomWall()
    {
        if (spawnRandomEastWallArray == null || spawnRandomEastWallArray.Length == 0)
        {
            Debug.LogError("spawnRandomEastWallArray is null or empty.");
            return;
        }

        {
            int randomIndex = UnityEngine.Random.Range(0, 8);

            GameObject selectedWallPrefab = spawnRandomEastWallArray[randomIndex];

            GameObject instantiatedEastWallObject = Instantiate(selectedWallPrefab, transform.position, Quaternion.identity);

            instantiatedEastWallObject.SetActive(true);
        }
    }
}

