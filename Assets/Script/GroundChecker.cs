using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDistance = 0.05f;
    private float playerHalfHeight;
    private bool isGrounded;

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public void SetPlayerHalfHeight(float playerHalfHeight)
    {
        this.playerHalfHeight = playerHalfHeight;
    }

    //충돌시 그라운드의 위에서 충돌했을 경우만 점프 가능 상태 만들어줌
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Block"))
        {
            foreach (var contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f && IsCollidedOnGround(contact.point.y))
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }

    // collide upward -> true
    // 0.9 -> transform, collider position difference care 
    private bool IsCollidedOnGround(float contactY)
    {
        return contactY <= transform.position.y - playerHalfHeight*0.9;
    }
        
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Block"))
        {
            isGrounded = false;
        }
    }


}