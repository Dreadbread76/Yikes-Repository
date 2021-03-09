using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle fullscreenToggle, vsyncToggle;
    public ResItem[] resolutions;
    public int selectedResolution;
    public Text resolutionLabel;
    public AudioMixer myMixer;
    public Slider masterSlider, musicSlider, sfxSlider;
    public Text masterLabel, musicLabel, sfxLabel;
    public AudioSource sfxLoop;

    // Start is called before the first frame update
    void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncToggle.isOn = false;
        }
        else
        {
            vsyncToggle.isOn = true;
        }

        bool foundRes = false;
        for (int i=0; i<resolutions.Length; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedResolution = i;
                UpdateResLabel();
                break;
            }
        }

        if (!foundRes)
        {
            resolutionLabel.text = Screen.width.ToString() + " X " + Screen.height.ToString();
        }

        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            myMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume"); 
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            myMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");            
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            myMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");        
        }

        masterLabel.text = (masterSlider.value + 80).ToString();
        musicLabel.text = (musicSlider.value + 80).ToString();
        sfxLabel.text = (sfxSlider.value + 80).ToString();
    }


    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0) selectedResolution = 0;

        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Length-1) selectedResolution = resolutions.Length-1;

        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " X " + resolutions[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        // apply Fullscreen
        // Screen.fullScreen = fullscreenToggle.isOn;

        // apply vSync
        if (vsyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        // apply Resolution
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenToggle.isOn);
    }

    public void SetMasterVolume()
    {
        masterLabel.text = (masterSlider.value + 80).ToString();
        myMixer.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }

    public void SetMusicVolume()
    {
        musicLabel.text = (musicSlider.value + 80).ToString();
        myMixer.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public void SetSFXVolume()
    {
        sfxLabel.text = (sfxSlider.value + 80).ToString();
        myMixer.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }

    public void PlaySFXLoop()
    {
        sfxLoop.Play();
    }

    public void StopSFXLoop()
    {
        sfxLoop.Stop();
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
