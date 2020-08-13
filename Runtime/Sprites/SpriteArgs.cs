﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    [CreateAssetMenu(fileName = "SpriteArgs", menuName = "HexUN/UI/SpriteArgs")]
    public class SpriteArgs : ScriptableObject
    {
        public Sprite Sprite;

        public bool OverrideColor;
        public Color Color;
        
        public void ApplyToImage(Image image)
        {
            image.sprite = Sprite;
            if(OverrideColor) image.color = Color;
        }
    }
}