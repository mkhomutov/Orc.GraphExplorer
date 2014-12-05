// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GraphLogic.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Models.Data
{
    using System;

    using Catel;

    using GraphX.Logic;

    public class GraphLogic : GXLogicCore<DataVertex, DataEdge, Graph>
    {
        #region Constructors
        public GraphLogic()
        {
        }
        #endregion

        #region Methods
        public void PrepareGraphReloading()
        {
            BeforeReloadingGraph.SafeInvoke(this);
        }

        public void ResumeGraphReloading(Graph graph)
        {
            Argument.IsNotNull(() => graph);

            GraphReloaded.SafeInvoke(this, new GraphEventArgs(graph));
        }
        #endregion

        public event EventHandler BeforeReloadingGraph;

        public event EventHandler<GraphEventArgs> GraphReloaded;
    }
}