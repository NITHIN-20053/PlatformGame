using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 movementDirection = Vector3.right;
    public float distance = 5f;
    public float speed = 2f;

    private Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float movement = Mathf.Sin(Time.time * speed) * distance;

        transform.position = startPosition + movementDirection.normalized * movement;
    }

}
