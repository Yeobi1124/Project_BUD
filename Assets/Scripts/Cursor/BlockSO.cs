using UnityEngine;

namespace ProjectBUD.Cursor
{
    [CreateAssetMenu(fileName = "Block", menuName = "Block/Block", order = 0)]
    public class BlockSO : ScriptableObject
    {
        public int id;
        public GameObject inGameBlock;
        public GameObject uiBlock;
        public GameObject previewBlock;
    }   
}
