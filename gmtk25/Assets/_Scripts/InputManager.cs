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

    [Space(10)]
    [SerializeField] RotationManager rotationManager;


    private void OnEnable()
    {
        var playerMap = inputActions.FindActionMap("Player");
        RotateAction = playerMap.FindAction("Rotate");
        JumpAction = playerMap.FindAction("Jump");

        RotateAction.Enable();
        JumpAction.Enable();
    }
    private void OnDisable()
    {
        RotateAction.Disable();
        JumpAction.Disable();
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void ProcessInputs()
    {
        if(RotateAction.IsPressed())
        {
            rotationManager.RotationInput(RotateAction.ReadValue<float>() > 0);
        }
        if (JumpAction.WasPressedThisFrame())
        {
            Debug.Log("jump");
        }
    }
}
