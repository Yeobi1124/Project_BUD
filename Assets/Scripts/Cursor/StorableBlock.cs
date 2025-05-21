using UnityEngine;

namespace ProjectBUD.Cursor
{
    public class StorableBlock : MonoBehaviour, IInteractableWithCursor
    {
        public void Interact()
        {
            var editor = EditorManager.Instance;

            if (editor.IsEmpty == true)
            {
                editor.Insert(gameObject);
                gameObject.SetActive(false);
            }
        }
    }   
}
