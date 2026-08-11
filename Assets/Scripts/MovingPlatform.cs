using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 movementDirection = Vector3.right;
    private Vector3 startPosition;

    public float distance = 5f;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Mathf.Sin(Time.time * speed) * distance;

        transform.position = startPosition + movementDirection.normalized * movement;
    }

}
