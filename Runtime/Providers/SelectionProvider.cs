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
        private BooleanReliableEvent _onSelectionStateChange = null;

        #region API
        public void Select()
        {
            if(_group != null && _group.Selected != null)
            {
                _group.Selected.Deselect();    
            }

            _group.Selected = this;
        }

        public void Deselect()
        {
            if(_group != null && _group.Selected == this)
            {
                _group.Selected = null;
            }
        }
        #endregion

        private void Start()
        {
            _group.OnSelectionChange += HandleSelectionStateChange;
        }

        private void HandleSelectionStateChange()
        {
            _onSelectionStateChange.Invoke(_group.Selected == this);
        }
    }
}