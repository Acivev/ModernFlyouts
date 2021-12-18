﻿using System;
using System.Runtime.InteropServices;

namespace ModernFlyouts.WPF.Helpers
{
    public static class NativeMethods
    {
        internal const int SW_SHOWNORMAL = 1;
        internal const int SW_SHOWMAXIMIZED = 3;

        [DllImport("user32.dll")]
        internal static extern bool SetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        internal static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);
    }
}
