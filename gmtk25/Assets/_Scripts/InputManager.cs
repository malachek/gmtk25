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
    }
    private void OnDisable()
    {
        RotateAction.Disable();
        JumpAction.Disable();
        SprintAction.Disable();
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void ProcessInputs()
    {
        if (RotateAction.IsPressed())
        {
            //Debug.Log(RotateAction.ReadValue<float>() > 0 ? "CCW" : "CW");
            playerMovement.RotationInputOverride(RotateAction.ReadValue<float>() > 0);
        }
        if (JumpAction.IsPressed())
        {
            playerMovement.Jump(JumpAction);
        }
        if (SprintAction.WasPressedThisFrame())
        {
            Debug.Log("Sprint Start");
            playerMovement.SetSprint(true);
        }
        if (SprintAction.WasReleasedThisFrame())
        {
            Debug.Log("Sprint Stop");
            playerMovement.SetSprint(false);
        }
    }
}
