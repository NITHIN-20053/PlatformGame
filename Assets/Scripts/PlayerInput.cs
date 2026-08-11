using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControl;

    [SerializeField] private string actionMapName = "Player";
    [SerializeField] private string movement = "Movement";
    [SerializeField] private string rotation = "Rotation";
    [SerializeField] private string jump = "Jump";
    [SerializeField] private string sprint = "Sprint";
    [SerializeField] private string crouch = "Crouch";
    [SerializeField] private string escapeButton = "Escape";

    private InputAction movementAction;
    private InputAction rotationAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private InputAction crouchAction;
    private InputAction escapeButtonAction;

    public Vector2 MovementInput;
    public Vector2 RotationInput;

    public bool JumpInput;
    public bool SprintInput;
    public bool CrouchInput;
    public bool EscapeButtonInput;
    private void Awake()
    {
        InputActionMap mapref = playerControl.FindActionMap(actionMapName);
        movementAction = mapref.FindAction(movement);
        rotationAction = mapref.FindAction(rotation);
        jumpAction = mapref.FindAction(jump);
        sprintAction = mapref.FindAction(sprint);
        crouchAction = mapref.FindAction(crouch);
        escapeButtonAction = mapref.FindAction(escapeButton);

        PlayerControl();

    }

    // Player Actions 
    private void PlayerControl()
    {
        movementAction.performed += inputInfo => MovementInput = inputInfo.ReadValue <Vector2>();
        movementAction.canceled += inputInfo => MovementInput = Vector2.zero;

        rotationAction.performed += inputInfo => RotationInput = inputInfo.ReadValue <Vector2>();
        rotationAction.canceled += inputInfo => RotationInput = Vector2.zero;

        jumpAction.performed += inputInfo => JumpInput = true;
        jumpAction.canceled += inputInfo => JumpInput = false;

        sprintAction.performed += inputInfo => SprintInput = true;
        sprintAction.canceled += inputInfo => SprintInput = false;

        crouchAction.performed += inputInfo => CrouchInput = true;
        crouchAction.canceled += inputInfo => CrouchInput = false;

        escapeButtonAction.performed += inputInfo => EscapeButtonInput = true;
        escapeButtonAction.canceled += inputInfo => EscapeButtonInput = false;


    }

    private void OnEnable()
    {
        playerControl.FindActionMap(actionMapName).Enable();
    }

    private void OnDisable()
    {
        playerControl.FindActionMap(actionMapName).Disable();
    }



}





