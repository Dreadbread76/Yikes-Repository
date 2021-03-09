using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer myMixer;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            myMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            myMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            myMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
        }
    }
}
