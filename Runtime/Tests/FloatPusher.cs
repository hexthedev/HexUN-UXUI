using HexUN.Events;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.Sub.UIUX.Tests
{
    public class FloatPusher : MonoBehaviour
    {
        public SingleReliableEvent _onPercentageChange;

        [Range(0, 1)]
        public float percentageFloat;

        public void OnAwake()
        {
            _onPercentageChange.Invoke(percentageFloat);
        }

        public void OnValidate()
        {
            _onPercentageChange.Invoke(percentageFloat);
        }
    }
}