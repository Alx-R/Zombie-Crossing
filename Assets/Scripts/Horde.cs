using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Horde : MonoBehaviour
{
    public Player Player;
    public Horde horde;

    private void FixedUpdate()
    {
        transform.position = new Vector3(0, transform.position.y + GameParameters.hordeSpeed, 0);
        Teleport();
    }
    
    public float GetPositionY()
    {
        return transform.position.y;
    }

    public void Teleport()
    {
        if (Player.GetPositionY() - GetPositionY() >= 30)
        {
            transform.position = new Vector3(0, Player.GetPositionY() - 30, 0);
        }
    }
}
