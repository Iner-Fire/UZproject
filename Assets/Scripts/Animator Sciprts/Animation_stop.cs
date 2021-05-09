using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation_stop : MonoBehaviour
{
    private int klucze;
    public Animator anim;
    private GameObject playerPosition;
    private GameObject doorPosition;



    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
        doorPosition = GameObject.FindGameObjectWithTag("Door");
        GameObject key = GameObject.Find("Player");
        keyPickup keypick = key.GetComponent<keyPickup>();
        klucze = keypick.key;
        if (Input.GetKeyDown(KeyCode.E) && klucze >= 1)
        {

            if (anim != null)
            {
                if (anim.runtimeAnimatorController != null)
                {
                    if (Mathf.Abs(playerPosition.transform.position.x - doorPosition.transform.position.x) < 1.2 && Mathf.Abs(playerPosition.transform.position.y - doorPosition.transform.position.y) < 1.2)
                    {
                        Destroy(GameObject.FindGameObjectWithTag("Collider_bot"));
                        anim.SetBool("open", true);
                        keypick.key--;
                    }
                }

            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            StartCoroutine(delay());
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("idle", true);
        anim.SetBool("close", false);
        anim.SetBool("open", false);
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        anim.SetBool("close", true);
    }
}

