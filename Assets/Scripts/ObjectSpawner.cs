using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    
    public List<GameObject> ObstaclePrefabs;
    public List<GameObject> PowerupPrefabs;
    public GameObject startSignPrefab;
    public GameObject tile;
    private bool tileIsOccupied = false;

    private void Start()
    {
        SpawnObstacle();
        SpawnPowerup();
    }

    private void SpawnObstacle()
    {
        int chanceOfObstacle = UnityEngine.Random.Range(0, 2);
        Vector3 tilePosition = transform.position;
        if (tilePosition.y <= 0)
        {
            if (tilePosition.y == 0)
            {
                Vector3 spawnPosition = new Vector3(-4, this.transform.position.y, 0f);
                Instantiate(startSignPrefab, spawnPosition, Quaternion.identity);
            }
        }
        else if (chanceOfObstacle == 1)
        {
            tileIsOccupied = true;
            float xValue = UnityEngine.Random.Range(-8, 8);
            Vector3 spawnPosition = new Vector3(xValue, this.transform.position.y, 0f);
            Instantiate(RandomObstaclePrefab(), spawnPosition, Quaternion.identity);
        }
    }
    
    private GameObject RandomObstaclePrefab()
    {
        return ObstaclePrefabs[UnityEngine.Random.Range(0, 2)];
    }
    
    private void SpawnPowerup()
    {
        int chanceOfPowerup = UnityEngine.Random.Range(0, 5);
        Vector3 tilePosition = transform.position;
        if (tilePosition.y <= 0)
        {
            return;
        }
        else if ((chanceOfPowerup == 1) && (!tileIsOccupied))
        {
            float xValue = UnityEngine.Random.Range(-8, 8);
            Vector3 spawnPosition = new Vector3(xValue, this.transform.position.y, 0f);
            Instantiate(RandomPowerupPrefab(), spawnPosition, Quaternion.identity);
        }
    }
    
    private GameObject RandomPowerupPrefab()
    {
        return PowerupPrefabs[UnityEngine.Random.Range(0, 2)];
    }
}
