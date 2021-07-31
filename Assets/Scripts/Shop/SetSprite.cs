using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSprite : MonoBehaviour
{
    public SpriteRenderer curentSprite;

     void Update()
    {
        if (curentSprite.sprite != this.gameObject.GetComponent<SpriteRenderer>().sprite)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = curentSprite.sprite;
        }
    }
}
