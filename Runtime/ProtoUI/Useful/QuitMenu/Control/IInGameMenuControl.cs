

namespace HexUN.UXUI
{
    public interface IInGameMenuControl : IInGameMenuProvider
    {
        void Deactivate();

        void Activate();

        void Resume();

        void Quit();
    }
}