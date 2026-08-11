using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrapOctopus : MonoBehaviour
{
    public GameObject inkImage;
    public GameObject timerPanel;

    public Slider timerSlider;
    private Coroutine trapCoroutine;

    public float effectTime = 7f;

    // Start is called before the first frame update
    private void Start()
    {
        inkImage.SetActive(false);
        timerPanel.SetActive(false);
    }

    // When Player Collides With The Octopus 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Restart the effect if the player touches the octopus again
            if (trapCoroutine != null)
            {
                StopCoroutine(trapCoroutine);
            }

            trapCoroutine = StartCoroutine(InkEffect());
        }
    }

    // Ink Over Screen From Octopus Hinders Player Vision 
    IEnumerator InkEffect()
    {
        inkImage.SetActive(true);
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

        inkImage.SetActive(false);
        timerPanel.SetActive(false);

        trapCoroutine = null;
    }
}
