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

    // Start is called before the first frame update
    void Start()
    {
        currentOxygen = maxVal;
        oxygenBar.value = currentOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        currentOxygen -= oxygenDecRate * Time.deltaTime;
        currentOxygen = Mathf.Clamp(currentOxygen, 0, maxVal);
        oxygenBar.value = currentOxygen;

        //if (currentOxygen <= 0)
        //{
        //    Debug.Log("Player ran out of O2");
        //    RespawnPlayer();

        //}
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
            Destroy(other.gameObject);
        }
    }

    public void ResetOxygen()
    {
        currentOxygen = maxVal;
        oxygenBar.value = currentOxygen;
    }
}


    



