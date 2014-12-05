// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGraphLogicProvider.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer
{
    using Orc.GraphExplorer.Models.Data;

    public interface IGraphLogicProvider
    {
        #region Properties
        GraphLogic Logic { get; }
        #endregion
    }
}