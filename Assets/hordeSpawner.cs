using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hordeSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject hordePrefab;
    public Transform[] spawnPoints = new Transform[5]; // Assign 5 in the Inspector

    private List<GameObject> activeHordes = new List<GameObject>();

    void Start()
    {
        SpawnAllHordes();
    }

    void Update()
    {
        // Clean up destroyed hordes from the list
        activeHordes.RemoveAll(horde => horde == null);

        // If all hordes are destroyed, spawn a new batch
        if (activeHordes.Count == 0)
        {
            SpawnAllHordes();
        }
    }

    void SpawnAllHordes()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject newHorde = Instantiate(hordePrefab, spawnPoint.position, spawnPoint.rotation);
            activeHordes.Add(newHorde);
        }
    }
}
