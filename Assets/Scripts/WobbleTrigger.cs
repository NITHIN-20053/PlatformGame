using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleTrigger : MonoBehaviour
{
    private WobblyPlatform platform;

    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponentInParent<WobblyPlatform>();
    }

    // Start Wobble When Player Enter Collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            platform.StartWobble();
        }
    }
}
