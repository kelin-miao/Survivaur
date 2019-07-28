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
    int RefreshRate = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        //Graphics Presets
        if(graphicsPreset.value == 0)
        {
            QualitySettings.SetQualityLevel(0, true);
        }
        if (graphicsPreset.value == 1)
        {
            QualitySettings.SetQualityLevel(1, true);
        }
        if (graphicsPreset.value == 2)
        {
            QualitySettings.SetQualityLevel(2, true);
        }
        if (graphicsPreset.value == 3)
        {
            QualitySettings.SetQualityLevel(3, true);
        }
        if (graphicsPreset.value == 4)
        {
            QualitySettings.SetQualityLevel(4, true);
        }
        if (graphicsPreset.value == 5)
        {
            QualitySettings.SetQualityLevel(5, true);
        }
        //Resolutions
        if (Resolution.value == 0)
        {
            Screen.SetResolution(1024, 768, Screen.fullScreen, RefreshRate);
        }
        if (Resolution.value == 1)
        {
            Screen.SetResolution(1200, 720, Screen.fullScreen, RefreshRate);
        }
        if (Resolution.value == 2)
        {
            Screen.SetResolution(1600, 900, Screen.fullScreen, RefreshRate);
        }
        if (Resolution.value == 3)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen, RefreshRate);
        }
        if (Resolution.value == 4)
        {
            Screen.SetResolution(2560, 1440, Screen.fullScreen, RefreshRate);
        }
        if (Resolution.value == 5)
        {
            Screen.SetResolution(3840, 2160, Screen.fullScreen, RefreshRate);
        }
        //Refresh Rates
        if (RefreshDrop.value == 0)
        {
            RefreshRate = 30;
            Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, RefreshRate);
        }
        if (RefreshDrop.value == 1)
        {
            RefreshRate = 60;
            Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, RefreshRate);
        }
        if (RefreshDrop.value == 2)
        {
            RefreshRate = 70;
            Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, RefreshRate);
        }
        if (RefreshDrop.value == 3)
        {
            RefreshRate = 75;
            Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, RefreshRate);
        }
        if (RefreshDrop.value == 4)
        {
            RefreshRate = 120;
            Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, RefreshRate);
        }
        if (RefreshDrop.value == 5)
        {
            RefreshRate = 144;
            Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, RefreshRate);
        }
        if (RefreshDrop.value == 6)
        {
            RefreshRate = 180;
            Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, RefreshRate);
        }
        if (RefreshDrop.value == 7)
        {
            RefreshRate = 240;
            Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen, RefreshRate);
        }
    }
    void SwitchFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
