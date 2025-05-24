using System.Collections.Generic;
using UnityEngine;

namespace ProjectBUD.Cursor
{
    [CreateAssetMenu(menuName = "Block/BlockDB", order = 1)]
    public class BlockSODB : ScriptableObject
    {
        [SerializeField]
        private List<BlockSO> blocks;
        private Dictionary<int, BlockSO> _blockDictionary;

        private bool _initialized = false;
        
        private void Initialize()
        {
            // Debug.Log("Initializing Block DB");
            _blockDictionary = new Dictionary<int, BlockSO>();
            
            foreach (var block in blocks)
            {
                _blockDictionary.Add(block.id, block);
                // Debug.Log($"Added Block {block.id}");
            }
            
            _initialized = true;
        }
        private BlockSO GetBlock(int id)
        {
            // Debug.Log(_initialized); // 얘 분명 false로 초기화 하는데 출력하면 True 뜸.
            // if(_initialized == false) Initialize();
            Initialize();
            
            if (_blockDictionary.TryGetValue(id, out var block) == true)
            {
                Debug.Log($"Found Block {id}");
                return block;
            }
            else
            {
                Debug.LogError($"Block {id} not found");
                return null;
            }
        }
        
        public GameObject GetInGameBlock(int id) => GetBlock(id)?.inGameBlock;
        public GameObject GetUIBlock(int id) => GetBlock(id)?.uiBlock;
        public GameObject GetPreviewBlock(int id) => GetBlock(id)?.previewBlock;
    }   
}
