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
            var interactAction = _actionMap.FindAction("Attack");
            interactAction.Enable();
            interactAction.started += cursorInteract.Interact;
            
            var bringOutAction = _actionMap.FindAction("Interact");
            bringOutAction.Enable();
            bringOutAction.started += cursorInteract.BringOut;
        }
    }   
}
