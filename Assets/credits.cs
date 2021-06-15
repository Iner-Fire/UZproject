using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    private int klucze;

    public Animator anim;
    public Animator animPath;
    private GameObject playerPosition;
    public openChest chest;
    private GameObject doorPosition;
    public playerMovement playerMovement;
    int saveData;
    public bool isDoorOpened = false;
    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
        doorPosition = GameObject.FindGameObjectWithTag("Drzwi_top");
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
                        SceneManager.LoadScene("Credits");

                    }
                }

            }

        }
    }
}