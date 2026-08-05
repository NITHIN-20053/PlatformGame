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

    // Start is called before the first frame update
    void Start()
    {
        currentOxygen = maxVal;
        oxygenBar.value = currentOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        if (!oxygenActive)
        {
            return;
        }

        currentOxygen -= oxygenDecRate * Time.deltaTime;
        currentOxygen = Mathf.Clamp(currentOxygen, 0, maxVal);

        oxygenBar.value = currentOxygen;

        if (currentOxygen <= 0)
        {
            RespawnControl.Instance.RespawnPlayer(gameObject);
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

    public void ResetOxygen()
    {
        currentOxygen = maxVal;
        oxygenBar.value = currentOxygen;
    }
}


    



