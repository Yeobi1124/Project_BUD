using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectBUD.Cursor
{
    public class CommonBlock : Block
    {
        private Collider2D _collider;
        private Rigidbody2D _rigidbody2D;
        
        [SerializeField]
        private float _followSpeed = 5f;

        private float _gravity;
        private float _mass;
        private RigidbodyType2D _rigidbodyType;
        
        protected override void ChangeMode(BlockMode mode)
        {
            if (mode == Mode) return;
            
            switch (mode)
            {
                case BlockMode.InGame:
                    // Layer
                    gameObject.layer = LayerMask.NameToLayer("Block");
                    
                    // Rigidbody
                    _rigidbody2D.bodyType = _rigidbodyType;
                    _rigidbody2D.constraints = RigidbodyConstraints2D.None;
                    _rigidbody2D.linearVelocity = Vector2.zero;
                    _rigidbody2D.gravityScale = _gravity;
                    _rigidbody2D.mass = _mass;
                    
                    break;
                
                case BlockMode.Preview:
                    // Layer
                    gameObject.layer = LayerMask.NameToLayer("Preview");
                    
                    // Transform
                    transform.rotation = Quaternion.identity;
                    
                    // Rigidbody
                    _rigidbodyType = _rigidbody2D.bodyType;
                    _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                    
                    _rigidbody2D.angularVelocity = 0;
                    _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                    
                    _gravity = _rigidbody2D.gravityScale;
                    _rigidbody2D.gravityScale = 0;
                    
                    _mass = _rigidbody2D.mass;
                    _rigidbody2D.mass = 0;
                    break;
                
                default:
                    break;
            }
            
            Debug.Log($"{name} change mode to {mode}");
        }

        private void Awake()
        {
            if (TryGetComponent(out _collider) == false)
            {
                Debug.LogError("Couldn't find collider");
            }

            if (TryGetComponent(out _rigidbody2D) == false)
            {
                Debug.LogError("Couldn't find rigidbody2D");
            }
        }

        private void FixedUpdate()
        {
            if (Mode == BlockMode.Preview)
            {
                var mosPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                _rigidbody2D.linearVelocity = (mosPos - transform.position).normalized * _followSpeed;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (Mode == BlockMode.Preview && other.CompareTag("CursorArea"))
            {
                Mode = BlockMode.InGame;
            }
        }
    }   
}
