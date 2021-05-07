using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_stop : MonoBehaviour
{

    private Animation animacja;
    public Animator anim;
    public int klik = 0;
    public int klucze = 0;
    int klucze2;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        GameObject key = GameObject.Find("Player");
        keyPickup keypick = key.GetComponent<keyPickup>();
        klucze = keypick.key;
        klucze2 = klucze;
        if (Input.GetKey(KeyCode.E) && klucze >= 1)
        {

            if (anim != null)
            {
                if (anim.runtimeAnimatorController != null)
                {
                    if (CheckClose("Player",7)==true)
                    {
                        gameObject.GetComponent<Animator>().enabled = true;
                        anim.SetBool("open", true);
                        keypick.key--;
                    }
                }

            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
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

        bool CheckClose(string tag, double distance)
        {
            GameObject[] findTag = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < findTag.Length; ++i)
        {
            if (Vector3.Distance(transform.position, findTag[i].transform.position) <= distance)
            {
                return true;
            }
        }
        return false;
           

        }
    }

