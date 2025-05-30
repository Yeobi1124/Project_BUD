using System;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    private void FixedUpdate()
    {
        if(_target != null)
            transform.position = _target.position;
    }
}   
