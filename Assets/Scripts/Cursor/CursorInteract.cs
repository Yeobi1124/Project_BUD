using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectBUD.Cursor
{
    public class CursorInteract : MonoBehaviour
    {
        [SerializeField]
        private LayerMask layer;
        
        public void Interact(InputAction.CallbackContext context)
        {
            var mosPos = Mouse.current.position.ReadValue();
            mosPos = Camera.main.ScreenToWorldPoint(mosPos);
            
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(mosPos.x, mosPos.y, -10), Vector3.forward);
            if (hit == true)
            {
                IInteractableWithCursor interact = hit.collider.gameObject.GetComponent<IInteractableWithCursor>();
                
                interact.Interact();
            }
            else
            {
                Debug.Log("No IInteractableWithCursor");
                Debug.Log(mosPos);
            }
        }

        public void BringOut(InputAction.CallbackContext context)
        {
            var editor = EditorManager.Instance;

            if (editor.IsEmpty == false)
            {
                var go = editor.GetBlock();
                var mosPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

                go.transform.position = new Vector3(mosPos.x, mosPos.y, 0f);
                go.SetActive(true);
            }
        }
    }   
}
