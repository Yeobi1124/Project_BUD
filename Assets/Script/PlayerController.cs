using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private GroundChecker groundChecker;
    private Collider2D playerCollider;
    [SerializeField] private float moveSpeed;

    private bool isLookingLeft;

    public Vector2 moveInput { get; private set; }
    public bool jumpPressed { get; private set; }


    private PlayerInputHandler input;
    private JumpHandler jumpHandler;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        groundChecker = GetComponent<GroundChecker>();
        playerCollider = GetComponent<Collider2D>();
        groundChecker.SetPlayerHalfHeight(playerCollider.bounds.extents.y);
        input = new PlayerInputHandler();
        jumpHandler = new JumpHandler(5f);
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = input.GetMove();
        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveInput.x * moveSpeed;
        rb.linearVelocity = velocity;

        jumpHandler.TryJump(rb, groundChecker.GetIsGrounded(), input.IsJumpPressed());
    }

    public void SetAnimatorParameter(string parameterName, float value)
    {
        animator.SetFloat(parameterName, value);
    }

    public void SpriteRendererFlip()
    {
        if (isLookingLeft)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }

    public void SetIsLookingLeft(bool isLookingLeft)
    {
        this.isLookingLeft = isLookingLeft;
    }

    void Update()
    {
        
    }

}
