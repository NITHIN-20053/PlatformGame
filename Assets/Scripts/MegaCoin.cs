using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaCoin : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Hide The MegaCoin Once Player Picks It Up
    public void CollectMegaCoin()
    {
        gameObject.SetActive(false);
    }

    // Reset The Mega Coin (Player Failed To Reach The CheckPoint With The MegaCoin)
    public void ResetMegaCoin()
    {
        gameObject.SetActive(true);

        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
