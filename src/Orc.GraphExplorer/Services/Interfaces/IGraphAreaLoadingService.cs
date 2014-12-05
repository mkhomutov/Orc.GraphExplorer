// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGraphAreaLoadingService.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Services
{
    using System.Threading.Tasks;

    using Orc.GraphExplorer.Models;

    public interface IGraphAreaLoadingService
    {
        #region Methods
        void ReloadGraphArea(GraphArea graphArea, int offsetY);

        Task<bool> TryRefresh(GraphArea area);
        #endregion
    }
}