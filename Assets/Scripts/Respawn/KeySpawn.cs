using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{
    public GameObject KeySpawn0;
    public GameObject KeySpawn1;
    public GameObject KeySpawn2;
    public GameObject KeySpawn3;
    public GameObject KeySpawn4;
    public GameObject KeySpawn5;
    public GameObject KeySpawn6;
    public GameObject KeySpawn7;
    public GameObject KeySpawn8;
    public GameObject KeySpawn9;
    public GameObject KeySpawn10;
    public GameObject Key2;
    int random;
    int random1;


    public void SetKeySpawn()
    {
        random = Random.Range(0, 10);
        random1 = Random.Range(0, 10);
        while (random1 == random)
        {
            random1 = Random.Range(0, 10);
        }
        switch (random)
        {
            case 0:
                this.transform.position = new Vector3(KeySpawn0.transform.position.x, KeySpawn0.transform.position.y, 0);
                break;
            case 1:
                this.transform.position = new Vector3(KeySpawn1.transform.position.x, KeySpawn1.transform.position.y, 0);
                break;
            case 2:
                this.transform.position = new Vector3(KeySpawn2.transform.position.x, KeySpawn2.transform.position.y, 0);
                break;
            case 3:
                this.transform.position = new Vector3(KeySpawn3.transform.position.x, KeySpawn3.transform.position.y, 0);
                break;
            case 4:
                this.transform.position = new Vector3(KeySpawn4.transform.position.x, KeySpawn4.transform.position.y, 0);
                break;
            case 5:
                this.transform.position = new Vector3(KeySpawn5.transform.position.x, KeySpawn5.transform.position.y, 0);
                break;
            case 6:
                this.transform.position = new Vector3(KeySpawn6.transform.position.x, KeySpawn6.transform.position.y, 0);
                break;
            case 7:
                this.transform.position = new Vector3(KeySpawn7.transform.position.x, KeySpawn7.transform.position.y, 0);
                break;
            case 8:
                this.transform.position = new Vector3(KeySpawn8.transform.position.x, KeySpawn8.transform.position.y, 0);
                break;
            case 9:
                this.transform.position = new Vector3(KeySpawn9.transform.position.x, KeySpawn9.transform.position.y, 0);
                break;
            case 10:
                this.transform.position = new Vector3(KeySpawn10.transform.position.x, KeySpawn10.transform.position.y, 0);
                break;
            default:
                break;
        }
        switch (random1)
        {
            case 0:
                Key2.transform.position = new Vector3(KeySpawn0.transform.position.x, KeySpawn0.transform.position.y, 0);
                break;
            case 1:
                Key2.transform.position = new Vector3(KeySpawn1.transform.position.x, KeySpawn1.transform.position.y, 0);
                break;
            case 2:
                Key2.transform.position = new Vector3(KeySpawn2.transform.position.x, KeySpawn2.transform.position.y, 0);
                break;
            case 3:
                Key2.transform.position = new Vector3(KeySpawn3.transform.position.x, KeySpawn3.transform.position.y, 0);
                break;
            case 4:
                Key2.transform.position = new Vector3(KeySpawn4.transform.position.x, KeySpawn4.transform.position.y, 0);
                break;
            case 5:
                Key2.transform.position = new Vector3(KeySpawn5.transform.position.x, KeySpawn5.transform.position.y, 0);
                break;
            case 6:
                Key2.transform.position = new Vector3(KeySpawn6.transform.position.x, KeySpawn6.transform.position.y, 0);
                break;
            case 7:
                Key2.transform.position = new Vector3(KeySpawn7.transform.position.x, KeySpawn7.transform.position.y, 0);
                break;
            case 8:
                Key2.transform.position = new Vector3(KeySpawn8.transform.position.x, KeySpawn8.transform.position.y, 0);
                break;
            case 9:
                Key2.transform.position = new Vector3(KeySpawn9.transform.position.x, KeySpawn9.transform.position.y, 0);
                break;
            case 10:
                Key2.transform.position = new Vector3(KeySpawn10.transform.position.x, KeySpawn10.transform.position.y, 0);
                break;
            default:
                break;
        }
    }


}
