using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesSpawn : MonoBehaviour
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
    public GameObject spike1;
    public GameObject spike2;
  
    public void Spawn() {

        int random = Random.Range(1, 9);
        int random1 = Random.Range(1, 9);
        int random2 = Random.Range(1, 9);
        while (random1 == random || random1 == random2)
        {
            random1 = Random.Range(1, 9);
        }
        
        while(random2 == random || random2 == random1)
        {
            random2 = Random.Range(1, 9);
        }

        switch(random)
        {
            case 1:
                this.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, 0);
                break;
            case 2:
                this.transform.position = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, 0);
                break;
            case 3:
                this.transform.position = new Vector3(spawn2.transform.position.x, spawn2.transform.position.y, 0);
                break;
            case 4:
                this.transform.position = new Vector3(spawn3.transform.position.x, spawn3.transform.position.y, 0);
                break;
            case 5:
                this.transform.position = new Vector3(spawn4.transform.position.x, spawn4.transform.position.y, 0);
                break;
            case 6:
                this.transform.position = new Vector3(spawn5.transform.position.x, spawn5.transform.position.y, 0);
                break;
            case 7:
                this.transform.position = new Vector3(spawn6.transform.position.x, spawn6.transform.position.y, 0);
                break;
            case 8:
                this.transform.position = new Vector3(spawn7.transform.position.x, spawn7.transform.position.y, 0);
                break;
            case 9:
                this.transform.position = new Vector3(spawn8.transform.position.x, spawn8.transform.position.y, 0);
                break;
        }
        switch (random1)
        {
            case 1:
                spike1.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, 0);
                break;
            case 2:
                spike1.transform.position = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, 0);
                break;
            case 3:
                spike1.transform.position = new Vector3(spawn2.transform.position.x, spawn2.transform.position.y, 0);
                break;
            case 4:
                spike1.transform.position = new Vector3(spawn3.transform.position.x, spawn3.transform.position.y, 0);
                break;
            case 5:
                spike1.transform.position = new Vector3(spawn4.transform.position.x, spawn4.transform.position.y, 0);
                break;
            case 6:
                spike1.transform.position = new Vector3(spawn5.transform.position.x, spawn5.transform.position.y, 0);
                break;
            case 7:
                spike1.transform.position = new Vector3(spawn6.transform.position.x, spawn6.transform.position.y, 0);
                break;
            case 8:
                spike1.transform.position = new Vector3(spawn7.transform.position.x, spawn7.transform.position.y, 0);
                break;
            case 9:
                spike1.transform.position = new Vector3(spawn8.transform.position.x, spawn8.transform.position.y, 0);
                break;
        }
        switch (random2)
        {
            case 1:
                spike2.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, 0);
                break;
            case 2:
               spike2.transform.position = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, 0);
                break;
            case 3:
                spike2.transform.position = new Vector3(spawn2.transform.position.x, spawn2.transform.position.y, 0);
                break;
            case 4:
                spike2.transform.position = new Vector3(spawn3.transform.position.x, spawn3.transform.position.y, 0);
                break;
            case 5:
                spike2.transform.position = new Vector3(spawn4.transform.position.x, spawn4.transform.position.y, 0);
                break;
            case 6:
                spike2.transform.position = new Vector3(spawn5.transform.position.x, spawn5.transform.position.y, 0);
                break;
            case 7:
                spike2.transform.position = new Vector3(spawn6.transform.position.x, spawn6.transform.position.y, 0);
                break;
            case 8:
                spike2.transform.position = new Vector3(spawn7.transform.position.x, spawn7.transform.position.y, 0);
                break;
            case 9:
                spike2.transform.position = new Vector3(spawn8.transform.position.x, spawn8.transform.position.y, 0);
                break;
        }

    }
}
