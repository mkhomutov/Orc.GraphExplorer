// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataLocationSettingsService.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Services
{
    using Orc.GraphExplorer.Models;

    public interface IDataLocationSettingsService
    {
        #region Methods
        DataLocationSettings Load();

        DataLocationSettings GetCurrentOrLoad();

        void Save(DataLocationSettings dataLocationSettings);
        #endregion
    }
}