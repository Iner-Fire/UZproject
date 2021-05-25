using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour
{

    public float textDelay = 0.1f;
    public string text;
    private string currentText = "";
    void Start()
    {
        StartCoroutine(ShowText());
    }
    IEnumerator ShowText()
    {
        for (int i = 0; i <= text.Length; i++)
        {
            currentText = text.Substring(0,i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(textDelay);
        }
    }

}
