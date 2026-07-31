using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject levelCompletePanel;
    public Transform level1pos;

    private bool completed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (completed)
        {
            return;
        }
        
        if (other.CompareTag("Player"))
        {
            completed = true;   
            StartCoroutine(FinishLevel(other));  
        }
    }

    IEnumerator FinishLevel(Collider player)
    {
        levelCompletePanel.SetActive(true);

        yield return new WaitForSeconds(2f);

        CharacterController cc = player.GetComponentInParent<CharacterController>();

        if (cc != null)
        {
            cc.enabled = false;

            Vector3 newPosition = level1pos.position + Vector3.up * 1f;

            cc.transform.position = newPosition;

            cc.enabled = true;

            FPSController fps = cc.GetComponent<FPSController>();

            if (fps != null)
            {
                fps.ResetMovement();
            }

            RespawnControl.Instance.respawnPosition.position = newPosition;
        }

        levelCompletePanel.SetActive(false);
    }

}
