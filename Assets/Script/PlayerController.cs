using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GroundChecker groundChecker;
    private Collider2D playerCollider;
    [SerializeField] private float moveSpeed;

    public Vector2 moveInput { get; private set; }
    public bool jumpPressed { get; private set; }


    private PlayerInputHandler input;
    private JumpHandler jumpHandler;
    private PlayerAnimationHandler animHandler;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<GroundChecker>();
        playerCollider = GetComponent<Collider2D>();
        groundChecker.SetPlayerHalfHeight(playerCollider.bounds.extents.y);
        input = new PlayerInputHandler();
        jumpHandler = new JumpHandler(5f);
        animHandler = new PlayerAnimationHandler(GetComponent<Animator>(), GetComponent<SpriteRenderer>());
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = input.GetMove();
        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveInput.x * moveSpeed;
        rb.linearVelocity = velocity;

        bool isJump = jumpHandler.TryJump(rb, groundChecker.GetIsGrounded(), input.IsJumpPressed());
        AnimUpdate(velocity.x, isJump);
        
    }

    private void AnimUpdate(float velocityX,bool isJump)
    {
        // ����
        if (isJump) 
            animHandler.SetAnimatorParameter("IsJump");
        // �̵�
        if (velocityX!=0) 
            animHandler.SetAnimatorParameter("IsMoving",true);
        //�¿�����
        animHandler.CheckFlip(velocityX);
    }

    void Update()
    {
        
    }

}
