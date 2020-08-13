﻿using UnityEngine;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    public abstract class APuiSlotView : APuiView<APuiSlotControl>
    {
        [Header("Dependencies (APuiSlotView)")]
        [SerializeField]
        [Tooltip("Sprite configuration for empty disabled slot")]
        public SpriteArgs EmptyDisabledSprite = null;

        [SerializeField]
        [Tooltip("Sprite configuration for empty enabled slot")]
        public SpriteArgs EmptyEnabledSprite = null;

        [SerializeField]
        [Tooltip("Image component used to show the slot visuals")]
        protected Image ImageComponent = null;

        public abstract void PopulateSlot(GameObject obj);

        public abstract void Clear();
    }
}