using System;
using UnityEngine;

namespace ProjectBUD.Cursor
{
    public class EditorManager : MonoBehaviour
    {
        public static EditorManager Instance = null;

        private GameObject _block;

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
        
        public bool IsEmpty => _block == null;

        public void Insert(GameObject block)
        {
            _block = block;
        }

        public GameObject GetBlock()
        {
            var block = _block;
            _block = null;
            return block;
        }
    }   
}
