using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TrapGV : MonoBehaviour
{
    public GameObject globalVolume;
    public float effectTime = 7f;

    public GameObject timerPanel;
    public Slider timerSlider;

    private Coroutine trapCoroutine;

    private void Start()
    {
        timerPanel.SetActive(false);
        globalVolume.SetActive(false);
    }

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