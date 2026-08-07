using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class OxygenController : MonoBehaviour
{
    public Slider oxygenBar;

    public float maxVal = 100f;
    public float oxygenDecRate = 5f;
    public float oxygenIncAmt = 30f;

    private float currentOxygen;
    public bool oxygenActive;
    public GameObject oxygenUI;
    public GameObject deathText;
    public float deathDelay = 1.5f;
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
            //RespawnControl.Instance.RespawnPlayer(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oxygen"))
        {
            currentOxygen += oxygenIncAmt;
            currentOxygen = Mathf.Clamp(currentOxygen, 0, maxVal);
            oxygenBar.value = currentOxygen;
            //Destroy(other.gameObject);
            OxygenBubble bubble = other.GetComponent<OxygenBubble>();

            if (bubble != null)
            {
                bubble.CollectBubble();
            }
        }
    }
    
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


    public void ResetOxygen()
    {
        currentOxygen = maxVal;
        oxygenBar.value = currentOxygen;
    }
    public void DisableOxygen()
    {
        oxygenActive = false;

        if (oxygenUI != null)
        {
            oxygenUI.SetActive(false);
        }
    }
}


    



