﻿namespace HexUN.UXUI
{
    /// <summary>
    /// Able to view a string
    /// </summary>
    public abstract class APuiStringView : APuiControl
    {
        private string _stringValue;

        /// <summary>
        /// String value managed by the view
        /// </summary>
        public string StringValue { 
            get => _stringValue;
            set {
                _stringValue = value;
                Render();
            } 
        }
    }
}