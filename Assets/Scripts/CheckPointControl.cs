using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.BoolParameter;

public class CheckPointControl : MonoBehaviour
{
    public BoxCollider trigger;
    public GameObject checkpointPanel;
    public GameObject checkPointParitclesEffect;

    // CheckPoint Saved As Respawn Position
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnControl.Instance.respawnPosition = transform;
            FPSController fps = other.GetComponent<FPSController>();

            // Mega Coins Counted As Player Reached Checkpoint
            if (fps != null)
            {
                fps.SaveMegaCoins();
            }

            trigger.enabled = false;
            checkPointParitclesEffect.SetActive(false);
            StartCoroutine(ShowCheckpointPanel());

        }
    }
    // Show Checkpoint panel for 3 seconds 
    IEnumerator ShowCheckpointPanel()
    {
        checkpointPanel.SetActive(true);

        yield return new WaitForSeconds(3f);

        checkpointPanel.SetActive(false);

    }
}

