using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartMessage : MonoBehaviour
{
    public GameObject messagePanel;
    private bool messageSeen = false;
    public FPSController fpsController;

    private void OnTriggerEnter(Collider other) 
    { 
        if (other.CompareTag("Player") && !messageSeen) 
        { 
            messagePanel.SetActive(true); 
            messageSeen = true;

            fpsController.canMove = false; 
            fpsController.canRotate = false;

            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;
        } 
    }
    public void CloseMessage() 
    { 
        messagePanel.SetActive(false);

        fpsController.canMove = true;
        fpsController.canRotate = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
