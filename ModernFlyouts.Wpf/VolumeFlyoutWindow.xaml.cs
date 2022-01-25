﻿using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using NPSMLib;
using ModernFlyouts.Uwp;
using System.Diagnostics;
using ModernFlyouts.Core.Utilities;
using ModernFlyouts.Standard.Classes;
using System.Linq;
using ModernFlyouts.Utilities;

namespace ModernFlyouts.Wpf
{
    public partial class VolumeFlyoutWindow : Window
    {
        private VolumeFlyoutControl Volumeflyoutcontrol;
        private static NowPlayingSessionManager NPSessionManager;

        public VolumeFlyoutWindow() => InitializeComponent();

        private async void OnFlyoutControlLoaded(object sender, EventArgs e)
        {
            Volumeflyoutcontrol = (sender as WindowsXamlHost).Child as VolumeFlyoutControl;
            NPSessionManager = new NowPlayingSessionManager();
            NPSessionManager.SessionListChanged += NPSessionManager_SessionListChanged;
            foreach (var i in NPSessionManager.GetSessions())
            {

                // SessionConstructor should work here but it doesnt, maybe it an async problem but it should replace this
                using var process = Process.GetProcessById((int)i.PID);
                if (IsImmersiveProcess(process.Handle))
                {
                    Volumeflyoutcontrol.MediaSessions.Add(await ModernAppInfoExtractor.GetModernAppInfo(i));
                }
                else
                {
                    Volumeflyoutcontrol.MediaSessions.Add(DesktopAppInfoExtractor.GetDesktopAppInfo(i));
                }
            }
        }

        private async void NPSessionManager_SessionListChanged(object sender, NowPlayingSessionManagerEventArgs e)
        {
            if (e.NotificationType == NowPlayingSessionManagerNotificationType.SessionCreated)
            {
                // Same here should be replaced
                var session = NPSessionManager.FindSession(e.NowPlayingSessionInfo);
                using var process = Process.GetProcessById((int)session.PID);
                if (IsImmersiveProcess(process.Handle))
                {
                    Volumeflyoutcontrol.AddSession(await ModernAppInfoExtractor.GetModernAppInfo(session));
                }
                else
                {
                    Volumeflyoutcontrol.AddSession(DesktopAppInfoExtractor.GetDesktopAppInfo(session));
                }
            }
            else if (e.NotificationType == NowPlayingSessionManagerNotificationType.SessionDisconnected)
            {
                 var mediaSession = Volumeflyoutcontrol.MediaSessions.Cast<MediaSession>().FirstOrDefault(x => x.MediaPlayingSession.GetSessionInfo().Equals(e.NowPlayingSessionInfo));
                 Volumeflyoutcontrol.RemoveSession(mediaSession);
            }

        }
        [DllImport("user32.dll")]
        public static extern bool IsImmersiveProcess(IntPtr hProcess);
        #region Flyout skeleton code

        private void Window_Activated(object sender, EventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
        }

        private void Window_Deactivated(object sender, EventArgs e) => Dispatcher.Invoke(() => { Close(); });

        public void ShowFlyout()
        {
            if (Volumeflyoutcontrol == null) return;
            Activate();
            Volumeflyoutcontrol.ShowFlyout();
        }
        private void DragWindow(object sender, MouseButtonEventArgs e) => DragMove();

        #endregion
    }
}