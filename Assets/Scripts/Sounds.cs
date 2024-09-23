using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip DeadSound;

    public void PlayDeadSound()
    {
        AudioSource.PlayOneShot(DeadSound);
    }
    
}
