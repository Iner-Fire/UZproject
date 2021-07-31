using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusicBackground()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
     void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<PlayMusic>().PlayMusicBackground();
        }
        else
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<PlayMusic>().StopMusic();
        }
        
    }
}