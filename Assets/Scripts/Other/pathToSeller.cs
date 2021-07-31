using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathToSeller : MonoBehaviour
{
    public GameObject path;
    public AnimationStop_top topDor;
    void Start()
    {
        path.SetActive(false);
    }
    void Update()
    {
        
        AnimationStop_top dor = topDor.GetComponent<AnimationStop_top>();
        if (dor.isDoorOpened == true)
            path.SetActive(true);
            
    }
}
