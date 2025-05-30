using UnityEngine;

namespace ProjectBUD.Stage
{
    [RequireComponent(typeof(Collider2D))]
    public class Portal : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
                StageManager.Instance.MoveToNextStage();
        }
    }   
}
