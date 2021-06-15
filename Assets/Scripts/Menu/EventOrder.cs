using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOrder : MonoBehaviour
{
    public GameObject Menu;
    public void SetMenuActive()
    {
        Menu.SetActive(false);
    }
    public void SetMenuDeactive()
    {
        Menu.SetActive(true);
    }
}
