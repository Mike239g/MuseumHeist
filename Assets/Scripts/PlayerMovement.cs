using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Originalmente usé una cinemachine freelook camera
    // Por lo que el movimiento de la cámara ya está hecho ahí
    public float playerSpeed;
    public Transform camera;
    
    private InputSystem_Actions inputActions;
    private Vector2 movementInput;
    private Vector3 movement;
    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        inputActions = new InputSystem_Actions();
        inputActions.Player.Move.Enable();
        movementInput = Vector2.zero;
    }

    private void Update()
    {
        InputHandle();
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void InputHandle()
    {
        movementInput = inputActions.Player.Move.ReadValue<Vector2>();
        
        Vector3 camForward = camera.forward;
        Vector3 camRight = camera.right;
        
        camForward.y = 0;
        camRight.y = 0;
        
        camForward.Normalize();
        camRight.Normalize();

        movement = camForward * movementInput.y + camRight * movementInput.x;
    }

    public void MovePlayer()
    {
        if (movementInput.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.fixedDeltaTime);
            
            controller.Move(movement * Time.fixedDeltaTime * playerSpeed);
        }
        
    }
}
