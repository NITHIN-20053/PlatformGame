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
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit: " + other.name);

        if (other.CompareTag("Player"))
        {
            //Debug.Log("Respawning");

            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
                cc.enabled = false;

            other.transform.position = respawnPosition.position;

            if (cc != null)
                cc.enabled = true;
        }
    }
}
