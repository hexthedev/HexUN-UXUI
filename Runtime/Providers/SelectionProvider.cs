using HexUN.Events;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// Provides selection events so that when something is selected, the
    /// old selected object can be deselected
    /// </summary>
    public class SelectionProvider : MonoBehaviour
    {
        [Header("Group")]
        [SerializeField]
        private SelectionGroup _group = null;

        [Header("Emissions")]
        [SerializeField]
        private VoidReliableEvent _onDeselect = null;

        [SerializeField]
        private VoidReliableEvent _onSelect = null;

        #region API

        public void Select()
        {
            if(_group != null && _group.Selected != null)
            {
                _group.Selected.Deselect();    
            }

            _group.Selected = this;
            _onSelect.Invoke();
        }

        public void Deselect()
        {
            if(_group != null && _group.Selected == this)
            {
                _group.Selected = null;
                _onDeselect.Invoke();
            }
        }
        #endregion
    }
}