using UnityEngine;

namespace ProjectBUD.Cursor
{
    public class StorableBlock : MonoBehaviour, IInteractableWithCursor
    {
        public void Interact()
        {
            var editor = EditorManager.Instance;

            editor.Insert(gameObject);
        }
    }   
}
