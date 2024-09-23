using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite StandingStillSprite;
    public Sprite WalkingSprite1;
    public Sprite WalkingSprite2;
    public Sprite DeadSprite;
    public Movement Movement;
    public Sounds Sounds;
    private bool isDead = false;
    private bool isAbleToMove = true;
    private bool onPowerUp = false;
    private bool isOnWaterObject = false;
    public bool immortal = false;

    void Update()
    {
        FaceCorrectDirection();
        PreventMapEscape();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        if (Movement.GetIsMoving())
            StartCoroutine(AnimationCoroutine());
        else if (Movement.GetIsMoving() == false && isDead == false)
        {
            SpriteRenderer.sprite = StandingStillSprite;
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Horde") || other.CompareTag("Zombie"))
        {
            LoadGameOver();
        }

        if (other.CompareTag("Obstacle"))
        {
            Obstacle obstacleScript = other.GetComponent<Obstacle>();
            isAbleToMove = false;
            Movement.MoveBackFromObstacle();
        }
        
        
        if (other.CompareTag("PowerUp"))
        {
            onPowerUp = true;
        }
        if (other.CompareTag("WaterObject"))
        {
            isOnWaterObject = true;
            gameObject.transform.parent = other.gameObject.transform;
        }
    }
    

    public bool GetIsAbleToMove()
    {
        return isAbleToMove;
    }

    public bool GetIsOnPowerUp()
    {
        if (onPowerUp)
        {
            onPowerUp = false;
            return true;
        }
        return false;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            isAbleToMove = true;
        }

        if (other.CompareTag("WaterObject"))
        {
            isOnWaterObject = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ThreeTileRiver") && Movement.GetIsMoving() == false && isOnWaterObject == false)
        {
            LoadGameOver();
        }
    }

    public void LoadGameOver()
    {
        if (isDead == false && immortal == false)
        {
            isDead = true;
            GetComponent<Movement>().enabled = false;
            Sounds.PlayDeadSound();
            SpriteRenderer.sprite = DeadSprite;
            StartCoroutine(DeathCoroutine());
        }
    }
    
    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    public float GetPositionY()
    {
        return transform.position.y;
    }

    public void PreventMapEscape()
    {
        if (transform.position.x < -9 || transform.position.x > 9)
        {
            Movement.enabled = false;
            LoadGameOver();
        }
    }


    public void FaceCorrectDirection()
    {
        bool facingRight = Movement.GetPlayerFacingRight();
        if (facingRight == true)
            SpriteRenderer.flipX = false;
        else if (facingRight == false)
            SpriteRenderer.flipX = true;
    }

    public bool getIsDead()
    {
        return isDead;
    }

    IEnumerator AnimationCoroutine()
    {
        if (Movement.GetIsMoving() == true && isDead == false)
            SpriteRenderer.sprite = WalkingSprite1;
        yield return new WaitForSeconds(0.5f);
        if (Movement.GetIsMoving() == true && isDead == false)
            SpriteRenderer.sprite = WalkingSprite2;
        yield return new WaitForSeconds(0.5f);
    }
}
