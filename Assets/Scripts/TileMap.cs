using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public Player Player;
    public Camera MainCamera;
    public static Vector2 Center = new Vector2(0f, 0f);
    public static float RightOne = 1 * GameParameters.playerSpeed;
    public static float RightTwo = 2 * GameParameters.playerSpeed;
    public static float RightThree = 3 * GameParameters.playerSpeed;
    public static float RightFour = 4 * GameParameters.playerSpeed;
    public static float RightFive = 5 * GameParameters.playerSpeed;
    public static float LeftOne = -1 * GameParameters.playerSpeed;
    public static float LeftTwo = -2 * GameParameters.playerSpeed;
    public static float LeftThree = -3 * GameParameters.playerSpeed;
    public static float LeftFour = -4 * GameParameters.playerSpeed;
    public static float LeftFive = -5 * GameParameters.playerSpeed;

    
    // translate this to screen
    // after every movement => call function in movement class to lock to screen points
    // x positions by 1.5 units until +/- 7.5
    // y positions will update
    

    public Vector2 FindClosestTile()
    {
        Vector3 PlayerPosition = Player.transform.position;
        if (PlayerPosition.x >= 6.8)
        {
            return new Vector2(RightFive, FindClosestTileYPosition());
        }
        else if (PlayerPosition.x >= 5.3)
        {
            return new Vector2(RightFour, FindClosestTileYPosition());
        }
        else if (PlayerPosition.x >= 3.8)
        {
            return new Vector2(RightThree, FindClosestTileYPosition());
        }
        else if (PlayerPosition.x >= 2.3)
        {
            return new Vector2(RightTwo, FindClosestTileYPosition());
        }
        else if (PlayerPosition.x >= 0.8)
        {
            return new Vector2(RightOne, FindClosestTileYPosition());
        }
        else if (PlayerPosition.x >= -0.7)
        {
            return new Vector2(Center.x, FindClosestTileYPosition());
        }
        else if (PlayerPosition.x >= -2.2)
        {
            return new Vector2(LeftOne, FindClosestTileYPosition());
        }
        else if (PlayerPosition.x >= -3.7)
        {
            return new Vector2(LeftTwo, FindClosestTileYPosition());
        }
        else if (PlayerPosition.x >= -5.2)
        {
            return new Vector2(LeftThree, FindClosestTileYPosition());
        }
        else if (PlayerPosition.x >= -6.7)
        {
            return new Vector2(LeftFour, FindClosestTileYPosition());
        }
        else
        {
            return new Vector2(LeftFive, FindClosestTileYPosition());
        }
    }

    private float FindClosestTileYPosition()
    {
        float yPosition = Player.GetPositionY();
        int yMovesUp = Mathf.RoundToInt(yPosition / 1.5f);
        return yMovesUp * 1.5f;
    }
    public static float FindClosestTileYPosition(float yPosition)
    {
        int yMovesUp = Mathf.RoundToInt(yPosition / 1.5f);
        return yMovesUp * 1.5f;
    }
}
