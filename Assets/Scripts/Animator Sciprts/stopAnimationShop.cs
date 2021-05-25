using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stopAnimationShop : MonoBehaviour
{
    private int klucze;

    public Animator anim;
    private GameObject playerPosition;
    private GameObject doorPosition;
    public Animator NextMapAnim;



    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
        doorPosition = GameObject.FindGameObjectWithTag("Drzwi_top");
        GameObject key = GameObject.Find("Player");
        keyPickup keypick = key.GetComponent<keyPickup>();
        klucze = keypick.key;
        if (Input.GetKeyDown(KeyCode.E) && klucze >= 0)
        {

            if (anim != null)
            {
                if (anim.runtimeAnimatorController != null)
                {
                    if (Mathf.Abs(playerPosition.transform.position.x - doorPosition.transform.position.x) < 1 && Mathf.Abs(playerPosition.transform.position.y - doorPosition.transform.position.y) < 1)
                    {
                        Destroy(GameObject.FindGameObjectWithTag("Colliber_top"));
                        anim.SetBool("open", true);
                    }
                }

            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (NextMapAnim.GetBool("No") == true)
                NextMapAnim.SetBool("No", false);

                NextMapAnim.SetBool("Trigger", true);
            
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("idle", true);
        anim.SetBool("close", false);
        anim.SetBool("open", false);
        NextMapAnim.SetBool("Trigger", false);
        NextMapAnim.SetBool("No", true);
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        anim.SetBool("close", true);
    }
}

