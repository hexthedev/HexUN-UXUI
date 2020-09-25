using UnityEngine;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    [CreateAssetMenu(fileName = "SpriteArgs", menuName = "HexUN/UI/SpriteArgs")]
    public class SpriteArgs : ScriptableObject
    {
        public Sprite Neutral;
        public Sprite Hover;
        public Sprite Down;
        public Sprite Highlighted;
        public Sprite Disabled;

        public bool OverrideColor;
        public Color Color;
        
        public void ApplyToImage(Image image, EUiVisualState state = EUiVisualState.Neutral)
        {
            if(Neutral == null)
            {
                SpriteArgs def = DefaultUXUI.Instance.DefaultSpriteArg;
                def.ApplyToImage(image, state);
                return;
            }

            image.sprite = GetSprite(state);
            if(OverrideColor) image.color = Color;
        }

        public Sprite GetSprite(EUiVisualState state)
        {
            switch (state)
            {
                case EUiVisualState.Neutral: return Neutral;
                case EUiVisualState.Hover: return Hover;
                case EUiVisualState.Down: return Down;
                case EUiVisualState.Highlighted: return Highlighted;
                case EUiVisualState.Disabled: return Disabled;
            }

            return null;
        }
    }
}