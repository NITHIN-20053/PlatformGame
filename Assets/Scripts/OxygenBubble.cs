using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBubble : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Set Bubble GameObject To Be Hidden
    public void CollectBubble()
    {
        gameObject.SetActive(false);
    }

    // Reset Bubbles In Same Position When Player Respawns
    public void ResetBubble()
    {
        gameObject.SetActive(true);

        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
