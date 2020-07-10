using UnityEngine;
using HexUN.MonoB;
using HexUN.Deps;
using HexUN.Patterns;
using TobiasCSStandard.Core;

namespace HexUN.UXUI
{
   public class InGameMenuProviderEventListener : MonoDependent
   {
      [SerializeField]
      private Object _inGameMenuProviderObject = null;

      private IInGameMenuProvider _inGameMenuProvider;

      [SerializeField]
      private CVCommandUnityEvent _onActivateEvent = null;

      protected override void ResolveDependencies()
      {
         UTDependency.Resolve(ref _inGameMenuProviderObject, out _inGameMenuProvider, this, true);
      }

      protected override void ResolveEventBindings(EventBindingGroup ebs)
      {
         if (_inGameMenuProvider != null)
         {
         	ebs.Add(_inGameMenuProvider.OnActivate.Subscribe(_onActivateEvent.Invoke));
         }
      }

   }
}