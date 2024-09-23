using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceFromLowerHorde : MonoBehaviour
{
    public Player Player;
    public Horde LowerHorde;
    private int distanceFromHorde = 0;
    public Text Text;
    void FixedUpdate()
    {
        Text.text = GetNewDistance();
    }

    private string GetNewDistance()
    {
        if ((int)Player.GetPositionY() - (int)LowerHorde.GetPositionY() < 0)
        {
            distanceFromHorde = 0;
        }
        else
        {
            distanceFromHorde = (int)Player.GetPositionY() - (int)LowerHorde.GetPositionY();
        }
        return "DISTANCE FROM HORDE: " + distanceFromHorde;
    }
}
