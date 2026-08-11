using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TrapGV : MonoBehaviour
{
    public GameObject globalVolume;
    public GameObject timerPanel;

    public Slider timerSlider;
    private Coroutine trapCoroutine;

    public float effectTime = 7f;


    // Start is called before the first frame update
    private void Start()
    {
        timerPanel.SetActive(false);
        globalVolume.SetActive(false);
    }

    // Player Collides With StarFish Effect Enable Hinders Player Vision
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset timer if already active
            if (trapCoroutine != null)
            {
                StopCoroutine(trapCoroutine);
            }

            trapCoroutine = StartCoroutine(ActivateEffect());
        }
    }
    // Run Effect For A Specific Duration
    IEnumerator ActivateEffect()
    {
        globalVolume.SetActive(true);
        timerPanel.SetActive(true);

        float timeRemaining = effectTime;

        timerSlider.maxValue = effectTime;
        timerSlider.value = effectTime;

        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            timerSlider.value = timeRemaining;

            yield return null;
        }

        globalVolume.SetActive(false);
        timerPanel.SetActive(false);

        trapCoroutine = null;
    }
}