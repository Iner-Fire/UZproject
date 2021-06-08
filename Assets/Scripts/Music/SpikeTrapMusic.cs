using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapMusic : MonoBehaviour
{
    AudioSource audioSrc;
    public AudioClip spiketrap;
    int isPlayed = 0;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !audioSrc.isPlaying && isPlayed == 0)
        {
            audioSrc.Play();
            isPlayed = 1;
        }
    }
}
