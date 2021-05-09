using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{
    public GameObject torch;
    public GameObject trapPrefab;
    public playerMovement counter;
    public Animator torchAnim;
    public Animator trap;
    public Animator potion;
    private int whichKey;
    private GameObject playerPosition;
    bool torchb = false;
    bool torchnb = false;
    bool potionb = false;
    bool potionnb = false;
    bool trapb = false;
    bool trapnb = false;
    bool callTrapFunction = false;
    public List<GameObject> cloneList = new List<GameObject>();
    void Update()
    {
        
        playerMovement counterTorches = counter.GetComponent<playerMovement>();
        var input = Input.inputString;
        switch (input)
        {
            case "1":
                whichKey = 1;
                if(torchnb==true)
                {
                    torchAnim.SetBool("torchNotClicked", false);
                    torchnb = false;
                }
                torchAnim.SetBool("torchClicked", true);
                torchb = true;

                if (trapb == true)
                {
                    trap.SetBool("trapNotClicked", true);
                    trapnb = true;
                    trap.SetBool("trapClicked", false);
                    trapb = false;
                }
                else
                    trap.SetBool("trapNotClicked", false);
                if (potionb == true)
                {
                    potion.SetBool("potionNotClicked", true);
                    potionnb = true;
                    potion.SetBool("potionClicked", false);
                    potionb = false;
                }
                else
                    potion.SetBool("potionNotClicked", false);
               
                break;
            case "2":
                whichKey = 2;
                if(trapnb == true)
                {
                    trap.SetBool("trapNotClicked", false);
                    trapnb = false;
                }
                trap.SetBool("trapClicked", true);
                trapb = true;

                if (torchb == true)
                {
                    torchAnim.SetBool("torchNotClicked", true);
                    torchnb = true;
                    torchAnim.SetBool("torchClicked", false);
                    torchb = false;
                }
                else
                    torchAnim.SetBool("torchNotClicked", false);
                if (potionb == true)
                {
                    potion.SetBool("potionNotClicked", true);
                    potionb = true;
                    potion.SetBool("potionClicked", false);
                    potionb = false;
                }
                else
                    potion.SetBool("potionNotClicked", false);
                
                
                break;
            case "3":
                whichKey = 3;
                if(potionnb == true)
                {
                    potion.SetBool("potionNotClicked", false);
                    potionnb = false;
                }
                potion.SetBool("potionClicked", true);
                potionb = true;

                if (torchb == true)
                {
                    torchAnim.SetBool("torchNotClicked", true);
                    torchnb = true;
                    torchAnim.SetBool("torchClicked", false);
                    torchb = false;
                }
                else
                    torchAnim.SetBool("torchNotClicked", false);
                if (trapb == true)
                {
                    trap.SetBool("trapNotClicked", true);
                    trapnb = true;
                    trap.SetBool("trapClicked", false);
                    trapb = false;
                }
                else
                    trap.SetBool("trapNotClicked", false);



                break;
        }
        if (Input.GetButtonDown("Fire1") && counterTorches.torches >=1 && whichKey == 1)
        {
           
            counterTorches.torches -= 1;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject newClone = Instantiate(torch, new Vector3(mousePos.x,mousePos.y,0),Quaternion.identity);
            cloneList.Add(newClone);
           
            
        }
        if (!callTrapFunction)
        {
            if (counterTorches.trap >= 1 && whichKey == 2 && Input.GetKeyDown(KeyCode.G))
            {
                counterTorches.trap -= 1;
                playerPosition = GameObject.FindGameObjectWithTag("Player");
                Instantiate(trapPrefab, new Vector3(playerPosition.transform.position.x, playerPosition.transform.position.y - (float)0.3, 0), Quaternion.identity);

            }
        }

        if (Input.GetButtonDown("Fire1") && counterTorches.potions >= 1 && whichKey == 3)
        {

            counterTorches.potions -= 1;


        }

    }
}
