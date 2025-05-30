using UnityEngine;


public class JumpHandler : IJumpHandler
{
    private float jumpForce;

    public JumpHandler(float jumpForce)
    {
        this.jumpForce = jumpForce;
    }

    //jump = true, no jump = false
    public bool TryJump(Rigidbody2D rb, bool isGrounded, bool isJumpPressed)
    {
        Debug.Log("isG: " + isGrounded + ", isJ: " + isJumpPressed);
        if(isGrounded && isJumpPressed)
        {
            rb.AddForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
            return true;
        }
        return false;
    }
}
