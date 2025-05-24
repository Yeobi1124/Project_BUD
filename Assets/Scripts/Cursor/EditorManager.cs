using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectBUD.Cursor
{
    public class EditorManager : MonoBehaviour
    {
        public static EditorManager Instance = null;

        [SerializeField]
        private BlockSODB _blockTypes;
        [SerializeField]
        private List<int> _blocks = new List<int>();

        [SerializeField]
        private int _selectedBlock = -1;
        [SerializeField] private GameObject _blockPreviewParent;

        public event Action<int> OnBlockInserted;
        public event Action<int> OnBlockSelected;
        public event Action<int> OnBlockRemoved;
        public event Action OnCleared;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        public bool Summonable()
        {
            // Todo : 실제 로직 짜기. 지금껀 임시로 짜둔 거
            return _selectedBlock != -1;
        }

        public GameObject GetInGameBlock(int id) => _blockTypes.GetInGameBlock(id);
        public GameObject GetUIBlock(int id) => _blockTypes.GetUIBlock(id);
        public GameObject GetPreviewBlock(int id) => _blockTypes.GetPreviewBlock(id);
        
        public void Insert(GameObject block)
        {
            BlockInfo info;
            if (block.TryGetComponent(out info) == false)
            {
                Debug.LogError($"Couldn't find BlockInfo {block.name}");
                return;
            }

            int id = info.id;
            _blocks.Add(id);
            
            Destroy(block);
            
            Debug.Log($"Added Block {id}");
            OnBlockInserted?.Invoke(id);
        }

        public void Place(Vector3 pos)
        {
            GameObject block = Instantiate(_blockTypes.GetInGameBlock(_blocks[_selectedBlock]), pos, Quaternion.identity);
            Remove(_selectedBlock);
            
            // Debug.Log($"Placed Block : id = {_blocks[_selectedBlock]},index = {_selectedBlock}");
        }

        public void Remove(int index)
        {
            _blocks.RemoveAt(index);
            
            if(_selectedBlock == index)
                _selectedBlock = -1;
            else if(_selectedBlock > index)
                _selectedBlock -= 1;
            
            OnBlockRemoved?.Invoke(index);
        }

        public void Select(int index)
        {
            _selectedBlock = index;
            OnBlockSelected?.Invoke(index);
        }

        public void Clear()
        {
            _blocks.Clear();
            _selectedBlock = -1;
            OnCleared?.Invoke();
        }
    }   
}
