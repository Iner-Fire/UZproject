using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyPickup : MonoBehaviour
    
{
    public int key;
    public Text mytext = null;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            key += 1;
            Debug.Log("Podniosles klucz");
            Destroy(GameObject.FindGameObjectWithTag("Key"));        }
    }
     void Update()
    {
    }
}
