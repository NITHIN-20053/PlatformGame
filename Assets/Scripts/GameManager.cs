using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject gameManagerPanel;
    public GameObject HintsPanel;
    public GameObject HintsPanellevel1;
    public GameObject HintsPanellevel2;
    public GameObject HintsPanellevel3;

    public PlayerInput playerInput;
    public FPSController fpsController;
    public Slider volumeSlider;
    public AudioSource musicAudioSource;

    private bool gamePaused = false;
    private bool escapeWasPressed = false;

    // Start is called before the first frame update
    private void Start()
    {
        gameManagerPanel.SetActive(false);
        fpsController.canMove = true;
        fpsController.canRotate = true;

        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 0.5f);
        volumeSlider.value = savedVolume;
        musicAudioSource.volume = savedVolume;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    private void Update()
    {

        if (playerInput.EscapeButtonInput && !escapeWasPressed)
        {
            TogglePause();
            escapeWasPressed = true;
        }

        if (!playerInput.EscapeButtonInput)
        {
            escapeWasPressed = false;
        }
    }

    // Tab Button Toggle for Menu
    public void TogglePause()
    {
        gamePaused = !gamePaused;
        gameManagerPanel.SetActive(gamePaused);

        if (gamePaused)
        {
            // Player Can't Move Or Rotate
            fpsController.canMove = false;
            fpsController.canRotate = false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        
        }
        else
        {
            // Player Can Move And Rotate Now
            fpsController.canMove = true;
            fpsController.canRotate = true;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
  
        }
    }
    // Show Level 1 Hints Panel
    public void Displaylevel1Hints()
    {
        HintsPanellevel1.SetActive(true);
        HintsPanellevel2.SetActive(false);
        HintsPanellevel3.SetActive(false);
    }

    // Show Level 2 Hints Panel
    public void Displaylevel2Hints()
    {
        HintsPanellevel1.SetActive(false);
        HintsPanellevel3.SetActive(false);
        HintsPanellevel2.SetActive(true);
    }
    // Show Level 3 Hints Panel
    public void Displaylevel3Hints()
    {
        HintsPanellevel1.SetActive(false);
        HintsPanellevel2.SetActive(false);
        HintsPanellevel3.SetActive(true);
    }

    // Volume Slider Change (Updates Between Scenes)
    public void ChangeVolume()
    {
        musicAudioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("GameVolume", volumeSlider.value);
        PlayerPrefs.Save();
    }

    // Game Restart From Tutorial
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    // Exit Game To Main Menu
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Go Back To Hints Panel
    public void ToHintsPanel()
    {
        HintsPanel.SetActive(true);
        gameManagerPanel.SetActive(false);

    }
    // Go Back To Menu Panel From Hints Panel
    public void BackToGameManagerPanel()
    {
        HintsPanel.SetActive(false);
        gameManagerPanel.SetActive(true);

    }

}
