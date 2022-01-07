﻿using System;

using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace ModernFlyouts.Settings.ViewModels
{
    public class Appearance_BehaviorViewModel : ObservableObject
    {
        public Func<string, int> UpdateUIThemeCallBack { get; }
        public Appearance_BehaviorViewModel()
        {

            // set the callback function value to update the UI theme.
            //UpdateUIThemeCallBack = updateTheme;

            //UpdateUIThemeCallBack(GeneralSettingsConfig.Theme);

            //            // Update Settings file folder:
            //            _settingsConfigFileFolder = configFileSubfolder;

            //            // Using Invariant here as these are internal strings and fxcop
            //            // expects strings to be normalized to uppercase. While the theme names
            //            // are represented in lowercase everywhere else, we'll use uppercase
            //            // normalization for switch statements
            //            switch (GeneralSettingsConfig.Theme.ToUpperInvariant())
            //            {
            //                case "DARK":
            //                    _themeIndex = 0;
            //                    break;
            //                case "LIGHT":
            //                    _themeIndex = 1;
            //                    break;
            //                case "SYSTEM":
            //                    _themeIndex = 2;
            //                    break;
            //            }


            //                    public int ThemeIndex
            //        {
            //            get
            //            {
            //                return _themeIndex;
            //            }

            //            set
            //            {
            //                if (_themeIndex != value)
            //                {
            //                    switch (value)
            //                    {
            //                        case 0: GeneralSettingsConfig.Theme = "dark"; break;
            //                        case 1: GeneralSettingsConfig.Theme = "light"; break;
            //                        case 2: GeneralSettingsConfig.Theme = "system"; break;
            //                    }

            //                    _themeIndex = value;

            //                    try
            //                    {
            //                        UpdateUIThemeCallBack(GeneralSettingsConfig.Theme);
            //                    }
            //#pragma warning disable CA1031 // Do not catch general exception types
            //                    catch (Exception e)
            //#pragma warning restore CA1031 // Do not catch general exception types
            //                    {
            //                        Logger.LogError("Exception encountered when changing Settings theme", e);
            //                    }

            //                    NotifyPropertyChanged();
            //                }
            //            }
            //        }


        }
}
}
