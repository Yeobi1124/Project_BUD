using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectBUD.Cursor
{
    public class BlockPannel : MonoBehaviour
    {
        private void Awake()
        {
            var editor = EditorManager.Instance;

            editor.OnBlockInserted += Insert;
            editor.OnBlockRemoved += Remove;
            editor.OnCleared += Clear;
        }

        private void OnDestroy()
        {
            var editor = EditorManager.Instance;
            
            editor.OnBlockInserted -= Insert;
            editor.OnBlockRemoved -= Remove;
            editor.OnCleared -= Clear;
        }

        public void Insert(int id)
        {
            var editor = EditorManager.Instance;
            var prefab = editor.GetUIBlock(id);
            
            var go = Instantiate(prefab, transform);
            // Todo : go에 Select 이벤트 연결하기
            var button = go.GetComponent<Button>();
            button.onClick.AddListener(() => Select(transform.childCount - 1));
        }

        public void Remove(int index)
        {
            var child = transform.GetChild(index);
            Destroy(child.gameObject);
        }

        public void Select(int index)
        {
            var editor = EditorManager.Instance;
            editor.Select(index);
        }

        public void Clear()
        {
            while (transform.childCount > 0)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
        }
    }   
}
