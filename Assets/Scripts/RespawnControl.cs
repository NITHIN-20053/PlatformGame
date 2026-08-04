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
    private void Awake()
    {
        Instance = this;
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
