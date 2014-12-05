// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataVertexFactory.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Factories
{
    using Orc.GraphExplorer.Models;

    public class DataVertexFactory : IDataVertexFactory
    {
        #region Constants
        private static int _maxId = 0;
        #endregion

        #region IDataVertexFactory Members
        public DataVertex CreateFakeVertex()
        {
            return new DataVertex(DataVertex.FakeVertexId);
        }

        public DataVertex CreateVertex()
        {
            return new DataVertex(++_maxId);
        }

        public DataVertex CreateVertex(int id)
        {
            if (id > _maxId)
            {
                _maxId = id + 1;
            }

            return new DataVertex(id);
        }
        #endregion
    }
}