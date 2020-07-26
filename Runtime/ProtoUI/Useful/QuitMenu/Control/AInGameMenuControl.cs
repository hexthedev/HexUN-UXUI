using UnityEngine;
using HexUN.Patterns;
using HexCS.Core;

namespace HexUN.UXUI
{
    public abstract class AInGameMenuControl : AControl, IInGameMenuControl
    {
        [Header("Emissions (AInGameMenuControl)")]
        [SerializeField]
        protected CVCommandReliableEvent _onActivate = new CVCommandReliableEvent();

        [SerializeField]
        protected CVCommandReliableEvent _onDeactivate = new CVCommandReliableEvent();

        [SerializeField]
        protected CVCommandReliableEvent _onResume = new CVCommandReliableEvent();

        [SerializeField]
        protected CVCommandReliableEvent _onQuit = new CVCommandReliableEvent();

        public IEventSubscriber<CVCommand> OnDeactivate => _onDeactivate;

        public IEventSubscriber<CVCommand> OnActivate => _onActivate;

        public IEventSubscriber<CVCommand> OnResume => _onResume;

        public IEventSubscriber<CVCommand> OnQuit => _onQuit;

        public abstract bool IsActive { get; }

        public abstract void Deactivate();

        public abstract void Activate();

        public abstract void Resume();

        public abstract void Quit();
    }
}