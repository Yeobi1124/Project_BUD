using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Key : MonoBehaviour
{
    [SerializeField] private GameObject _lock;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _lock.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
