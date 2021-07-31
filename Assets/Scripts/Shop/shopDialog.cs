using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shopDialog : MonoBehaviour
{
    public GameObject popupbox;
    public Animator anim;
    public TMP_Text popuptext;


    public void PopUp()
    {
        popupbox.SetActive(true);
        anim.SetTrigger("pop");
    }

}
