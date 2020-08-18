using HexCS.Core;
using HexUN.Events;
using UnityEngine;

namespace HexUN.UXUI
{
    public class PuiSelectionGroupControl : APuiControl<PuiSelectionGroupView>
    {
        [Header("Emissions")]
        [SerializeField]
        [Tooltip("Invoked when a selection change is made by the user. Does not automatically change selection")]
        private Int32ReliableEvent _onSelectionChangeRequested;

        [Header("Options")]
        [SerializeField]
        [Tooltip("The max active index of the buttons. All bttons afte rindex will be disabled")]
        private int _maxActiveIndex = 0;

        private int _selected = 0;

        #region API
        /// <summary>
        /// The max active index. All others are disabled. 
        /// </summary>
        public int MaxActiveIndex
        {
            get => _maxActiveIndex;
            set 
            {
                if (_maxActiveIndex == value) return;
                _maxActiveIndex = value;
                RenderView();
            }
        }

        /// <summary>
        /// The index of the selected item
        /// </summary>
        public int Selected {
            get => _selected;
            set
            {
                if (_selected != value) _selected = value;
                RenderView();
            }
        }

        /// <summary>
        /// Invoked when a new seleciton index is selected
        /// </summary>
        public IEventSubscriber<int> OnSelectionChangeRequest => _onSelectionChangeRequested;

        /// <summary>
        /// Attempt to make a selection change. It is up to the
        /// manager of the controller to decide if the selected index actually changes
        /// </summary>
        /// <param name="newSelection"></param>
        public void RequestSelectionChange(int newSelection)
        {
            _onSelectionChangeRequested?.Invoke(newSelection);
        }

        /// <summary>
        /// Set the max active index
        /// </summary>
        /// <param name="maxIndex"></param>
        public void SetActiveRange(int maxIndex)
        {
            MaxActiveIndex = maxIndex;
            RenderView();
        }
        #endregion
    }
}