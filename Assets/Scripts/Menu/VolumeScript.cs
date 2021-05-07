using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour
{
    public AudioMixer mixer;
    public void setVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
    }
}
