using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(SpriteRenderer))]
public class Disappear : MonoBehaviour, IDeadable
{
    [SerializeField]
    private bool _active = false;
    
    [SerializeField]
    private AnimationCurve _alphaCurve = AnimationCurve.Linear(0, 1, 1, 0);
    
    [SerializeField]
    private float _disappearDuration = 1f;
    
    private SpriteRenderer _spriteRenderer;

    private float _time = 0f;

    private void Awake()
    {
        if (TryGetComponent(out _spriteRenderer) == false)
        {
            Debug.LogError("Couldn't find SpriteRenderer");
        }
    }

    private void Update()
    {
        if (_active == true)
        {
            _time += Time.deltaTime;
            var color = _spriteRenderer.color;
            _spriteRenderer.color = new Color(color.r, color.g, color.b, _alphaCurve.Evaluate(_time /  _disappearDuration));
            
            if(_time >= _disappearDuration)
                Destroy(gameObject);
        }
    }

    public void Dead()
    {
        _active = true;

        if (TryGetComponent(out Rigidbody2D rigidbody) == true)
        {
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
            rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (TryGetComponent(out Collider2D collider) == true)
        {
            collider.isTrigger = true;
        }
    }
}
