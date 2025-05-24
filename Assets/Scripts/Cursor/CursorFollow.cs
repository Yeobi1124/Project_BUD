using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectBUD.Cursor
{
    public class CursorFollow : MonoBehaviour
    {
        void Update()
        {
            var mosPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            transform.position = mosPos;
        }
    }   
}
