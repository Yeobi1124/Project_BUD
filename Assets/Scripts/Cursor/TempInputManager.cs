using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectBUD.Cursor
{
    public class TempInputManager : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _actionMap;
        
        [SerializeField] private CursorRaycast cursorRaycast;
        
        private void Awake()
        {
            _actionMap.Enable();
            var action = _actionMap.FindAction("Attack");
            action.Enable();
            action.started += cursorRaycast.Activate;
        }
    }   
}
