using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleTrigger : MonoBehaviour
{

    private WobblyPlatform platform;

    void Start()
    {
        platform = GetComponentInParent<WobblyPlatform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            platform.StartWobble();
        }
    }
}
