using HexUN.Data;
using HexUN.Events;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <inheritdoc />
    public abstract class AUIFilter : AMonoDataProvider
    {
        [SerializeField]
        [Tooltip("Object event this class listen to")]
        private ObjectSoEvent _listeningToEvent = null;

        /// <summary>
        /// How to process the generic event received
        /// </summary>
        /// <param name="o"></param>
        public abstract void HandleUI(object o);

        protected override void HexAwake()
        {
            _listeningToEvent?.Event.Subscribe(HandleUI);
        }
    }
}