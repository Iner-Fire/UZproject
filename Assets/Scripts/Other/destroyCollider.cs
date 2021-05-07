using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyCollider : MonoBehaviour
{
    private int keys;
    private GameObject playerPostion;
    private GameObject colliderPostion;
    public bool clickStatus = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        playerPostion = GameObject.FindGameObjectWithTag("Player");
        colliderPostion = GameObject.FindGameObjectWithTag("Collider_bot");
        GameObject key = GameObject.Find("Player");
       // keyPickup keypick = key.GetComponent<keyPickup>();
        //Debug.Log("Liczba kluczy : " + keypick.key);
        //keys = keypick.key;

        if (Mathf.Abs(playerPostion.transform.position.x - colliderPostion.transform.position.x) < 1 && Mathf.Abs(playerPostion.transform.position.y - colliderPostion.transform.position.y) < 1)
        {
            if (Input.GetKey(KeyCode.E) && keys >= 1)
            {
                Destroy(GameObject.FindGameObjectWithTag("Collider_bot"));
                clickStatus = true;
            }
        }
        
    }
}
