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
        
        [SerializeField]
        private float _waitingTime = 2f;

        [SerializeField]
        private float _currentRemainTime;
        
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

        private void Update()
        {
            _currentRemainTime = _currentRemainTime - Time.deltaTime > 0 ? _currentRemainTime - Time.deltaTime : 0;
        }

        public bool Summonable()
        {
            return (_selectedBlock?.IsOverlapped ?? true) == false && _currentRemainTime <= 0;
        }
        
        public void Insert(Block block)
        {
            if (IsEmpty == false) return;
            
            _selectedBlock = block;
            block.transform.rotation = Quaternion.identity;
            block.Mode = Block.BlockMode.Preview;

            _currentRemainTime = _waitingTime;
        }

        public void Rotate()
        {
            if (IsEmpty == true) return;
            _selectedBlock.transform.rotation *= Quaternion.Euler(0, 0, 90);
        }

        public void Place(Vector3 pos)
        {
            if (IsEmpty == true) return;
            if (_currentRemainTime > 0) return;
            
            _selectedBlock.transform.position = pos;
            _selectedBlock.Mode = Block.BlockMode.InGame;
            _selectedBlock = null;
        }

        public void Clear()
        {
            _selectedBlock = null;
        }
        
        public float GetRemainTimeRate() => _currentRemainTime/_waitingTime;
    }   
}
