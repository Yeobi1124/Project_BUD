using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Key : MonoBehaviour
{
    [SerializeField] private GameObject _lock;
    private LockAnimationHandler lockAnimationHandler;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lockAnimationHandler = _lock.GetComponent<LockAnimationHandler>();
            lockAnimationHandler.UnlockAnim();
            gameObject.SetActive(false);
        }
    }
}
