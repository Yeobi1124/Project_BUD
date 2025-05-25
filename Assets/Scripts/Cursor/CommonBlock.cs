using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectBUD.Cursor
{
    public class CommonBlock : Block
    {
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider;
        private Rigidbody2D _rigidbody2D;
        
        // Cache
        private Color _inGameSpriteColorCache;
        private Color _previewSpriteColorCache;
        private RigidbodyType2D _inGameRigidbodyType;

        [SerializeField]
        private float _previewTransparency = 0.5f;

        [SerializeField]
        private Color _overlapColor = new Color(1, 0, 0, 0.5f);
        
        protected override void ChangeMode(BlockMode mode)
        {
            switch (mode)
            {
                case BlockMode.InGame:
                    // SpriteRenderer
                    _spriteRenderer.color = _inGameSpriteColorCache;
                    
                    // Collider
                    _collider.isTrigger = false;
                    
                    // Rigidbody
                    _rigidbody2D.bodyType = _inGameRigidbodyType;
                    _rigidbody2D.linearVelocity = Vector2.zero;
                    break;
                
                case BlockMode.Preview:
                    // SpriteRenderer
                    var color = _spriteRenderer.color;
                    _inGameSpriteColorCache = color;
                    _spriteRenderer.color = new Color(color.r, color.g, color.b, _previewTransparency);
                    
                    // Collider
                    _collider.isTrigger = true;
                    
                    // Rigidbody
                    _inGameRigidbodyType = _rigidbody2D.bodyType;
                    _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                    break;
                
                default:
                    break;
            }
        }

        private void Awake()
        {
            if (TryGetComponent(out _spriteRenderer) == false)
            {
                Debug.LogError("Couldn't find sprite renderer");
            }

            if (TryGetComponent(out _collider) == false)
            {
                Debug.LogError("Couldn't find collider");
            }

            if (TryGetComponent(out _rigidbody2D) == false)
            {
                Debug.LogError("Couldn't find rigidbody2D");
            }
        }

        private void Update()
        {
            if (Mode == BlockMode.Preview)
            {
                var mosPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                transform.position = new Vector3(mosPos.x, mosPos.y, 0);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Entered preview");
            if (Mode == BlockMode.Preview)
            {
                Debug.Log("Entered preview");
                _previewSpriteColorCache = _spriteRenderer.color;
                _spriteRenderer.color = _overlapColor;
                
                IsOverlapped = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (Mode == BlockMode.Preview)
            {
                Debug.Log("Exited preview");
                _spriteRenderer.color = _previewSpriteColorCache;
                
                IsOverlapped = false;
            }
        }
    }   
}
