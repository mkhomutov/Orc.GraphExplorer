// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataVertexFactory.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Factories
{
    using Orc.GraphExplorer.Models;

    public interface IDataVertexFactory
    {
        #region Methods
        DataVertex CreateFakeVertex();

        DataVertex CreateVertex();

        DataVertex CreateVertex(int id);
        #endregion
    }
}