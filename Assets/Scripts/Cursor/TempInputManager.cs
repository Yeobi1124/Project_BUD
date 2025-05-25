using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace ProjectBUD.Cursor
{
    public class TempInputManager : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _actionMap;
        
        [SerializeField] private CursorInteract cursorInteract;
        
        private void Awake()
        {
            _actionMap.Enable();
            var interactAction = _actionMap.FindAction("LMB"); // Mouse Left Click
            interactAction.Enable();
            interactAction.started += LMB;
            
            var bringOutAction = _actionMap.FindAction("RMB"); // Keyboard E
            bringOutAction.Enable();
            // bringOutAction.started += cursorInteract.Summon;
        }

        private void LMB(InputAction.CallbackContext context)
        {
            if (EditorManager.Instance.IsEmpty == true)
            {
                cursorInteract.Interact(context);
            }
            else
            {
                cursorInteract.Summon(context);
            }
        }
    }   
}
