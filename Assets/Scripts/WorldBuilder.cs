using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    
    public GameObject OneTileGrassPrefab;
    public GameObject TwoTileGrassPrefab;
    public GameObject ThreeTileRoadPrefab;
    public GameObject ThreeTileRiverPrefab;
    public GameObject Player;
    public GameObject Obstacle;

    private GameObject lastInstantiatedPrefab;
    private Vector3 spawnPosition =  new Vector3(0f, 0f, 1f);
    
    void Start()
    {
        GenerateOnStart();
    }
    
    void FixedUpdate()
    {
        if (BuildNeeded())
        {
            ExpandMap();
        }
    }

    private void ExpandMap()
    {
        switch (lastInstantiatedPrefab.tag)
        {
            case "OneTile" or "TwoTile": 
                ExpandMapAfterSafety();
                break;
            case "ThreeTileRiver" or "ThreeTileRoad":
                ExpandMapAfterDanger(); 
                break;
        }
    }

    private void ExpandMapAfterDanger()
    {
        if (Random.Range(0f, 1f) < 0.1f)
        {
            ExpandMapAfterSafety();
        }
        else 
        {
            InstantiateTile(Random.Range(0f, 1f) < 0.75f ? OneTileGrassPrefab : TwoTileGrassPrefab);
        }
    }

    private void ExpandMapAfterSafety()
    {
        InstantiateTile(Random.Range(0f, 1f) < 0.5f ? ThreeTileRiverPrefab : ThreeTileRoadPrefab);
    }

    private bool BuildNeeded()
    {
        return lastInstantiatedPrefab.transform.position.y - Player.transform.position.y < 8; // If player is approaching upper bounds of map generation
    }

    private void GenerateOnStart()
    {
        InstantiateBeginningTileSequence();
        BottomFillGrass();
    }

    private void BottomFillGrass()
    {
        for (int i = -3; i >= -9; i -= 3)
        {
            Instantiate(TwoTileGrassPrefab, new Vector3(0f, (float)i, 1f), Quaternion.identity);
        }
    }

    private void InstantiateBeginningTileSequence()
    {
        InstantiateTile(OneTileGrassPrefab);
        InstantiateTile(ThreeTileRoadPrefab);
        InstantiateTile(OneTileGrassPrefab);
        InstantiateTile(ThreeTileRiverPrefab);
        InstantiateTile(TwoTileGrassPrefab);
    }

    private void InstantiateTile(GameObject prefab)
    {
        if (lastInstantiatedPrefab != null) // If it is NOT the first tile placed, adjust its y position
        {
            switch (lastInstantiatedPrefab.tag)
            {
                case "OneTile":
                    spawnPosition.y += 1.5f;
                    break;
                case "TwoTile":
                    spawnPosition.y += 3f;
                    break;
                case "ThreeTileRiver" or "ThreeTileRoad":
                    spawnPosition.y += 4.5f;
                    break;
            }
        } 
        lastInstantiatedPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
    

    

    private void InstantiateObstacle(float y)
    {
        float yPosition = TileMap.FindClosestTileYPosition(y);
    }
    
}
