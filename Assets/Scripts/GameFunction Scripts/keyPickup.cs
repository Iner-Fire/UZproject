using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyPickup : MonoBehaviour
    
{
    public int key;
    public playerMovement keys;

    void Start()
    {
        key = PlayerPrefs.GetInt("keyAmount");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("keyAmount", key);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            key += 1;
            Destroy(GameObject.FindGameObjectWithTag("Key"));        }
    }
}
