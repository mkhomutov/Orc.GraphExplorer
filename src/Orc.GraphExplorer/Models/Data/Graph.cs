// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Graph.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Models.Data
{
    using Catel;

    using Orc.GraphExplorer.Services;

    using QuickGraph;

    public class Graph : BidirectionalGraph<DataVertex, DataEdge>
    {
        #region Fields
        private readonly IGraphDataGetter _graphDataGetter;
        #endregion

        #region Constructors
        public Graph()
        {
        }

        public Graph(IGraphDataGetter graphDataGetter)
        {
            Argument.IsNotNull(() => graphDataGetter);

            _graphDataGetter = graphDataGetter;
        }
        #endregion

        #region Methods
        public void ReloadGraph()
        {
            RemoveEdgeIf(e => true);
            RemoveVertexIf(v => true);

            AddVertexRange(_graphDataGetter.GetVerteces());
            AddEdgeRange(_graphDataGetter.GetEdges());
        }
        #endregion
    }
}