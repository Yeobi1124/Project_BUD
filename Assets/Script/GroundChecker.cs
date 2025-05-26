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

    //�浹�� �׶����� ������ �浹���� ��츸 ���� ���� ���� �������
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