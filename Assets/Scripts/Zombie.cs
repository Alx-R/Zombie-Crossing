using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Zombie : TimedLifespan
{

    private float speed;
    private bool startsOnLeftSide;
    public SpriteRenderer SpriteRenderer;
    public Sprite lurch;
    public Sprite stand;
    private int frameCount = 0;
    private bool onStand;
    
    public override void Start()
    {
        SecondsOnScreen = GameParameters.ZombieMaxLifespanSeconds;
        base.Start();
        speed = Random.Range(GameParameters.ZombieMinSpeed, GameParameters.ZombieMaxSpeed);
        startsOnLeftSide = transform.position.x < 0;
    }

    private void FixedUpdate()
    {
        if (startsOnLeftSide)
        {
            SpriteRenderer.flipX = false;
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
        else
        {
            SpriteRenderer.flipX = true;
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
    }
    
    void Update()
    {
        AnimateMovement();
    }

    private void AnimateMovement()
    {
        if (frameCount == 70)
        {
            //swaps between sprites to show animated walking 
            if (onStand == false)
            {
                SpriteRenderer.sprite = stand;
                onStand = true;
            }
            else if (onStand == true)
            {
                SpriteRenderer.sprite = lurch;
                onStand = false;
            }

            frameCount = 0;
        }
        else
            frameCount++;

    }
}
