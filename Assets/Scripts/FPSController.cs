using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float setSprintbyTimes = 2.0f;

    [SerializeField] private float jump = 5.0f;
    [SerializeField] private float gravityMeasure = 1.0f;
    [SerializeField] private float crouchSpeed = 2.0f;

    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float Updownlookrage = 80f;



    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private PlayerInput playerInput;
    public bool canMove = true;
    public bool canRotate = true;

    private Vector3 currentMovement;
    private float verticalRotation;
    //private float currentSpeed => speed * (playerInput.SprintInput ? setSprintbyTimes : 1);
    //private float currentSpeed => speed * (playerInput.SprintInput && characterController.isGrounded ? setSprintbyTimes : 1);

    private float currentSpeed
    {
        get
        {
            if (playerInput.CrouchInput)
            {
                return crouchSpeed;
            }

            if (playerInput.SprintInput && characterController.isGrounded)
            {
                return speed * setSprintbyTimes;
            }

            return speed;
        }
    }

    public int coinCount = 0;
    private int unsavedMegaCoins = 0;
    public TMP_Text countText;
    public AudioClip coinPickupSound;
    public AudioSource coinAudioSource;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        coinCount = 0;
        countText.text = coinCount.ToString();

    }

    private void Update()
    {
        if (canMove)
        {
            HandleMovement();
            //HandleRotation();
        }

        if (canRotate)
        {
            HandleRotation();
        }


    }
    private Vector3 Direction()
    {
        Vector3 inputDirection = new Vector3(playerInput.MovementInput.x, 0f, playerInput.MovementInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        return worldDirection.normalized;
    }

    private void HandleJump()
    {
        if (characterController.isGrounded)
        {
            currentMovement.y = -0.5f;

            if (playerInput.JumpInput)
            {
                currentMovement.y = jump;
            }
        }
        else
        {
            currentMovement.y += Physics.gravity.y * gravityMeasure * Time.deltaTime;
        }
        
    }
    public void LaunchPlayer(float force)
    {
        currentMovement.y = force;
    }

    private void HandleMovement()
    {
        Vector3 worldDirection = Direction();
        currentMovement.x = worldDirection.x * currentSpeed;
        currentMovement.z = worldDirection.z * currentSpeed;

        HandleJump();
        characterController.Move(currentMovement * Time.deltaTime);


    }


    private void HandleHorizontalRotation(float rotation)
    {
        transform.Rotate(0, rotation, 0);

    }
    private void HandleVerticalRotation(float rotation)
    {
        //transform.Rotate(0, rotation, 0);
        verticalRotation = Mathf.Clamp(verticalRotation - rotation, -Updownlookrage, Updownlookrage);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

    }

    private void HandleRotation()
    {
        float mouseX = playerInput.RotationInput.x * mouseSensitivity;
        float mouseY = playerInput.RotationInput.y * mouseSensitivity;

        HandleHorizontalRotation(mouseX);
        HandleVerticalRotation(mouseY);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin") && other.gameObject.activeSelf)
        {
            coinAudioSource.pitch = 1f;
            coinAudioSource.PlayOneShot(coinPickupSound);

            other.gameObject.SetActive(false);
            coinCount = coinCount + 1;
            countText.text = coinCount.ToString(); //"Coins: " + coinCount;

        }
        //if (other.CompareTag("MegaCoin") && other.gameObject.activeSelf)
        //{
        //    other.gameObject.SetActive(false);

        //    coinCount += 5;

        //    countText.text = "Coins: " + coinCount;
        //}
        if (other.CompareTag("MegaCoin"))
        {
            MegaCoin megaCoin = other.GetComponent<MegaCoin>();

            coinAudioSource.pitch = 0.6f; 
            coinAudioSource.PlayOneShot(coinPickupSound);

            if (megaCoin != null)
            {
                megaCoin.CollectMegaCoin();

                coinCount += 5;
                unsavedMegaCoins += 5;

                countText.text = coinCount.ToString(); //"Coins: " + coinCount;
            }
        }

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Coin"))
    //    {
    //        Coin coin = other.GetComponent<Coin>();

    //        if (coin != null)
    //        {
    //            coin.Collect();

    //            coinCount++;

    //            countText.text = "Coins: " + coinCount;
    //        }
    //    }
    //}
    public void ResetMovement()
    {
        currentMovement = Vector3.zero;
    }
    public int GetCoinCount()
    {
        return coinCount;
    }
    public void ResetCoins()
    {
        coinCount = 0;

        if (countText != null)
        {
            countText.text = coinCount.ToString(); //"Coins: " + coinCount;
        }
    }
    public void SaveMegaCoins()
    {
        unsavedMegaCoins = 0;
    }

    public void LoseUnsavedMegaCoins()
    {
        coinCount -= unsavedMegaCoins;
        unsavedMegaCoins = 0;

        countText.text = coinCount.ToString();  //"Coins: " + coinCount;
    }




}
