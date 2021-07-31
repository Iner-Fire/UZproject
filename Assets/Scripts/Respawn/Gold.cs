using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public GameObject spawn;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    public GameObject spawn7;
    public GameObject spawn8;
    int randomSpawn;
    public playerMovement coinCount;
    public AudioSource audioSrc;
    public AudioClip coinpick;

 


    public void GoldSpawn()
    {
        randomSpawn = Random.Range(0, 8);
        switch (randomSpawn)
        {
            case 0:
                this.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, 0);
                break;
            case 1:
                this.transform.position = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, 0);
                break;
            case 2:
                this.transform.position = new Vector3(spawn2.transform.position.x, spawn2.transform.position.y, 0);
                break;
            case 3:
                this.transform.position = new Vector3(spawn3.transform.position.x, spawn3.transform.position.y, 0);
                break;
            case 4:
                this.transform.position = new Vector3(spawn4.transform.position.x, spawn4.transform.position.y, 0);
                break;
            case 5:
                this.transform.position = new Vector3(spawn5.transform.position.x, spawn5.transform.position.y, 0);
                break;
            case 6:
                this.transform.position = new Vector3(spawn6.transform.position.x, spawn6.transform.position.y, 0);
                break;
            case 7:
                this.transform.position = new Vector3(spawn7.transform.position.x, spawn7.transform.position.y, 0);
                break;
            case 8:
                this.transform.position = new Vector3(spawn8.transform.position.x, spawn8.transform.position.y, 0);
                break;

        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            audioSrc.Play();
            coinCount.coins += 10;
            Destroy(GameObject.FindGameObjectWithTag("Gold"));
            
        }
    }

}
