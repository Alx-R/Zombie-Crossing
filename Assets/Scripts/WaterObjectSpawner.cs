using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterObjectSpawner : MonoBehaviour
{
    
    public List<GameObject> WaterObjectPrefabs;
    
    private int numLanes = GameParameters.NumZombieLanes;
    private bool countingDown = false;

    private void FixedUpdate()
    {
        if (countingDown)
        {
            return;
        }
        StartCoroutine(WaterSpawnCountdown());
    }

    private IEnumerator WaterSpawnCountdown()
    {
        countingDown = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(GameParameters.WaterObjectMinSpawnIntervalSeconds,
            GameParameters.WaterObjectMaxSpawnIntervalSeconds));
        SpawnWaterObjectInLanes();
        countingDown = false;
    }

    private void SpawnWaterObjectInLanes()
    {
        Vector3 spawnPosition = new Vector3(-10f, this.transform.position.y, 0f);
        for (int i = 0; i < numLanes; i++)
        {
            spawnPosition.x *= -1;
            Instantiate(RandomWaterObjectPrefab(), spawnPosition, Quaternion.identity);
            spawnPosition.y += 1.5f;
        }
    }

    private GameObject RandomWaterObjectPrefab()
    {
        return WaterObjectPrefabs[UnityEngine.Random.Range(0, 3)];
    }
}
