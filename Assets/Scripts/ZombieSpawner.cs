using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class ZombieSpawner : MonoBehaviour
{
    public List<GameObject> ZombiePrefabs;
    
    private int numLanes = GameParameters.NumZombieLanes;
    private bool countingDown = false;

    private void FixedUpdate()
    {
        if (countingDown)
        {
            return;
        }
        StartCoroutine(ZombieSpawnCountdown());
    }

    private IEnumerator ZombieSpawnCountdown()
    {
        countingDown = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(GameParameters.ZombieMinSpawnIntervalSeconds,
            GameParameters.ZombieMaxSpawnIntervalSeconds));
        SpawnZombieInLanes();
        countingDown = false;
    }

    private void SpawnZombieInLanes()
    {
        Vector3 spawnPosition = new Vector3(-10f, this.transform.position.y, 0f);
        for (int i = 0; i < numLanes; i++)
        {
            spawnPosition.x *= -1;
            Instantiate(RandomZombiePrefab(), spawnPosition, Quaternion.identity);
            spawnPosition.y += 1.5f;
        }
    }

    private GameObject RandomZombiePrefab()
    {
        return ZombiePrefabs[UnityEngine.Random.Range(0, 3)];
    }
}
