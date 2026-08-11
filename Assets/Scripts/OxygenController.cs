using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class OxygenController : MonoBehaviour
{
    public Slider oxygenBar;
    public GameObject oxygenUI;
    public GameObject deathText;

    public AudioClip oxygenPickupSound;
    public AudioSource oxygenAudioSource;

    public float maxVal = 100f;
    public float oxygenDecRate = 5f;
    public float oxygenIncAmt = 30f;

    public float deathDelay = 1.5f;
    private float currentOxygen;

    public bool oxygenActive;
    private bool isDying = false;

    // Start is called before the first frame update
    void Start()
    {
        currentOxygen = maxVal;
        oxygenBar.value = currentOxygen;

        if (deathText != null) 
        { 
            deathText.SetActive(false); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!oxygenActive || isDying)
        {
            return;
        }

        currentOxygen -= oxygenDecRate * Time.deltaTime;
        currentOxygen = Mathf.Clamp(currentOxygen, 0, maxVal);

        oxygenBar.value = currentOxygen;

        if (currentOxygen <= 0)
        {
            StartCoroutine(OxygenDeath());
        }
    }
    // Oxygen Bubble 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oxygen"))
        {
            currentOxygen += oxygenIncAmt;
            currentOxygen = Mathf.Clamp(currentOxygen, 0, maxVal);
            oxygenBar.value = currentOxygen;
            if (oxygenAudioSource != null && oxygenPickupSound != null) 
            { 
                oxygenAudioSource.PlayOneShot(oxygenPickupSound); 
            }
            OxygenBubble bubble = other.GetComponent<OxygenBubble>();

            if (bubble != null)
            {
                bubble.CollectBubble();
            }
        }
    }
    
    // Ran out of oxygen
    IEnumerator OxygenDeath()
    {
        isDying = true;
        FPSController fps = GetComponent<FPSController>();
        if (fps != null)
        {
            fps.canMove = false;
        }
        if (deathText != null)
        {
            deathText.SetActive(true);
        }
        yield return new WaitForSeconds(deathDelay);

        RespawnControl.Instance.RespawnPlayer(gameObject);

        ResetOxygen();

        if (deathText != null)
        {
            deathText.SetActive(false);
        }
        if (fps != null)
        {
            fps.canMove = true;
            fps.ResetMovement();
        }
        isDying = false;
    }

    // Oxygen Reset
    public void ResetOxygen()
    {
        currentOxygen = maxVal;
        oxygenBar.value = currentOxygen;
    }
    // Disabling Oxygen - At end of level 2 
    public void DisableOxygen()
    {
        oxygenActive = false;

        if (oxygenUI != null)
        {
            oxygenUI.SetActive(false);
        }
    }
}


    



