using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Player Player;
    private bool isMoving;
    private Vector2 originalPostion, targetPosition;
    private float TimeToMove = 0.1f;
    private bool playerFacingRight = true;
    private static Vector2 lastDirectionTravelled;
    public TileMap TileMap;

    void Update()
    {
        if (!Player.GetIsAbleToMove())
        {
            return;
        }

        Vector2 direction;

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !isMoving)
        {
            direction = new Vector2(0, GameParameters.playerSpeed);
            StartCoroutine(MovePlayer(direction));
            lastDirectionTravelled = direction;
        }

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !isMoving)
        {
            direction = new Vector2(0, -GameParameters.playerSpeed);
            if (Math.Abs(Player.transform.position.y - (-4.5f)) < 0.5f)
            {
                return;
            }
            StartCoroutine(MovePlayer(direction));
            lastDirectionTravelled = direction;
        }
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !isMoving &&
            (this.transform.position.x > -7.999))
        {
            direction = new Vector2(-GameParameters.playerSpeed, 0);
            playerFacingRight = false;
            StartCoroutine(MovePlayer(direction));
            lastDirectionTravelled = direction;
        }

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !isMoving &&
            (this.transform.position.x < 7.999))
        {
            direction = new Vector2(GameParameters.playerSpeed, 0);
            playerFacingRight = true;
            StartCoroutine(MovePlayer(direction));
            lastDirectionTravelled = direction;
        }
    }

    private IEnumerator MovePlayer(Vector2 direction)
    {
        gameObject.transform.parent = null;
        
        isMoving = true;

        float elapsedTime = 0;

        originalPostion = transform.position;
        targetPosition = originalPostion + direction;

        while (elapsedTime < TimeToMove)
        {
            transform.position = Vector2.Lerp(originalPostion, targetPosition, (elapsedTime / TimeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        isMoving = false;
        
        //Grid.SnapToGrid(Player.transform.position);
        //SnapToNearestTile();
    }

    private void SnapToNearestTile()
    {
        if (transform.position.x - TileMap.FindClosestTile().x >= 0.05)
        {
            Vector2 incorrectPosition = transform.position;
            transform.position = Vector2.Lerp(incorrectPosition, TileMap.FindClosestTile(), 0.1f);
            // print("Snap to nearest Tile Called");
        }
        if (transform.position.y - TileMap.FindClosestTile().y >= 0.05)
        {
            Vector2 incorrectPosition = transform.position;
            transform.position = Vector2.Lerp(incorrectPosition, TileMap.FindClosestTile(), 0.1f);
            // print("Snap to nearest Tile Called");
        }
    }

    public bool GetIsMoving()
    {
        return isMoving;
    }

    public bool GetPlayerFacingRight()
    {
        return playerFacingRight;
    }
    
    public void MoveBackFromObstacle()
    {
        if (GetLastDirectionTravelled().x == 0)
        {
            if (GetLastDirectionTravelled().y > 0)
                StartCoroutine(MovePlayer(new Vector2(0, -GameParameters.playerSpeed)));
            else
                StartCoroutine(MovePlayer(new Vector2(0, GameParameters.playerSpeed)));
        }
        else
        {
            if (GetLastDirectionTravelled().x > 0)
                StartCoroutine(MovePlayer(new Vector2(-GameParameters.playerSpeed, 0)));
            else
                StartCoroutine(MovePlayer(new Vector2(GameParameters.playerSpeed, 0)));
        }
    }
    private static Vector2 GetLastDirectionTravelled()
    {
        return lastDirectionTravelled;
    }


}