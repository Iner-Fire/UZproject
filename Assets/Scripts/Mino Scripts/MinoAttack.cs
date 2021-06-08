using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinoAttack : MonoBehaviour
{
    public playerMovement player;
    public HealthBar health;
    public RespawnPoints spawn;
    public AudioSource audioSrc;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            int tmp = SceneManager.GetActiveScene().buildIndex;
            player.deathCounter += 1;
            PlayerPrefs.SetInt("deathCounter", player.deathCounter);
            PlayerPrefs.SetInt("death", 1);
            health.SetHP(0);
            SceneManager.LoadScene(tmp);
        }
        if(collision.CompareTag("Music") && !audioSrc.isPlaying)
        {
            audioSrc.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Music") && audioSrc.isPlaying)
        {
            audioSrc.Stop();
        }
    }
}
