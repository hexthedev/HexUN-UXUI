using System.Collections;
using System.Collections.Generic;
using HexUN.Events;
using UnityEngine;

namespace HexUN.UXUI
{
    public class UIFilterString : AUIFilter
    {
        public override void HandleUI(object o)
        {
            string value = o as string;

            if (value != null)
            {
                _onProvideData?.Invoke(value);
            }
        }
    }
}