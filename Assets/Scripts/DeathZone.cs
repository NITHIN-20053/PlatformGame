
using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject deathText;

    public float respawnDelay = 2f;
    private bool isRespawning = false;

    // Start is called before the first frame update
    public void Start()
    {
        deathText.SetActive(false);
    }

    // Player Collides With The Zone And Respawns
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isRespawning)
        {
            isRespawning = true;
            StartCoroutine(DelayedRespawn(other.gameObject, deathText));
        }
    }
    // Player Died Method (Shark, Spike)
    public void PlayerDied(GameObject player, GameObject deathMessage)
    {
        if (!isRespawning)
        {
            isRespawning = true;
            StartCoroutine(DelayedRespawn(player, deathMessage));
        }
    }
    // Respawns Player With A Delay
    IEnumerator DelayedRespawn(GameObject player, GameObject deathMessage)
    {
        // Stops Player Movement
        FPSController fps = player.GetComponent<FPSController>();

        if (fps != null)
        {
            fps.canMove = false;
        }

        deathMessage.SetActive(true);
        RespawnControl.Instance.ResetAnimals();
        yield return new WaitForSeconds(respawnDelay);
        RespawnControl.Instance.RespawnPlayer(player);

        // Player Can Move Agian
        if (fps != null)
        {
            fps.canMove = true;
            fps.ResetMovement();
        }

        deathMessage.SetActive(false);
        isRespawning = false;
    }
}

