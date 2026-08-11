using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishControl : MonoBehaviour
{
    public GameObject notEnoughCoinsPanel;
    public GameObject levelCompletePanel;
    public Transform level1pos;

    public int requiredCoins = 5;

    private bool completed = false;
    public bool disableOxygenAfterFinish;

    // Final Platform Checks If Player Has Required Coin Count
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

    // Display Finish Level Panel And Take Player To New Level (Player Met The Requirement)
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

    // Display Insufficient Coin Panel (Player Did Not Meet The Requirement)
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
    }
}
