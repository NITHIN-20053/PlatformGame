using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControl : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    //public BoxCollider trigger;
    //private float respawnHeightOffset = 2f;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        RespawnControl.Instance.respawnPosition.position = transform.position + Vector3.up * respawnHeightOffset;
    //        trigger.enabled = false;
    //        Debug.Log("New checkpoint saved: " + transform.position);

    //    }
    //}
    public BoxCollider trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnControl.Instance.respawnPosition = transform;

            trigger.enabled = false;

            Debug.Log("New checkpoint saved: " + transform.position);
        }
    }
}

