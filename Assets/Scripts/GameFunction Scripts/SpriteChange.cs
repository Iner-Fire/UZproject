using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public SpriteRenderer potion_mvspeed;
    public Sprite sprite_potion_invisible;
    public Sprite sprite_potion_mvspeed;
    public int whichOne = 10;

    int random;

     void Start()
    {
        random = Random.Range(0, 2);
    }

     void Update()
    {
        Debug.Log(random);
        if (random == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprite_potion_invisible;
            whichOne = 1;
        }
        else if (random == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprite_potion_mvspeed;
            whichOne = 0;
        }
    }
}
