using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyPickup : MonoBehaviour
    
{
    public int key;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Key"))
        {
            key += 1;
            Debug.Log("Podniosles klucz");
            Destroy(GameObject.FindGameObjectWithTag("Key"));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
