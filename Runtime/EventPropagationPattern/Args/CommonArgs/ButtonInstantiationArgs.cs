using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.UI.Button;

namespace HexUN.UXUI
{
    /// <summary>
    /// Args used to instanitate a button
    /// </summary>
    [System.Serializable]
    public class ButtonInstantiationArgs : EventPropagationArgs<ButtonClickedEvent, GameObject>
    {
        /// <summary>
        /// Construct UIElementPropagationArgs
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="args"></param>
        public ButtonInstantiationArgs(ButtonClickedEvent evt, GameObject args) : base(evt, args)
        {
        }
    }
}
