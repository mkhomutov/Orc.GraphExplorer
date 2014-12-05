﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MahAppsService.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Demo.Services
{
    using System.Windows;

    using MahApps.Metro.Controls;

    using Orc.GraphExplorer.Demo.Views;

    using Orchestra.Models;
    using Orchestra.Services;

    public class MahAppsService : IMahAppsService
    {
        #region IMahAppsService Members
        public AboutInfo GetAboutInfo()
        {
            return new AboutInfo();
        }

        public WindowCommands GetRightWindowCommands()
        {
            return new WindowCommands();
        }

        public FrameworkElement GetMainView()
        {
            return new MainWindow();
        }
        #endregion
    }
}