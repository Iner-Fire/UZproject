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
    public GameObject deathScreen;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.deathCounter += 1;
            PlayerPrefs.SetInt("deathCounter", player.deathCounter);
            PlayerPrefs.SetInt("death", 1);
            health.SetHP(0);
            deathScreen.SetActive(true);
            StartCoroutine(RestartLvl(2));
            this.transform.position = new Vector3(0, 0, -100);
            var playerPosition = GameObject.FindGameObjectWithTag("Player");
            playerPosition.transform.position = new Vector3(0, 0, -100);
            
            
        }
        if(collision.CompareTag("Music") && !audioSrc.isPlaying)
        {
            audioSrc.Play();
        }
    }
    IEnumerator RestartLvl(int secs)
    {
        yield return new WaitForSeconds(secs);
        int tmp = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(tmp);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Music") && audioSrc.isPlaying)
        {
            audioSrc.Stop();
        }
    }
}
