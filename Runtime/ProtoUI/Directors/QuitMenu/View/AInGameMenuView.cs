using UnityEngine;
using HexUN.MonoB;
using HexUN.Patterns;
using HexUN.Deps;
using HexCS.Core;

namespace HexUN.UXUI
{
    public abstract class AInGameMenuView : MonoDependent
    {
        [Header("Dependencies (AInGameMenuView)")]
        [SerializeField]
        private Object _inGameMenuProviderGeneric = null;

        protected IInGameMenuProvider InGameMenuProvider;

        protected override void ResolveDependencies()
        {
            UTDependency.Resolve(ref _inGameMenuProviderGeneric, out InGameMenuProvider, this);
        }

        protected override void ResolveEventBindings(EventBindingGroup ebs)
        {
            ebs.Add(InGameMenuProvider.OnActivate.Subscribe(HandleActivate));
            ebs.Add(InGameMenuProvider.OnDeactivate.Subscribe(HandleDeactivate));
            ebs.Add(InGameMenuProvider.OnResume.Subscribe(HandleResume));
            ebs.Add(InGameMenuProvider.OnQuit.Subscribe(HandleQuit));
        }

        public abstract void HandleActivate(CVCommand command);

        public abstract void HandleDeactivate(CVCommand command);

        public abstract void HandleResume(CVCommand command);

        public abstract void HandleQuit(CVCommand command);
    }
}