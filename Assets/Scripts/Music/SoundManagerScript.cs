using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
   public AudioSource audioSrc;
   public AudioClip footsteps;

     void Start()
    {
   
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSrc.Play();
    }
    public void StopSound()
    {
        audioSrc.Stop();
    }
}
