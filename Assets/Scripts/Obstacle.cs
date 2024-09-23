using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite ObstacleImage;
    public Sprite SecondaryImage;
    private int frameCount = 0;
    bool onSecondSprite = false;
    
    
    void Update()
    {
        AnimateIdleMovement();
    }

    private void AnimateIdleMovement()
    {
        if (frameCount == 100)
        {
            //swaps between sprites to show animation
            if (onSecondSprite == false)
            {
                SpriteRenderer.sprite = ObstacleImage;
                onSecondSprite = true;
            }
            else if (onSecondSprite == true)
            {
                SpriteRenderer.sprite = SecondaryImage;
                onSecondSprite = false;
            }

            frameCount = 0;
        }
        else
            frameCount++;
    }
}
