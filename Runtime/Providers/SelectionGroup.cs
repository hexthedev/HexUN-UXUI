using System;
using UnityEngine;

namespace HexUN.UXUI
{
    [CreateAssetMenu(fileName = "selectionGroup", menuName = "HexUN/UXUI/SelectionGroup")]
    public class SelectionGroup : ScriptableObject
    {
        private SelectionProvider _selected = null;

        public event Action OnSelectionChange;

        /// <summary>
        /// The seleted seletion provider. The GameObject this provider is attached to
        /// is the selected gameobject.
        /// </summary>
        public SelectionProvider Selected
        {
            get => _selected;
            set {
                if (_selected == value) return;
                _selected = value;
                OnSelectionChange?.Invoke();
            }
        }

        public T GetSelectedComponentOrNull<T>() where T : MonoBehaviour
        {
            if (Selected == null) return null;

            T comp = Selected.gameObject.GetComponent<T>();
            return comp;
            
        }
    }
}