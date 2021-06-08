using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangesChangeSprite : MonoBehaviour
{
    public SpriteRenderer spriteRnd;
    public Sprite potion_invisible;
    public Sprite potion_mvspeed;
    public SpriteChange which;
 

    // Update is called once per frame
    void Update()
    {
        
        
        if (which.whichOne == 0)
            this.GetComponent<SpriteRenderer>().sprite = potion_mvspeed;
        else if (which.whichOne == 1)
            this.GetComponent<SpriteRenderer>().sprite = potion_invisible;
    }
}
