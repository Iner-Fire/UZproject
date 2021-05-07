using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class coinScript : MonoBehaviour
{
    public Animator anim;
    public Text trapPrice;
    public Text potionPrice;
    public Text keyPrice;
    public Text playerCoins;
    public playerMovement player;
    public keyPickup key;
    int counterTraps;
    int counterPotions;
    int counterKeys;
    int coins;
    public bool isClicked;


    void Start()
    {
        playerMovement counter = player.GetComponent<playerMovement>();
        keyPickup keyCounter = key.GetComponent<keyPickup>();
        counterTraps = counter.trap;
        counterPotions = counter.potions;
        counterKeys = keyCounter.key;
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
        if (counterPotions > 1)
            potionPrice.text = (counterPotions * 2 + 2).ToString();
        else if (counterPotions == 0)
            potionPrice.text = "2";
        else if (counterPotions == 1)
            potionPrice.text = "4";

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
            player.trap++;
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
        if (coins >= counterPotions * 2)
        {
            if (counterPotions == 0)
            {
                coins -= 2;
                player.coins -= 2;
            }
            else if (counterPotions == 1)
            {
                coins -= 4;
                player.coins -= 4;
            }

            else if (counterPotions > 1)
            {

                coins -= counterPotions * 2 + 2;
                player.coins -= counterPotions * 2 + 2;
            }
            counterPotions++;
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
