using UnityEngine;
public interface IJumpHandler
{
    bool TryJump(Rigidbody2D rb, bool isGrounded, bool isJumpPressed);
}
