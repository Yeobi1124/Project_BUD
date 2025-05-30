using UnityEngine;

public class Storable : MonoBehaviour, IInteractableWithCursor
{
    public void Interact()
    {
        EditorManager.Instance.Insert(GetComponent<Block>());
    }
}   
