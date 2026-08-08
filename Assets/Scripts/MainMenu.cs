using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelInfoPanel;
    public GameObject SettingsPanel;
    public Slider volumeSlider;
    public AudioSource menuMusic;



    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 0.5f);
        volumeSlider.value = savedVolume;
        menuMusic.volume = savedVolume;
    }

    public void ChangeVolume()
    {
        menuMusic.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("GameVolume", volumeSlider.value);
        PlayerPrefs.Save();
    }
    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        levelInfoPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
    public void Settings()
    {
        mainMenuPanel.SetActive(false);
        levelInfoPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        levelInfoPanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
