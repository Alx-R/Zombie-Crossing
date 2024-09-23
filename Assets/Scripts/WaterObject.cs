using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterObject : TimedLifespan
{
    
    private float speed;
    private bool startsOnLeftSide;

    public override void Start()
    {
        SecondsOnScreen = GameParameters.WaterObjectLifespanSeconds;
        base.Start();
        speed = Random.Range(GameParameters.WaterObjectMinSpeed, GameParameters.WaterObjectMaxSpeed);
        startsOnLeftSide = transform.position.x < 0;
    }

    private void FixedUpdate()
    {
        if (startsOnLeftSide)
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
        else
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
    }
}
