using HexCS.Core;
using HexUN.Patterns;

namespace HexUN.UXUI
{
    public interface IInGameMenuProvider
    {
        bool IsActive { get; }

        IEventSubscriber<CVCommand> OnActivate { get; }

        IEventSubscriber<CVCommand> OnDeactivate { get; }

        IEventSubscriber<CVCommand> OnResume { get; }

        IEventSubscriber<CVCommand> OnQuit { get; }
    }
}