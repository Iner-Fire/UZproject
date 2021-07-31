using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderInLayer : MonoBehaviour
{
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collsion)
    {
        if(collsion.gameObject.CompareTag("Player"))
        sprite.sortingOrder = 4;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        sprite.sortingOrder = 2;
        //Destroy(GameObject.FindGameObjectWithTag("Góra"));
    }
}
