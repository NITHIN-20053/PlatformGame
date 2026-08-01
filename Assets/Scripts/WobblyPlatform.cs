using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WobblyPlatform : MonoBehaviour
{
    public float wobbleAmount = 0.1f;
    public float wobbleSpeed = 12f;

    public float fallDelay = 1.0f;
    public float fallSpeed = 5f;
    public float destroyHeight = -20f;

    private Vector3 startPos;
    private bool wobbling = false;
    private bool falling = false;

    private Vector3 startPosition;
    private Quaternion startRotation;
    void Start()
    {
        startPos = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        if (wobbling && !falling)
        {
            float x = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;

            transform.position = startPos + new Vector3(x, 0, 0);
        }

        if (falling)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;


            if (transform.position.y < destroyHeight)
            {
                gameObject.SetActive(false);
            }
        }
      
    }

    public void StartWobble()
    {
        wobbling = true;

        Invoke(nameof(StartFalling), fallDelay);
    }

    public void ResetPlatform()
    {
        Debug.Log("Resetting platform: " + gameObject.name);

        gameObject.SetActive(true);

        transform.position = startPos;
        transform.rotation = startRotation;

        falling = false;
        wobbling = false;

        CancelInvoke();
    }
    private void StartFalling()
    {
        falling = true;
        wobbling = false;
    }

}
