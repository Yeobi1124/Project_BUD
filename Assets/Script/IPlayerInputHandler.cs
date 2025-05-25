using UnityEngine;

public interface IPlayerInputHandler
{
    public Vector2 GetMove();
    public bool IsJumpPressed();
}
