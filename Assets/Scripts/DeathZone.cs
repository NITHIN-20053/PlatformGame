
using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    public float respawnDelay = 2f;
    public GameObject deathText;
    private bool isRespawning = false;

    public void Start()
    {
        deathText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isRespawning)
        {
            isRespawning = true;
            StartCoroutine(DelayedRespawn(other.gameObject, deathText));
        }
    }
    public void PlayerDied(GameObject player, GameObject deathMessage)
    {
        if (!isRespawning)
        {
            isRespawning = true;
            StartCoroutine(DelayedRespawn(player, deathMessage));
        }
    }
    IEnumerator DelayedRespawn(GameObject player, GameObject deathMessage)
    {
        FPSController fps = player.GetComponent<FPSController>();

        if (fps != null)
        {
            fps.canMove = false;
        }
        deathMessage.SetActive(true);
        RespawnControl.Instance.ResetAnimals();
        yield return new WaitForSeconds(respawnDelay);
        RespawnControl.Instance.RespawnPlayer(player);

        if (fps!= null)
        {
            fps.canMove = true;
            fps.ResetMovement();
        }

        deathMessage.SetActive(false);
        isRespawning = false;
    }
}


    













//private void OnTriggerEnter(Collider other)
//{
//    if (other.CompareTag("Player"))
//    {
//        CharacterController cc = other.GetComponent<CharacterController>();

//        if (cc != null)
//            cc.enabled = false;

//        other.transform.position = RespawnControl.Instance.respawnPosition.position;

//        if (cc != null)
//            cc.enabled = true;

//        Debug.Log("Player respawned");

//        foreach (WobblyPlatform platform in RespawnControl.Instance.platforms)
//        {
//            platform.ResetPlatform();
//        }
//        foreach (EnemyAI enemy in RespawnControl.Instance.enemies)
//        {
//            enemy.ResetEnemy();
//        }

//        //foreach (Coin coin in RespawnControl.Instance.coins)
//        //{
//        //    Debug.Log("Resetting coin: " + coin.name);
//        //    coin.ResetCoin();
//        //}
//    }
//}


