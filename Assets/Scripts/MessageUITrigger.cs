using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUITrigger : MonoBehaviour
{
    public GameObject messagePanel;

    // Player Enter Collider Display Panel
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messagePanel.SetActive(true);
        }
    }
    // Player Exits Collider Hide Panel
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messagePanel.SetActive(false);
        }
    }
}
