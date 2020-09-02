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
        [Header("Emissions")]
        [SerializeField]
        private VoidReliableEvent _onDeselect = null;

        #region API
        /// <summary>
        /// The seleted seletion provider. The GameObject this provider is attached to
        /// is the selected gameobject.
        /// </summary>
        public static SelectionProvider Selected { get; private set; } = null;

        public void Select()
        {
            if(Selected != null)
            {
                Selected.Deselect();    
            }

            Selected = this;
        }

        public void Deselect()
        {
            if(Selected == this)
            {
                Selected = null;
                _onDeselect.Invoke();
            }
        }
        #endregion
    }
}