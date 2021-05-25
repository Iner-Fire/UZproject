using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationStop_top : MonoBehaviour
{
    private int klucze;

    public Animator anim;
    public Animator animPath;
    private GameObject playerPosition;
    private GameObject doorPosition;
    public playerMovement playerMovement;
    int saveData;
    public bool isDoorOpened = false;



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
        if (Input.GetKeyDown(KeyCode.E) && klucze >= 1)
        {

            if (anim != null)
            {
                if (anim.runtimeAnimatorController != null)
                {
                    if (Mathf.Abs(playerPosition.transform.position.x - doorPosition.transform.position.x) < 1 && Mathf.Abs(playerPosition.transform.position.y - doorPosition.transform.position.y) < 1)
                    {
                        Destroy(GameObject.FindGameObjectWithTag("Colliber_top"));
                        anim.SetBool("open", true);
                        animPath.SetBool("open", true);
                        keypick.key--;
                        isDoorOpened = true;

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
            PlayerPrefs.SetInt("goldAmount", playerMovement.coins);
            PlayerPrefs.SetInt("torchAmount", playerMovement.torches);
            PlayerPrefs.SetInt("potionAmount", playerMovement.potions);
            PlayerPrefs.SetInt("trapAmount", playerMovement.trap);
            saveData = 1;
            PlayerPrefs.SetInt("saveData", saveData);
            Scene scene = SceneManager.GetActiveScene();
            if(scene.name == "Game")
            {
                PlayerPrefs.SetInt("CurrentSceneID", 1);
            }
            else if(scene.name =="Maze1")
            {
                PlayerPrefs.SetInt("CurrentSceneID", 2);
            }
            PlayerPrefs.Save();
            
            //SceneManager.LoadScene("shopScene");
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

