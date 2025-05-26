using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDistance = 0.05f;
    private float playerBottomCenterY;
    private bool isGrounded;

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    //충돌시 그라운드의 위에서 충돌했을 경우만 점프 가능 상태 만들어줌
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            foreach (var contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


}