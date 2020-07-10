using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HexUN.UXUI
{
    /// <summary>
    /// Arguments used to propgate event functions to UI creators. 
    /// 
    /// In this scenario, a UI manager will recieve EventPropagationArgs
    /// and use them to spawn a UI element with a linked to the given event
    /// </summary>
    [System.Serializable]
    public class EventPropagationArgs<TEvent, TArgs>
        where TEvent : UnityEvent
    {
        [SerializeField]
        private TArgs _args;

        [SerializeField]
        private TEvent _event;

        #region API
        /// <summary>
        /// The Event that is being progated
        /// </summary>
        public TEvent Event => _event;

        /// <summary>
        /// The arguments that should be used in conjunction with
        /// the event. This is ofen a prefab that should be
        /// Instantiated then linked with the event
        /// </summary>
        public TArgs Args => _args;

        /// <summary>
        /// Construct event propagation args
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="args"></param>
        public EventPropagationArgs(TEvent evt, TArgs args)
        {
            _event = evt;
            _args = args;
        }
        #endregion
    }
}