// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGraphDataGetter.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Services
{
    using System.Collections.Generic;

    using Orc.GraphExplorer.Models;

    public interface IGraphDataGetter
    {
        #region Methods
        IEnumerable<DataVertex> GetVerteces();

        IEnumerable<DataEdge> GetEdges();
        #endregion
    }
}