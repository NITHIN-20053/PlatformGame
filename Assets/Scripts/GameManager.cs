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
    private bool gamePaused = false;
    private bool escapeWasPressed = false;
    public FPSController fpsController;
    public Slider volumeSlider;
    public AudioSource musicAudioSource;


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

    public void TogglePause()
    {
        gamePaused = !gamePaused;
        gameManagerPanel.SetActive(gamePaused);

        if (gamePaused)
        {
            fpsController.canMove = false;
            fpsController.canRotate = false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
           
        
        }
        else
        {
            fpsController.canMove = true;
            fpsController.canRotate = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
         


        }
    }
    public void Displaylevel2Hints()
    {
        HintsPanellevel1.SetActive(false);
        HintsPanellevel3.SetActive(false);
        HintsPanellevel2.SetActive(true);
    }
    public void Displaylevel3Hints()
    {
        HintsPanellevel1.SetActive(false);
        HintsPanellevel2.SetActive(false);
        HintsPanellevel3.SetActive(true);
    
    }
    public void Displaylevel1Hints()
    {
        HintsPanellevel1.SetActive(true);
        HintsPanellevel2.SetActive(false);
        HintsPanellevel3.SetActive(false);

    }

    public void ChangeVolume()
    {
        musicAudioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("GameVolume", volumeSlider.value);
        PlayerPrefs.Save();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void BackToGameManagerPanel()
    {
        HintsPanel.SetActive(false);
        gameManagerPanel.SetActive(true);

    }
    public void ToHintsPanel()
    {
        HintsPanel.SetActive(true);
        gameManagerPanel.SetActive(false);

    }


}
