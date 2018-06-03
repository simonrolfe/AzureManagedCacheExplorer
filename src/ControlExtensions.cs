using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AzureCacheExplorer
{
//Double-buffering extension to prevent ugly flicker of listview when scrolling.
    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, enable, null);
        }

        public static void SetWatermark(this TextBox textBox, string watermarkText)
        {
            SafeNativeMethods.SendMessageW(textBox.Handle, SafeNativeMethods.EM_SETCUEBANNER, System.IntPtr.Zero, watermarkText);
        }
        
    }

    internal static class SafeNativeMethods
    {
        private const UInt32 ECM_FIRST = 0x1500;
        internal const UInt32 EM_SETCUEBANNER = ECM_FIRST + 1;

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        internal static extern IntPtr SendMessageW(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
    }

}
