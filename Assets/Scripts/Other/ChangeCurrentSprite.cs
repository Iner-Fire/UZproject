using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCurrentSprite : MonoBehaviour
{

    public SpriteRenderer currentSprite;
    public SpriteRenderer spriteToChange;
    public GameObject changeMenu;
   
    void Update()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = currentSprite.sprite;
        if (currentSprite.sprite == spriteToChange.sprite)
        {
            changeMenu.SetActive(false);
        }
    }
}
