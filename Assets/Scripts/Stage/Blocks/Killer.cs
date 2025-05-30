using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Killer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IDeadable deadable) == true)
        {
            deadable.Dead();
        }
    }
}
