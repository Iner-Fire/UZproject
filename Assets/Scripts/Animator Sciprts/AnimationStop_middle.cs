using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStop_middle : MonoBehaviour
{
    private int klucze;

    public Animator anim;
    public static bool doorPass = false;
    private GameObject playerPosition;
    private GameObject doorPosition;



    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
        doorPosition = GameObject.FindGameObjectWithTag("Drzwi_góra");
        GameObject key = GameObject.Find("Player");
        keyPickup keypick = key.GetComponent<keyPickup>();
        klucze = keypick.key;
        if (Input.GetKeyDown(KeyCode.E) && klucze >= 1)
        {

            if (anim != null)
            {
                if (anim.runtimeAnimatorController != null)
                {
                    if (Mathf.Abs(playerPosition.transform.position.x - doorPosition.transform.position.x) < 1 && Mathf.Abs(playerPosition.transform.position.y - doorPosition.transform.position.y) < 1)
                    {
                        Destroy(GameObject.FindGameObjectWithTag("Collider_mid"));
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
            doorPass = true;
            Destroy(GameObject.FindGameObjectWithTag("czarny_pokoj"));
        }

    }
   /* private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("idle", true);
        anim.SetBool("close", false);
        anim.SetBool("open", false);
    }*/

  /*  IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("close", true);
    }*/
}

