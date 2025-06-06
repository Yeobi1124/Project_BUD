using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RemainTimeUI : MonoBehaviour
{
    [SerializeField]
    private Vector3 _offset;

    private Image _image;

    private void Awake()
    {
        TryGetComponent(out _image);
    }

    private void Update()
    {
        _image.fillAmount = EditorManager.Instance.GetRemainTimeRate();
        transform.position = Mouse.current.position.ReadValue() + (Vector2) _offset;
    }
}
