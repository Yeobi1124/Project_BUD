using UnityEngine;
public interface IJumpHandler
{
    void TryJump(Rigidbody2D rb, bool isGrounded, bool isJumpPressed);
}
