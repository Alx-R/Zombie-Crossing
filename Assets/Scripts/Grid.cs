using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public static class Grid
{
    private static float gridHeight = 1.5f;
    private static float gridWidth = 1;

    public static Vector3 SnapToGrid(Vector3 currentPosition)
    {
        
        // figure out the closest grid center
        
        // how many cells wide and tall do we have
        Vector3 gridInScreenSpace = Camera.main.WorldToScreenPoint(new Vector3(gridWidth, gridHeight, 0f));
        
        float cellWidthInScreenCoords = gridInScreenSpace.x;
        //Debug.Log("cell width in screen coords: " + cellWidthInScreenCoords);
        
        float cellHeightInScreenCoords = gridInScreenSpace.y;
        //Debug.Log("cell height in screen coords: " + cellHeightInScreenCoords);

        int numberOfCellsWide = Screen.width / (int)cellWidthInScreenCoords;
        int numberOfCellsTall = Screen.height / (int)cellHeightInScreenCoords;
        
        //Debug.Log(numberOfCellsWide + " Cells wide and " + numberOfCellsTall + " cells tall");

        float minimumDistance = float.MaxValue;
        Vector3 bestPosition = new Vector3();

        for (int cellsAcross = 0; cellsAcross < numberOfCellsWide; cellsAcross++)
        {
            for (int cellsUp = 0; cellsUp < numberOfCellsTall; cellsUp++)
            {
                Vector2 cellUpperRightPositionInScreenCoords = new Vector2((cellsAcross + 1) * cellWidthInScreenCoords,
                    (cellsUp + 1) * cellHeightInScreenCoords);
                Vector2 cellCenterPositionInScreenCoords = new Vector2(
                    cellUpperRightPositionInScreenCoords.x - cellWidthInScreenCoords / 2,
                    cellUpperRightPositionInScreenCoords.y - cellHeightInScreenCoords / 2);
                Vector3 cellCenterInWorldCoords = Camera.main.ScreenToWorldPoint(new Vector3(
                    cellCenterPositionInScreenCoords.x,
                    cellCenterPositionInScreenCoords.y, 0f));
                float distance = Mathf.Abs(Vector3.Distance(cellCenterInWorldCoords, currentPosition));
                if (distance < minimumDistance)
                {
                    minimumDistance = distance;
                    bestPosition = cellCenterInWorldCoords;
                } 
                Debug.DrawLine(Camera.main.ScreenToWorldPoint(cellUpperRightPositionInScreenCoords), Camera.main.ScreenToWorldPoint(new Vector3(cellUpperRightPositionInScreenCoords.x + cellWidthInScreenCoords, cellUpperRightPositionInScreenCoords.y + cellHeightInScreenCoords)), Color.red);
            }
        }
        
        // put us there
        return bestPosition;
    }

}
