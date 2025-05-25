using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDistance = 0.05f;
    public bool CheckIsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, checkDistance, groundLayer);
    }
}
