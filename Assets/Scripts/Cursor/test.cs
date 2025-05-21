using UnityEngine;

namespace ProjectBUD.Cursor
{
    public class test : MonoBehaviour, IInteractableWithCursor
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Interact()
        {
            Debug.Log("Interact");
        }
    }   
}
