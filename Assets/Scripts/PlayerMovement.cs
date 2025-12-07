using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    
    private InputSystem_Actions inputActions;
    private Vector2 movementInput;
    private Vector3 movement;
    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        inputActions = new InputSystem_Actions();
        inputActions.Player.Move.Enable();
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
        movement = new Vector3(movementInput.x, 0, movementInput.y);
    }

    public void MovePlayer()
    {
        if (movementInput.magnitude > 0)
        {
            controller.Move(movement * Time.fixedDeltaTime * playerSpeed);
        }
        
    }
}
