// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGraphDataSaver.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Services
{
    using Orc.GraphExplorer.Models.Data;

    public interface IGraphDataSaver
    {
        #region Methods
        void SaveChanges(Graph graph);
        #endregion
    }
}