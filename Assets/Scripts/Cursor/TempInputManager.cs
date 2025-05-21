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
            var action = _actionMap.FindAction("Attack");
            action.Enable();
            action.started += cursorInteract.Interact;
        }
    }   
}
