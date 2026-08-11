//using System.Collections;
//using System.Collections.Generic;
using TMPro;
//using Unity.VisualScripting.InputSystem;
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

    private Vector3 currentMovement;
    private float verticalRotation;

    public int coinCount = 0;
    private int unsavedMegaCoins = 0;

    public TMP_Text countText;
    public AudioClip coinPickupSound;
    public AudioSource coinAudioSource;

    public bool canMove = true;
    public bool canRotate = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        coinCount = 0;
        countText.text = coinCount.ToString();

    }
    // Update is called once per frame
    private void Update()
    {
        if (canMove)
        {
            HandleMovement();
        }
        if (canRotate)
        {
            HandleRotation();
        }
    }

    // Jump Method
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
    // JumpPad Method
    public void LaunchPlayer(float force)
    {
        currentMovement.y = force;
    }

    // PlayerMovement (Crouch,Sprint)
    private float GetCurrentSpeed()
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

    // Player Movement
    private void HandleMovement()
    {
        Vector3 worldDirection = Direction();

        float currentSpeed = GetCurrentSpeed();
        currentMovement.x = worldDirection.x * currentSpeed;
        currentMovement.z = worldDirection.z * currentSpeed;
        HandleJump();
        characterController.Move(currentMovement * Time.deltaTime);
    }

    // Player Rotation Methods
    private void HandleHorizontalRotation(float rotation)
    {
        transform.Rotate(0, rotation, 0);

    }
    private void HandleVerticalRotation(float rotation)
    {
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

    // Coin and MegaCoin Collecting Code
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin") && other.gameObject.activeSelf)
        {
            coinAudioSource.pitch = 1f;
            coinAudioSource.PlayOneShot(coinPickupSound);

            other.gameObject.SetActive(false);
            coinCount = coinCount + 1;
            countText.text = coinCount.ToString(); 

        }

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

                countText.text = coinCount.ToString(); 
            }
        }

    }

    // CoinCount Method
    public int GetCoinCount()
    {
        return coinCount;
    }

    // Coin Reset Method
    public void ResetCoins()
    {
        coinCount = 0;

        if (countText != null)
        {
            countText.text = coinCount.ToString(); 
        }
    }
    // MegCoin Save
    public void SaveMegaCoins()
    {
        unsavedMegaCoins = 0;
    }

    // MegaCoin Unsaved
    public void LoseUnsavedMegaCoins()
    {
        coinCount -= unsavedMegaCoins;
        unsavedMegaCoins = 0;

        countText.text = coinCount.ToString();  
    }
    public void ResetMovement()
    {
        currentMovement = Vector3.zero;
    }
    private Vector3 Direction()
    {
        Vector3 inputDirection = new Vector3(playerInput.MovementInput.x, 0f, playerInput.MovementInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        return worldDirection.normalized;
    }
}
