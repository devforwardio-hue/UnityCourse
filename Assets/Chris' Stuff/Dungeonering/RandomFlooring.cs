using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;

public class RandomFlooring : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnRandomFloorArray;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnRandomFloor();
    }
    public void SpawnRandomFloor()
    {
        if (spawnRandomFloorArray == null || spawnRandomFloorArray.Length == 0)
        {
            Debug.LogError("spawnRandomFloorArray is null or empty.");
            return;
        }

        {
            int randomIndex = UnityEngine.Random.Range(0, 7);

            GameObject selectedFloorPrefab = spawnRandomFloorArray[randomIndex];

            GameObject instantiatedFloorObject = Instantiate(selectedFloorPrefab, transform.position, Quaternion.identity);

            instantiatedFloorObject.SetActive(true);
        }
    }
}

