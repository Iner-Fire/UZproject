using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openChest : MonoBehaviour
{
    private GameObject playerPostion;
    private GameObject chestPostion;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPostion = GameObject.FindGameObjectWithTag("Player");
        chestPostion = GameObject.FindGameObjectWithTag("Chest");
        if (Input.GetKey(KeyCode.E))
        {
            if (Mathf.Abs(playerPostion.transform.position.x - chestPostion.transform.position.x) < 1 && Mathf.Abs(playerPostion.transform.position.y - chestPostion.transform.position.y) < 1)
            {
                anim.SetBool("open", true);
            }
        }
    }
}
