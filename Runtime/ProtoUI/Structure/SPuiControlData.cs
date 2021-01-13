namespace HexUN.UXUI
{
    /// <summary>
    /// PuiControl and data extracted
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SPuiControlData<T>
    {
        public APuiControl Control;
        public T PuiData;

        public SPuiControlData(APuiControl control, T puiData)
        {
            Control = control;
            PuiData = puiData;
        }
    }
}