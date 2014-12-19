// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INavigationService.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Services
{
    using Orc.GraphExplorer.Models;

    public interface INavigationService
    {
        #region Methods
        void NavigateTo(DataVertex dataVertex);
        #endregion
    }
}