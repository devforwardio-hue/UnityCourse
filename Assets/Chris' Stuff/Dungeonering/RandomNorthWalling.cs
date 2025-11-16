using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;

public class RandomNorthWalling : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnRandomNorthWallArray;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRandomWall();
    }
    public void SpawnRandomWall()
    {
        if (spawnRandomNorthWallArray == null || spawnRandomNorthWallArray.Length == 0)
        {
            Debug.LogError("spawnRandomNorthWallArray is null or empty.");
            return;
        }

        {
            int randomIndex = UnityEngine.Random.Range(0, 13);

            GameObject selectedWallPrefab = spawnRandomNorthWallArray[randomIndex];

            GameObject instantiatedNorthWallObject = Instantiate(selectedWallPrefab, transform.position, Quaternion.identity);

            instantiatedNorthWallObject.SetActive(true);
        }
    }
}

