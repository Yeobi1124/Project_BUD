using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectBUD.Cursor
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Collider2D), typeof(Rigidbody2D))]
    public abstract class Block : MonoBehaviour
    {
        public enum BlockMode { InGame, Preview }
        
        [SerializeField]
        private BlockMode mode = BlockMode.InGame;

        public BlockMode Mode
        {
            get => mode;
            set => ChangeMode(mode = value);
        }
        
        public bool IsOverlapped { get; protected set; }

        protected abstract void ChangeMode(BlockMode mode);
    }   
}
