using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBubble : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void CollectBubble()
    {
        gameObject.SetActive(false);
    }

    public void ResetBubble()
    {
        gameObject.SetActive(true);

        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
