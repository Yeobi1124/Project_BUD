using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectBUD.Cursor
{
    public class FixedBlock : Block
    {
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider;
        
        private Color _spriteColorCache;

        [SerializeField]
        private float _previewTransparency = 0.5f;
        
        protected override void ChangeMode(BlockMode mode)
        {
            switch (mode)
            {
                case BlockMode.InGame:
                    // SpriteRenderer
                    _spriteRenderer.color = _spriteColorCache;
                    
                    // Collider
                    _collider.isTrigger = false;
                    break;
                
                case BlockMode.Preview:
                    // SpriteRenderer
                    var color = _spriteRenderer.color;
                    _spriteColorCache = color;
                    _spriteRenderer.color = new Color(color.r, color.g, color.b, _previewTransparency);
                    
                    // Collider
                    _collider.isTrigger = true;
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
        }

        private void Update()
        {
            if (Mode == BlockMode.Preview)
            {
                var mosPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                transform.position = new Vector3(mosPos.x, mosPos.y, 0);
            }
        }
    }   
}
