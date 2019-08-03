using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graphics : MonoBehaviour
{
    public Dropdown graphicsPreset;
    public Dropdown Resolution;
    public Dropdown RefreshDrop;
    public Toggle fullscreenToggle;
    public Slider VolumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        VolumeSlider.value = AudioListener.volume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = VolumeSlider.value;
    }
    void OnGUI()
    {
        PlayerPrefs.SetFloat("GlobalVolume", AudioListener.volume);

    }
    void ChangeGP()
    {
        //Graphics Presets
        if (graphicsPreset.value == 0)
        {
            QualitySettings.SetQualityLevel(0, true);
            PlayerPrefs.SetInt("GraphicsLevel", 0);
        }
        if (graphicsPreset.value == 1)
        {
            QualitySettings.SetQualityLevel(1, true);
            PlayerPrefs.SetInt("GraphicsLevel", 1);
        }
        if (graphicsPreset.value == 2)
        {
            QualitySettings.SetQualityLevel(2, true);
            PlayerPrefs.SetInt("GraphicsLevel", 2);
        }
        if (graphicsPreset.value == 3)
        {
            QualitySettings.SetQualityLevel(3, true);
            PlayerPrefs.SetInt("GraphicsLevel", 3);
        }
        if (graphicsPreset.value == 4)
        {
            QualitySettings.SetQualityLevel(4, true);
            PlayerPrefs.SetInt("GraphicsLevel", 4);
        }
        if (graphicsPreset.value == 5)
        {
            QualitySettings.SetQualityLevel(5, true);
            PlayerPrefs.SetInt("GraphicsLevel", 5);
        }
    }
    void ChangeRes()
    {
        //Resolutions
        if (Resolution.value == 0)
        {
            Screen.SetResolution(1024, 576, Screen.fullScreen, Application.targetFrameRate);
            PlayerPrefs.SetInt("ResolutionX", 1024);
            PlayerPrefs.SetInt("ResolutionX", 576);
        }
        if (Resolution.value == 1)
        {
            Screen.SetResolution(1200, 675, Screen.fullScreen, Application.targetFrameRate);
            PlayerPrefs.SetInt("ResolutionX", 1200);
            PlayerPrefs.SetInt("ResolutionX", 675);
        }
        if (Resolution.value == 2)
        {
            Screen.SetResolution(1600, 900, Screen.fullScreen, Application.targetFrameRate);
            PlayerPrefs.SetInt("ResolutionX", 1600);
            PlayerPrefs.SetInt("ResolutionX", 900);
        }
        if (Resolution.value == 3)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen, Application.targetFrameRate);
            PlayerPrefs.SetInt("ResolutionX", 1920);
            PlayerPrefs.SetInt("ResolutionX", 1080);
        }
        if (Resolution.value == 4)
        {
            Screen.SetResolution(2560, 1440, Screen.fullScreen, Application.targetFrameRate);
            PlayerPrefs.SetInt("ResolutionX", 2560);
            PlayerPrefs.SetInt("ResolutionX", 1440);
        }
        if (Resolution.value == 5)
        {
            Screen.SetResolution(3840, 2160, Screen.fullScreen, Application.targetFrameRate);
            PlayerPrefs.SetInt("ResolutionX", 3840);
            PlayerPrefs.SetInt("ResolutionX", 2160);
        }
    }
    void ChangeRef()
    {
        //Refresh Rates
        if (RefreshDrop.value == 0)
        {
            Application.targetFrameRate = 30;
            //Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, Application.targetFrameRate);
        }
        if (RefreshDrop.value == 1)
        {
            Application.targetFrameRate = 60;
            //Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, Application.targetFrameRate);
        }
        if (RefreshDrop.value == 2)
        {
            Application.targetFrameRate = 70;
            //Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, Application.targetFrameRate);
        }
        if (RefreshDrop.value == 3)
        {
            Application.targetFrameRate = 75;
            //Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, Application.targetFrameRate);
        }
        if (RefreshDrop.value == 4)
        {
            Application.targetFrameRate = 120;
            //Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, Application.targetFrameRate);
        }
        if (RefreshDrop.value == 5)
        {
            Application.targetFrameRate = 144;
            //Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, Application.targetFrameRate);
        }
        if (RefreshDrop.value == 6)
        {
            Application.targetFrameRate = 180;
            //Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, Application.targetFrameRate);
        }
        if (RefreshDrop.value == 7)
        {
            Application.targetFrameRate = 240;
            //Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, Application.targetFrameRate);
        }
    }
    void SwitchFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
