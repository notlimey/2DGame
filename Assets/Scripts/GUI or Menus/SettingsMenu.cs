using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Toggle fullscreenToggle;
    public Slider volumeSlider;
    public TMP_Dropdown textureQualityDropdown;

    public string[] qualitySettings;

    public Settings gameSettings;

    void Start()
    {
        gameSettings = new Settings();
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        
        LoadSettings();
    }

    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
        SaveSettings();
    }

    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
        SaveSettings();
    }

    public void OnVolumeChange()
    {
        audioMixer.SetFloat("volume", volumeSlider.value);
        gameSettings.volume = volumeSlider.value;
    }

    public void SaveSettings()
    {
        SaveSystem.SaveSettings(gameSettings);
    }
    public void ApplyChanges()
    {
        SaveSettings();
        Debug.Log(textureQualityDropdown.itemText);
    }

    public void LoadSettings()
    {
        gameSettings = SaveSystem.LoadSettings() ?? new Settings {volume = 1f, fullscreen = true, textureQuality = 0};
        volumeSlider.value = gameSettings.volume;
        textureQualityDropdown.value = gameSettings.textureQuality;
        fullscreenToggle.isOn = gameSettings.fullscreen;
        Screen.fullScreen = gameSettings.fullscreen;
    }

}
