using System;
using HexUN.Data;

namespace HexUN.UXUI
{
    /// <summary>
    /// A ui printer is a monbehaviour that takes in some type
    /// and shows the info on a UI element somehow
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AUIPrinter<T> : AMonoDataReciever
    {
        /// <summary>
        /// Render the value to some UI element
        /// </summary>
        /// <param name="value"></param>
        public abstract void Print(T value);

        protected override void HandleDataReceived(object data)
        {
            T dataCasted;

            try
            {
                dataCasted = (T)data;

            }
            catch (InvalidCastException)
            {
                return;
            }

            Print(dataCasted);
        }
    }
}