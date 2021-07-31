using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ResolutionScript : MonoBehaviour
{

    public Dropdown resolutiondrop;
    public Toggle toggle;
    bool isFull;
    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutiondrop.ClearOptions();
        List<string> options = new List<string>();

        int currentres = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && 
                resolutions[i].height == Screen.height)
                currentres = i;
        }
        resolutiondrop.AddOptions(options);
        resolutiondrop.value = currentres;
        resolutiondrop.RefreshShownValue();
    }

    public void SetResolution(int resindex)
    {
        Resolution res = resolutions[resindex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetFullScreen()
    {

        if (toggle.isOn)
        {
            isFull = true;
            Debug.Log("full");
            Screen.fullScreen = false;
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;

        }
        else if (!toggle.isOn)
        {
            Debug.Log("WIND");
            Screen.fullScreen = true;
            isFull = false;
            Screen.fullScreenMode = FullScreenMode.Windowed;


        }
    }

}