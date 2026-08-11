using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FogTrigger : MonoBehaviour
{
    public GameObject directionalLight;
    public GameObject water;
    public GameObject plane1;
    public GameObject coinUI;
    public GameObject surfaceCamera; 
    public GameObject fadePanel;
    public GameObject credits;
    public GameObject mainMenuButton;

    public Transform cameraEndPoint;
    private Image fadeImage; 
    private Camera playerCamera;
    public Animator creditsAnimator;

    public float delayBeforeFade = 2f;
    public float fadeTime = 1.5f;
    public float cameraMoveTime = 6f;

    // Start is called before the first frame update
    public void Start()
    {
        fadeImage = fadePanel.GetComponent<Image>();
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;

        playerCamera = Camera.main;
        surfaceCamera.SetActive(false);
    }
    // Change Light And Other Settings As Player Is At The Surface
    private void OnTriggerEnter(Collider other)
    {
            
        if (other.CompareTag("Player"))
        {
            RenderSettings.fogMode = FogMode.Exponential;
            RenderSettings.fogColor = Color.white;
            RenderSettings.fogDensity = 0.005f;
            directionalLight.SetActive(true);
            water.SetActive(true);
            coinUI.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(ActivatePlane());
            StartCoroutine(FinalSequence());

        }
    }
    // Plane Enabled Acts As Support For Player To Stand 
    IEnumerator ActivatePlane()
    {
        yield return new WaitForSeconds(2f);
        plane1.SetActive(true);
    }
    // Fade Transition Once Player Reached The Surface
    IEnumerator FinalSequence()
    {
        yield return new WaitForSeconds(delayBeforeFade);
        yield return StartCoroutine(Fade(0f, 1f));
        playerCamera.enabled = false;
        surfaceCamera.SetActive(true);
   
        credits.SetActive(true);
        creditsAnimator.Play("CreditsAnimation");
        StartCoroutine(ShowMainMenuButton());
        Vector3 startPosition = surfaceCamera.transform.position;
        Quaternion startRotation = surfaceCamera.transform.rotation;

        float timer = 0f;

        yield return StartCoroutine(Fade(1f, 0f));

        while (timer < cameraMoveTime)
        {
            timer += Time.deltaTime;
            float progress = timer / cameraMoveTime;

            surfaceCamera.transform.position = Vector3.Lerp(startPosition, cameraEndPoint.position, progress);
            surfaceCamera.transform.rotation = Quaternion.Slerp(startRotation, cameraEndPoint.rotation, progress);
            yield return null;
        }

        surfaceCamera.transform.position = cameraEndPoint.position;
        surfaceCamera.transform.rotation = cameraEndPoint.rotation;

    }

    // Exit Button Method
    public void GoToMainMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }

    // Display Button On Screen After A Duration Into The Credits
    IEnumerator ShowMainMenuButton()
    {
        yield return new WaitForSeconds(15f);
        mainMenuButton.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Fade Transition
    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float timer = 0f; 
        Color color = fadeImage.color;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, timer / fadeTime);

            color.a = alpha;
            fadeImage.color = color;
            yield return null;
        }

            color.a = endAlpha;
            fadeImage.color = color;
    }
}

