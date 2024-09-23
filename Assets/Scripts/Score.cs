using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Player Player;
    private int currentScore = 0;
    private int lastYPos = 0;
    public Text Text;
    void FixedUpdate()
    {
        Text.text = GetNewScore();
        if (Player.GetIsOnPowerUp())
        {
            Powerup();
        }
    }

    public void Powerup()
    {
        currentScore += 25;
        GetNewScore();
    }

    private string GetNewScore()
    {
        if (Player.GetPositionY() > lastYPos)
        {
            int amountMoved = ((int)Player.GetPositionY() - lastYPos);
            currentScore += amountMoved;
        }

        lastYPos = (int)Player.GetPositionY();
        return "SCORE: " + currentScore;
    }
}
