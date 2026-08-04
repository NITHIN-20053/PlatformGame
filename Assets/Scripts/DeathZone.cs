using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnControl.Instance.RespawnPlayer(other.gameObject);
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

}
