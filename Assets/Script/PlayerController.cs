using System;
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

    private float jumpDuration = 0.1f; // 걍 하드코딩...
    private float time = 0f;
    
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
        time -= Time.fixedDeltaTime;
        
        Vector2 moveInput = input.GetMove();
        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveInput.x * moveSpeed;

        if (moveInput.x == 0 && groundChecker.GetIsGrounded() && rb.linearVelocity.y > 0.1f && time <= 0)
        {
            Debug.Log($"velocity: {rb.linearVelocity}");
            velocity.y = 0;
        }
        
        rb.linearVelocity = velocity;

        bool isJump = jumpHandler.TryJump(rb, groundChecker.GetIsGrounded(), input.IsJumpPressed());
        if(isJump) time = jumpDuration;
        
        AnimUpdate(velocity.x, isJump);
        
    }

    private void AnimUpdate(float velocityX,bool isJump)
    {
        // 점프
        if (isJump) 
            animHandler.SetAnimatorParameter("IsJump");
        // 이동
        if (velocityX!=0) 
            animHandler.SetAnimatorParameter("IsMoving",true);
        //좌우판정
        animHandler.CheckFlip(velocityX);
    }
}
