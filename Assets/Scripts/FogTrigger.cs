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

    public Transform cameraEndPoint;

    public float delayBeforeFade = 2f;
    public float fadeTime = 1.5f; 
    public float cameraMoveTime = 6f;

    private Image fadeImage; 
    private Camera playerCamera;

    public GameObject credits;
    public Animator creditsAnimator;
    public GameObject mainMenuButton;
    //public float creditsDuration = 39f;

    public void Start()
    {
        fadeImage = fadePanel.GetComponent<Image>();
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;

        playerCamera = Camera.main;
        surfaceCamera.SetActive(false);
    }
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
    IEnumerator ActivatePlane()
    {
        yield return new WaitForSeconds(2f);
        plane1.SetActive(true);
    }
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

        //yield return new WaitForSeconds(creditsDuration);

        //SceneManager.LoadScene("MainMenu");
    }
    public void GoToMainMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator ShowMainMenuButton()
    {
        yield return new WaitForSeconds(15f);
        mainMenuButton.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }





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

