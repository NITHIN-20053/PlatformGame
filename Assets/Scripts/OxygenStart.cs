using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenStart : MonoBehaviour
{
    public GameObject oxygenUI;

    // Oxygen Tank Breaks Enable Oxygen Level Display
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OxygenController oxygen = other.GetComponent<OxygenController>();

            if (oxygen != null)
            {
                oxygen.oxygenActive = true;
                oxygenUI.SetActive(true);

                Debug.Log("Oxygen started");
            }
      
        }

    }

}
