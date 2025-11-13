using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;

public class WallSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnRandomWallArray;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRandomWall();
    }
    public void SpawnRandomWall()
    {
        if (spawnRandomWallArray == null || spawnRandomWallArray.Length == 0)
        {
            Debug.LogError("spawnRandomWallArray is null or empty.");
            return;
        }

        {
            int randomIndex = UnityEngine.Random.Range(0, 13);

            GameObject selectedWallPrefab = spawnRandomWallArray[randomIndex];

            GameObject instantiatedWallObject = Instantiate(selectedWallPrefab, transform.position, Quaternion.identity);

            instantiatedWallObject.SetActive(true);
        }
    }
}

