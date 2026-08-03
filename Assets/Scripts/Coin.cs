//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Coin : MonoBehaviour
//{
//    private Vector3 startPosition;
//    private Quaternion startRotation;

//    void Start()
//    {
//        startPosition = transform.position;
//        startRotation = transform.rotation;
//    }

//    public void Collect()
//    {
//        gameObject.SetActive(false);
//    }

//    public void ResetCoin()
//    {
//        Debug.Log("Resetting coin: " + gameObject.name);

//        gameObject.SetActive(true);

//        transform.position = startPosition;
//        transform.rotation = startRotation;
//    }
//}
