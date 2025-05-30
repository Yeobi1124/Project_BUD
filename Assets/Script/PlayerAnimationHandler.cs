using UnityEngine;

public class PlayerAnimationHandler: MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public PlayerAnimationHandler(Animator animator,SpriteRenderer spriteRenderer)
    {
        this.animator = animator;
        this.spriteRenderer = spriteRenderer;
    }
    void Start()
    {
        
    }


    public void SetAnimatorParameter(string parameterName, float value)
    {
        animator.SetFloat(parameterName, value);
    }
    public void SetAnimatorParameter(string parameterName, bool value)
    {
        animator.SetBool(parameterName, value);
    }
    public void SetAnimatorParameter(string parameterName)
    {
        animator.SetTrigger(parameterName);
    }

    public void CheckFlip(float velocityX)
    {
        if (velocityX > 0)
            FlipLeft();
        else if (velocityX < 0)
            FlipRight();
    }

    public void FlipLeft()
    {
            spriteRenderer.flipX = false;
    }
    public void FlipRight()
    {
            spriteRenderer.flipX = true;
    }

}
