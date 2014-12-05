// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Demo.ViewModels
{
    using Catel;
    using Catel.MVVM;

    using Orc.GraphExplorer.Messages;

    using Orchestra.Services;

    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private readonly IStatusService _statusService;
        #endregion

        #region Constructors
        public MainViewModel(IStatusService statusService)
        {
            Argument.IsNotNull(() => statusService);

            _statusService = statusService;
            StatusMessage.Register(this, OnStatusMessage);
        }
        #endregion

        #region Methods
        private void OnStatusMessage(StatusMessage message)
        {
            if (_statusService == null)
            {
                return;
            }

            _statusService.UpdateStatus(message.Data);
        }
        #endregion
    }
}