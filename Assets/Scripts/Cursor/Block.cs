using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectBUD.Cursor
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
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

        protected abstract void ChangeMode(BlockMode mode);
    }   
}
