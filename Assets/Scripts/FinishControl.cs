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

    public GameObject notEnoughCoinsPanel;
    public int requiredCoins = 5;

    private bool completed = false;
    public bool disableOxygenAfterFinish;

    private void OnTriggerEnter(Collider other)
    {
        if (completed)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            FPSController fps = other.GetComponent<FPSController>();

            if (fps != null)
            {
                if (fps.GetCoinCount() >= requiredCoins)
                {
                    completed = true;
                    StartCoroutine(FinishLevel(other));
                }
                else
                {
                    StartCoroutine(NotEnoughCoins(other));
                }
            }
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
                fps.ResetCoins();
            }

            RespawnControl.Instance.respawnPosition.position = newPosition;
            OxygenController oxygen = cc.GetComponent<OxygenController>();

            if (oxygen != null)
            {
                if (disableOxygenAfterFinish)
                {
                    oxygen.DisableOxygen();
                }
                else
                {
                    oxygen.ResetOxygen();
                }
            }
        }

        levelCompletePanel.SetActive(false);
    }
    IEnumerator NotEnoughCoins(Collider player)
    {
        notEnoughCoinsPanel.SetActive(true);

        yield return new WaitForSeconds(2f);

        notEnoughCoinsPanel.SetActive(false);
        CharacterController cc = player.GetComponentInParent<CharacterController>();

        if (cc != null)
        {
            RespawnControl.Instance.RespawnPlayer(cc.gameObject);

            FPSController fps = cc.GetComponent<FPSController>();

            if (fps != null)
            {
                fps.ResetMovement();
            }
        }

        //CharacterController cc = player.GetComponentInParent<CharacterController>();

        //if (cc != null)
        //{
        //    cc.enabled = false;

        //    cc.transform.position = RespawnControl.Instance.respawnPosition.position;

        //    cc.enabled = true;

        //    FPSController fps = cc.GetComponent<FPSController>();

        //    if (fps != null)
        //    {
        //        fps.ResetMovement();
        //    }
        //}
    }

}
