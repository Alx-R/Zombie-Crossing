using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloatingObject : MonoBehaviour
{
    public FloatingObject floatingObject;
    public Player Player;
    public Movement Movement;
    public SpriteRenderer UpperBox;
    public SpriteRenderer LowerBox;
    private float spawnPoint;
    private float movementSpeed;
    private bool lockPlayerBool;

    private void Start()
    {
        int randomNumber = Random.Range(0, 2);
        if (randomNumber == 0)
        {
            spawnPoint = -10f;
            movementSpeed = 0.02f;
        }
        else
        {
            spawnPoint = 10f;
            movementSpeed = -0.02f;
        }
        ResetLocation();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * movementSpeed);
    }

    private void Update()
    {
        if (transform.position.x > 10 || transform.position.x < -10)
            ResetLocation();
        if (lockPlayerBool && Player.getIsDead() == false)
        {
            Player.transform.position = transform.position;
            PlayerOnRaft();
        }
    }


    private void ResetLocation()
    {
        transform.position = new Vector3(spawnPoint, transform.position.y, 0);
        lockPlayerBool = false;
    }

    public void LockPlayer()
    {
        lockPlayerBool = true;
        Movement.enabled = false;
        
    }

    public bool getlockPlayerBool()
    {
        return lockPlayerBool;
    }

    private void PlayerOnRaft()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            lockPlayerBool = false;
            Player.transform.position = new Vector3(Player.transform.position.x, UpperBox.transform.position.y, 0);
            Movement.enabled = true;
        }/*
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            lockPlayerBool = false;
            Player.transform.position = new Vector3(Player.transform.position.x, LowerBox.transform.position.y, 0);
            Movement.enabled = true;
        }*/
    }
    

}