using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CommonBlock : Block
{
    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField]
    private float _followSpeed = 5f;

    // Cache
    private Quaternion _initialRotation;
    private float _gravity;
    private float _mass;
    private RigidbodyType2D _rigidbodyType;
    private string _tag;

    [SerializeField]
    private LayerMask _inGameLayer;
    [SerializeField]
    private LayerMask _previewLayer;
    
    [Header("Color")]
    [SerializeField] private Color _inGameColor;
    [SerializeField] private Color _previewColor;
    
    [Header("Outline")]
    [SerializeField] private Color _inGameOutlineColor;
    [SerializeField] private Color _previewOutlineColor;
    
    private SpriteRenderer _outlineRenderer;
    
    protected override void ChangeMode(BlockMode mode)
    {
        if (mode == Mode) return;

        switch (mode)
        {
            case BlockMode.InGame:
                // Layer
                gameObject.layer = Utils.GetIntFromLayer(_inGameLayer);

                // Rigidbody
                _rigidbody2D.bodyType = _rigidbodyType;
                _rigidbody2D.constraints = RigidbodyConstraints2D.None;
                _rigidbody2D.linearVelocity = Vector2.zero;
                _rigidbody2D.gravityScale = _gravity;
                _rigidbody2D.mass = _mass;
                
                // Tag
                tag = _tag;
                
                // Color
                _spriteRenderer.color = _inGameColor;
                _outlineRenderer.color = _inGameOutlineColor;
                
                break;

            case BlockMode.Preview:
                // Layer
                gameObject.layer = Utils.GetIntFromLayer(_previewLayer);

                // Transform
                transform.rotation = _initialRotation;

                // Rigidbody
                _rigidbodyType = _rigidbody2D.bodyType;
                _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

                _rigidbody2D.angularVelocity = 0;
                _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

                _gravity = _rigidbody2D.gravityScale;
                _rigidbody2D.gravityScale = 0;

                _mass = _rigidbody2D.mass;
                _rigidbody2D.mass = 0;
                
                // Tag
                _tag = tag;
                tag = "Untagged";
                
                // Color
                _spriteRenderer.color = _previewColor;
                _outlineRenderer.color = _previewOutlineColor;
                
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

        if (TryGetComponent(out _spriteRenderer) == false)
        {
            Debug.LogError("Couldn't find spriteRenderer");
        }
        
        transform.GetChild(0).TryGetComponent(out _outlineRenderer);
        
        _initialRotation = transform.rotation;
        _spriteRenderer.color = _inGameColor;
        _outlineRenderer.color = _inGameOutlineColor;
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
        Debug.Log($"name: {name} mode: {Mode} tag: {tag} other name: {other.name} tag: {other.tag}");
        if (Mode == BlockMode.Preview && other.CompareTag("CursorArea"))
        {
            EditorManager.Instance.Place();
        }
    }
}   

