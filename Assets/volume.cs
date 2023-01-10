using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volume : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropDown;

    Resolution[] resolutions;

/*    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length i++)
        {
            string options = 
        }
        resolutionDropDown.AddOptions();
    }*/
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);

    }
     public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    
}
