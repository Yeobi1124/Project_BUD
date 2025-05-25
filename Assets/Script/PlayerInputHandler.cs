using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : IPlayerInputHandler
{
    private PlayerInput inputActions;
    private Vector2 moveDir;
    private bool jumpPressed;

    public PlayerInputHandler(){
        inputActions = new PlayerInput();
        inputActions.PlayerGameplay.Enable();
        inputActions.PlayerGameplay.Move.performed += ctx => moveDir = ctx.ReadValue<Vector2>();
        inputActions.PlayerGameplay.Move.canceled += ctx => moveDir = Vector2.zero;
        inputActions.PlayerGameplay.Jump.performed += ctx => jumpPressed = true;
        inputActions.PlayerGameplay.Jump.canceled += ctx => jumpPressed = false;
    }


    public Vector2 GetMove() => moveDir;
    public bool IsJumpPressed() => jumpPressed;
}
