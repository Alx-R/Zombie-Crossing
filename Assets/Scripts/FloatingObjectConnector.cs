using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjectConnector : MonoBehaviour
{
    public FloatingObject FloatingObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (FloatingObject.getlockPlayerBool() == false)
        {
            if (other.CompareTag("Player"))
            {
            FloatingObject.LockPlayer();
        }
    }
    }
}
