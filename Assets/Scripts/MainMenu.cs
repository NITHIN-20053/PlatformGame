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

    // Start is called before the first frame update
    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 0.5f);
        volumeSlider.value = savedVolume;
        menuMusic.volume = savedVolume;
    }

    // Volume Change Between Scenes
    public void ChangeVolume()
    {
        menuMusic.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("GameVolume", volumeSlider.value);
        PlayerPrefs.Save();
    }
    // Buttom Method To LevelInfoPanel 
    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        levelInfoPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
    // Button Method to Settings
    public void Settings()
    {
        mainMenuPanel.SetActive(false);
        levelInfoPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    // Button Method to MainMenu
    public void BackToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        levelInfoPanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }
    // Button Method to Begin The Game
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

}
