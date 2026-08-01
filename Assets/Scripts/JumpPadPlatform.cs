using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadPlatform : MonoBehaviour
{
    public float jumpForce = 15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FPSController player = other.GetComponent<FPSController>();

            if (player != null)
            {
                player.LaunchPlayer(jumpForce);
            }
        }
    }
}
