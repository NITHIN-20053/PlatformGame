using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Transform respawnPosition;
    public static RespawnControl Instance;
    public WobblyPlatform[] platforms;
    public EnemyAI[] enemies;
    public OxygenBubble[] oxygenBubbles;
    public MegaCoin[] megaCoins;
    private void Awake()
    {
        Instance = this;
    }
    public void ResetAnimals()
    {
        foreach (EnemyAI enemy in enemies)
        {
            enemy.ResetEnemy();
        }
    }
    public void RespawnPlayer(GameObject player)
    {
        player.transform.SetParent(null, true);
        CharacterController cc = player.GetComponent<CharacterController>();

        if (cc != null)
            cc.enabled = false;


        player.transform.position = respawnPosition.position;


        if (cc != null)
            cc.enabled = true;


        // Reset oxygen
        OxygenController oxygen = player.GetComponent<OxygenController>();

        if (oxygen != null)
        {
            oxygen.ResetOxygen();
        }
        FPSController fps = player.GetComponent<FPSController>();

        if (fps != null)
        {
            fps.LoseUnsavedMegaCoins();
        }


        // Reset platforms
        foreach (WobblyPlatform platform in platforms)
        {
            platform.ResetPlatform();
        }


        // Reset enemies
        //foreach (EnemyAI enemy in enemies)
        //{
        //    enemy.ResetEnemy();
        //}
        foreach (OxygenBubble bubble in oxygenBubbles)
        {
            bubble.ResetBubble();
        }
        foreach (MegaCoin megaCoin in megaCoins)
        {
            megaCoin.ResetMegaCoin();
        }



        Debug.Log("Player Respawned");
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        other.transform.position = respawnPosition.position;
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        CharacterController cc = other.GetComponent<CharacterController>();

    //        if (cc != null)
    //            cc.enabled = false;

    //        other.transform.position = respawnPosition.position;

    //        if (cc != null)
    //            cc.enabled = true;

    //        foreach (WobblyPlatform platform in platforms)
    //        {
    //            platform.ResetPlatform();
    //        }
    //        foreach (EnemyAI enemy in RespawnControl.Instance.enemies)
    //        {
    //            enemy.ResetEnemy();
    //        }
    //        //Debug.Log("Number of coins to reset: " + coins.Length);

    //        //foreach (Coin coin in coins)
    //        //{
    //        //    coin.ResetCoin();
    //        //}


    //    }
    //}
}
