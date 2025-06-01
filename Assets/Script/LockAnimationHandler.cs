using UnityEngine;

public class LockAnimationHandler: MonoBehaviour
{
    [SerializeField] private Animator lockAnim;

    public void UnlockAnim()
    {
        if (lockAnim == null)
            Debug.LogError("lock animator null");

        lockAnim.SetTrigger("Unlock");
    }

    public void OnAnimationEnd()
    {
        gameObject.SetActive(false);
    }
}
