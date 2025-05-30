using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InteractArea : MonoBehaviour
{
    [SerializeField]
    private List<IInteract> _interacts = new List<IInteract>();

    public void Interact()
    {
        for(int i = _interacts.Count - 1; i >= 0; i--)
        {
            _interacts[i].Interact();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<IInteract>(out var interact) == true)
            _interacts.Add(interact);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent<IInteract>(out var interact) == true)
            _interacts.Remove(interact);
    }
}
