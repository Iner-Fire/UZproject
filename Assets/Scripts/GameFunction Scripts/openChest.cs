using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openChest : MonoBehaviour
{
    private GameObject playerPostion;
    private GameObject chestPostion;
    public Animator anim;
    public int isChanged = 0;
    public Animator popChestAnim;
    public Animator changeAnim;
    public SpriteRenderer trap;
    public SpriteRenderer potion;
    public SpriteRenderer torch;
    public Sprite potion_mvspeed;
    public Sprite potion_invisible;
    public playerMovement item;
    public SpriteChange which;
    public GameObject Menu;
    public GameObject scaleAnim;
    public GameObject scaleAnimChangeItems;
    int isOpened = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene1 = SceneManager.GetActiveScene();
        string sceneName1 = currentScene1.name;
        playerPostion = GameObject.FindGameObjectWithTag("Player");
        chestPostion = GameObject.FindGameObjectWithTag("Chest");
        if (Input.GetKey(KeyCode.E))
        {
            if (Mathf.Abs(playerPostion.transform.position.x - chestPostion.transform.position.x) < 1 && Mathf.Abs(playerPostion.transform.position.y - chestPostion.transform.position.y) < 1 && isOpened == 0)
            {
                Menu.SetActive(false);
                anim.SetBool("open", true);
                isOpened = 1;
                if (sceneName1 == "Maze1" || sceneName1 ==  "Maze2")
                    scaleAnim.transform.localScale = new Vector3(1, 1, 1);
                    popChestAnim.SetBool("open", true);

            }
        }
    }

    public void CloseChest()
    {
        
        popChestAnim.SetBool("open", false);
        item.coins += Random.Range(8, 25);
        item.trap += 2;
        popChestAnim.SetBool("close", true);
        anim.SetBool("open", false);
        anim.SetBool("closed", true);

        Scene currentScene1 = SceneManager.GetActiveScene();
        string sceneName1 = currentScene1.name;
        if (sceneName1 == "Maze1" || sceneName1 == "Maze2")
            scaleAnimChangeItems.transform.localScale = new Vector3(1, 1, 1);
        changeAnim.SetBool("changeYes", true);
       
        
    }

    public void YesChange()
    {
        Menu.SetActive(true);
        changeAnim.SetBool("changeYes", false);
        changeAnim.SetBool("closeChange", true);

        if (which.whichOne == 0)
        {
            item.potion_mvspeed += 1;
            potion.sprite = potion_mvspeed;
            isChanged = 1;
            PlayerPrefs.SetInt("isChanged",1);
        }
        else if(which.whichOne == 1)
        {
            item.potion_invisible += 1;
            potion.sprite = potion_invisible;
            isChanged = 1;
            PlayerPrefs.SetInt("isChanged", 1);
        }
        PlayerPrefs.Save();
    }
    public void NoChange()
    {
        Menu.SetActive(true);
        changeAnim.SetBool("changeYes", false);
        changeAnim.SetBool("closeChange", true);
        PlayerPrefs.SetInt("isChanged", 0);
    }
}
