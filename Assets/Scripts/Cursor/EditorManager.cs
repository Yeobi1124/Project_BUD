using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectBUD.Cursor
{
    public class EditorManager : MonoBehaviour
    {
        public static EditorManager Instance = null;

        [SerializeField]
        private Block _selectedBlock = null;
        
        public bool IsEmpty => _selectedBlock == null;
        
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
            return _selectedBlock != null;
        }
        
        public void Insert(Block block)
        {
            _selectedBlock = block;
            block.transform.rotation = Quaternion.identity;
            block.Mode = Block.BlockMode.Preview;
        }

        public void Place(Vector3 pos)
        {
            if (IsEmpty == true) return;
            
            _selectedBlock.transform.position = pos;
            _selectedBlock.Mode = Block.BlockMode.InGame;
            _selectedBlock = null;
        }

        public void Clear()
        {
            _selectedBlock = null;
        }
    }   
}
