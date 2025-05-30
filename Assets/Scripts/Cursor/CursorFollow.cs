using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectBUD.Cursor
{
    public class CursorFollow : MonoBehaviour
    {
        private void FixedUpdate()
        {
            var camera = Camera.main;
            var mosPos = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            
            transform.position = new Vector3(mosPos.x, mosPos.y, transform.position.z);
        }
    }   
}
