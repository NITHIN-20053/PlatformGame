using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenStart : MonoBehaviour
{
    public GameObject oxygenUI;
    //public GameObject oxygenUImsg;


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
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        oxygenUImsg.SetActive(false);

    //    }
       

    //}
}
