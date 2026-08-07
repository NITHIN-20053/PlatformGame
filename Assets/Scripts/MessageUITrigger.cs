using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUITrigger : MonoBehaviour
{

    public GameObject messagePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messagePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GetComponent<BoxCollider>().enabled = false;

         
        }
    }

    public void CloseMessage()
    {
        messagePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
