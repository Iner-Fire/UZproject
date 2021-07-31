using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoints : MonoBehaviour
{
    public GameObject spawn;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    private GameObject MInoPosition;

    public void Spawn()
    {
        MInoPosition = GameObject.FindGameObjectWithTag("Mino");
        int random = Random.Range(1, 7);
        if (PlayerPrefs.GetInt("saveData") == 0)
        {
            switch (random)
            {
                case 1:
                    MInoPosition.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, 0);
                    PlayerPrefs.SetInt("isRespawn", 1);
                    break;
                case 2:
                    MInoPosition.transform.position = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, 0);
                    PlayerPrefs.SetInt("isRespawn", 1);
                    break;
                case 3:
                    MInoPosition.transform.position = new Vector3(spawn2.transform.position.x, spawn2.transform.position.y, 0);
                    PlayerPrefs.SetInt("isRespawn", 1);
                    break;
                case 4:
                    MInoPosition.transform.position = new Vector3(spawn3.transform.position.x, spawn3.transform.position.y, 0);
                    PlayerPrefs.SetInt("isRespawn", 1);
                    break;
                case 5:
                    MInoPosition.transform.position = new Vector3(spawn4.transform.position.x, spawn4.transform.position.y, 0);
                    PlayerPrefs.SetInt("isRespawn", 1);
                    break;
                case 6:
                    MInoPosition.transform.position = new Vector3(spawn5.transform.position.x, spawn5.transform.position.y, 0);
                    PlayerPrefs.SetInt("isRespawn", 1);
                    break;
                case 7:
                    MInoPosition.transform.position = new Vector3(spawn6.transform.position.x, spawn6.transform.position.y, 0);
                    PlayerPrefs.SetInt("isRespawn", 1);
                    break;
            }
        }
    }
}
