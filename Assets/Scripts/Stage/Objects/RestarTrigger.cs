using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RestarTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            StageManager.Instance.Restart();
    }
}
