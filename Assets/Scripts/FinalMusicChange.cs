using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class FinalMusicChange : MonoBehaviour
{
    public GameManager gameManager;
    public AudioClip finalMusic;
    public float musicFade = 2f;


    private bool musicChanged = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !musicChanged)
        {
            musicChanged = true;
            StartCoroutine(ChangeMusic());
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    IEnumerator ChangeMusic()
    {
        float startVol = gameManager.musicAudioSource.volume;
        float timer = 0f;

        while (timer < musicFade) 
        {
            timer = timer + Time.deltaTime;
            gameManager.musicAudioSource.volume = Mathf.Lerp(startVol, 0f, timer / musicFade);
            yield return null;
        }

        gameManager.musicAudioSource.Stop();
        gameManager.musicAudioSource.clip = finalMusic;
        gameManager.musicAudioSource.Play();

        while (timer < musicFade)
        {
            timer = timer + Time.deltaTime;
            gameManager.musicAudioSource.volume = Mathf.Lerp(0f, startVol, timer / musicFade);
            yield return null;
        }
        gameManager.musicAudioSource.volume = startVol;
    }
}
