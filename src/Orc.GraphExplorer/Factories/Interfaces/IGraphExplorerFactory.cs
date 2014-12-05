// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGraphExplorerFactory.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Factories
{
    using Orc.GraphExplorer.Models;

    public interface IGraphExplorerFactory
    {
        #region Methods
        Explorer CreateExplorer();
        #endregion
    }
}