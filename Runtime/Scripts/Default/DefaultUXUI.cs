using HexUN.MonoB;

namespace HexUN.UXUI
{
    /// <summary>
    /// Singleton used to pull defaults uiux elements, which is a nicer way to deal with null
    /// </summary>
    public class DefaultUXUI : ANGHexPersistent<DefaultUXUI>
    {
        public SpriteArgs DefaultSpriteArg;
    }
}