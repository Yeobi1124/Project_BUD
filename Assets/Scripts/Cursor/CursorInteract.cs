using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectBUD.Cursor
{
    public class CursorInteract : MonoBehaviour
    {
        [SerializeField]
        private LayerMask layer;
        
        /// <summary>
        /// 마우스 위치에서 Raycast 쏴서 처음으로 닿는 GameObject의 IInteractableWithCursor의 Interact 사용.
        /// </summary>
        /// <param name="context"></param>
        public void Interact(InputAction.CallbackContext context)
        {
            var mosPos = Mouse.current.position.ReadValue();
            mosPos = Camera.main.ScreenToWorldPoint(mosPos);
            
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(mosPos.x, mosPos.y, -10), Vector3.forward, float.PositiveInfinity, layer);
            if (hit == true)
            {
                IInteractableWithCursor interact = hit.collider.gameObject.GetComponent<IInteractableWithCursor>();
                
                interact.Interact();
            }
            else
            {
                Debug.Log("Target Not Found");
            }
        }

        /// <summary>
        /// Editor에 저장되어있던 Block 꺼내서 소환하기
        /// </summary>
        /// <param name="context"></param>
        public void Summon(InputAction.CallbackContext context)
        {
            var editor = EditorManager.Instance;

            editor.Place();
        }

        public void Rotate(InputAction.CallbackContext context)
        {
            var editor = EditorManager.Instance;

            if (editor.IsEmpty == false)
            {
                editor.Rotate();
            }
        }
    }   
}
