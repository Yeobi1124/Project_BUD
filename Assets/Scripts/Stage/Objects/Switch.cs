using UnityEngine;
using UnityEngine.Events;

namespace ProjectBUD.Stage.Objects
{
    public class Switch : MonoBehaviour, IInteract
    {
        [SerializeField]
        private UnityEvent _onInteract;
        
        public void Interact()
        {
            _onInteract?.Invoke();
        }
    }
}
