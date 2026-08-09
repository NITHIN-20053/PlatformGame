using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUITrigger : MonoBehaviour
{

    public GameObject messagePanel;

    //private Coroutine messageCoroutine;
    //public float displayTime = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messagePanel.SetActive(true);
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            //GetComponent<BoxCollider>().enabled = false;
            //messageCoroutine = StartCoroutine(AutoCloseMessage());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messagePanel.SetActive(false);
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            //GetComponent<BoxCollider>().enabled = false;
            //messageCoroutine = StartCoroutine(AutoCloseMessage());
        }
    }
    //IEnumerator AutoCloseMessage()
    //{
    //    yield return new WaitForSeconds(displayTime);
    //    messagePanel.SetActive(false);

    //    //CloseMessage();
    //}

    //public void CloseMessage()
    //{
    //    if (messageCoroutine != null)
    //    {
    //        StopCoroutine(messageCoroutine);
    //    }
    //    messagePanel.SetActive(false);
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}
}
