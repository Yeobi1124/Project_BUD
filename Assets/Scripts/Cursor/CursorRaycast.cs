using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectBUD.Cursor
{
    public class CursorRaycast : MonoBehaviour
    {
        [SerializeField]
        private LayerMask layer;
        public void Activate(InputAction.CallbackContext context)
        {
            var mosPos = Mouse.current.position.ReadValue();
            mosPos = Camera.main.ScreenToWorldPoint(mosPos);
            
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(mosPos.x, mosPos.y, -10), Vector3.forward);
            if (hit == true)
            {
                IInteractableWithCursor interact = hit.collider.gameObject.GetComponent<IInteractableWithCursor>();
                
                // Todo : 중간에 저장되어있는지 여부 확인
                
                interact.Interact();
            }
            else
            {
                Debug.Log("No IInteractableWithCursor");
                Debug.Log(mosPos);
            }
        }
    }   
}
