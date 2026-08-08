using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogTrigger : MonoBehaviour
{
    public GameObject directionalLight;
    public GameObject water;
    public GameObject plane1;
  
    private void OnTriggerEnter(Collider other)
    {
            
        if (other.CompareTag("Player"))
        {
            RenderSettings.fogMode = FogMode.Exponential;
            RenderSettings.fogColor = Color.white;
            RenderSettings.fogDensity = 0.005f;
            directionalLight.SetActive(true);
            water.SetActive(true);
            plane1.SetActive(true);


        }
    }
}
