using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaCoin : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void CollectMegaCoin()
    {
        gameObject.SetActive(false);
    }

    public void ResetMegaCoin()
    {
        gameObject.SetActive(true);

        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
