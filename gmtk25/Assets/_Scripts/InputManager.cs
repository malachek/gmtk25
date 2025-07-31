using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;

public class InputManager : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;
    InputAction RotateAction;
    InputAction JumpAction;
    InputAction SprintAction;

    [Space(10)]
    [SerializeField] RotationManager rotationManager;
    [SerializeField] PlayerMovement playerMovement;


    private void OnEnable()
    {
        var playerMap = inputActions.FindActionMap("Player");
        RotateAction = playerMap.FindAction("Rotate");
        JumpAction = playerMap.FindAction("Jump");
        SprintAction = playerMap.FindAction("Sprint");

        RotateAction.Enable();
        JumpAction.Enable();
        SprintAction.Enable();

        JumpAction.started += OnJumpStarted;
        JumpAction.performed += OnJumpPerformed;
        JumpAction.canceled += OnJumpCanceled;

        SprintAction.started += OnSprintStarted;
        SprintAction.canceled += OnSprintCanceled;
    }
    private void OnDisable()
    {
        RotateAction.Disable();
        JumpAction.Disable();
        SprintAction.Disable();

        JumpAction.started -= OnJumpStarted;
        JumpAction.performed -= OnJumpPerformed;
        JumpAction.canceled -= OnJumpCanceled;

        SprintAction.started -= OnSprintStarted;
        SprintAction.canceled -= OnSprintCanceled;
    }

    private void Update()
    {
        if (RotateAction.IsPressed())
        {
            playerMovement.RotationInputOverride(RotateAction.ReadValue<float>() > 0);
        }
    }

    private void OnRotatePerformed(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<float>());
        playerMovement.RotationInputOverride(context.ReadValue<float>() > 0);
    }

    private void OnJumpStarted(InputAction.CallbackContext context)
    {
        playerMovement.StartJump();
    }
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        playerMovement.HoldJump();
    }
    private void OnJumpCanceled(InputAction.CallbackContext context)
    {
        playerMovement.EndJump();
    }

    private void OnSprintStarted(InputAction.CallbackContext context)
    {
        playerMovement.SetSprint(true);
    }
    private void OnSprintCanceled(InputAction.CallbackContext context)
    {
        playerMovement.SetSprint(false);
    }
 
}
