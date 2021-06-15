using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class coinScript : MonoBehaviour
{
    public Animator anim;
    public Text trapPrice;
    public Text torchPrice;
    public Text keyPrice;
    public Text playerCoins;
    public PlayerMovementShop player;
    public keyPickup key;
    int counterTraps;
    int counterPotions;
    int counterKeys;
    int counterTorches;
    int coins;
    public bool isClicked;


    void Start()
    {
        PlayerMovementShop counter = player.GetComponent<PlayerMovementShop>();
        keyPickup keyCounter = key.GetComponent<keyPickup>();
        counterTraps = counter.trap;
        counterPotions = counter.potions;
        counterKeys = keyCounter.key;
        counterTorches = counter.torches;
        
        coins = counter.coins;
    }

    void Update()
    {
        
        playerCoins.text = coins.ToString();
        if (counterKeys > 1)
            keyPrice.text = (counterKeys * 5 + 5).ToString();
        else if (counterKeys == 0)
            keyPrice.text = "5";
        else if (counterKeys == 1)
            keyPrice.text = "10";
        if (counterTraps == 0)
            trapPrice.text = "3";
        else if (counterTraps > 1)
            trapPrice.text = (counterTraps * 3 + 3).ToString();
        else if (counterTraps == 1)
            trapPrice.text = "6";
        if (counterTorches > 1)
            torchPrice.text = (counterTorches * 7 + 7).ToString();
        else if (counterTorches == 0)
            torchPrice.text = "7";
        else if (counterTorches == 1)
            torchPrice.text = "14";

        /* if (isClicked)
         {
             anim.SetBool("click", false);
             anim.SetBool("idle", false);
             isClicked = false;
         }*/

    }

    public void PurchaseTraps()
    {
        

        if (coins >= counterTraps * 3)
        {
            if (counterTraps == 0)
            {
                coins -= 3;
                player.coins -= 3;
            }
            else if (counterTraps == 1)
            {
                coins -= 6;
                player.coins -= 6;
            }
            else if (counterTraps > 1)
            {
                coins -= counterTraps * 3 + 3;
                player.coins -= counterTraps * 3 + 3;
            }
            counterTraps++;
            if (PlayerPrefs.GetInt("whichOne") == 0 && PlayerPrefs.GetInt("isChanged") == 1)
                player.potion_mvspeed++;
            else if (PlayerPrefs.GetInt("whichOne") == 1 && PlayerPrefs.GetInt("isChanged") == 1)
                player.potion_invisible++;
            else if (PlayerPrefs.GetInt("isChanged") == 0)
                player.potions++;
            anim.SetBool("click", true);
            anim.SetBool("idle", true);
            isClicked = true;
            StartCoroutine(Wait());

        }
        else
        {
            Debug.Log("Brak pieniedzy");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("click", false);
        anim.SetBool("idle", false);
        
        

    }
    public void PurchasePotion()
    {

       
        //potionPrice.text = (counterPotions * 2).ToString();
        if (coins >= counterTorches * 7)
        {
            if (counterTorches == 0)
            {
                coins -= 7;
                player.coins -= 7;
            }
            else if (counterTorches == 1)
            {
                coins -= 14;
                player.coins -= 14;
            }

            else if (counterTorches > 1)
            {

                coins -= counterTorches * 7 + 7;
                player.coins -= counterTorches * 7 + 7;
            }
            counterTorches++;
            player.torches++;
            anim.SetBool("click", true);
            anim.SetBool("idle", true);
            isClicked = true;
            StartCoroutine(Wait());


        }
        else
        {
            Debug.Log("Brak pieniedzy");
        }
    }
    public void PurchaseKey()
    {
        
        //keyPrice.text = (counterKeys * 5).ToString();
        if (coins >= counterKeys * 5)
        {
            if (counterKeys == 0)
            {
                coins -= 5;
                player.coins -= 5;
            }
            else if (counterKeys == 1)
            {
                coins -= 10;
                player.coins -= 10;
            }
            else if (counterKeys > 1)
            {
                coins -= counterKeys * 5 + 5;
                player.coins -= counterKeys * 5 + 5;
            }
            counterKeys++;
            key.key++;
            anim.SetBool("click", true);
            anim.SetBool("idle", true);
            isClicked = true;
            StartCoroutine(Wait());
        }
        else
        {
            Debug.Log("Brak pieniedzy");
        }
    }
}
