// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddEdgeOperation.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Operations
{
    using Catel;

    using Orc.GraphExplorer.Messages;
    using Orc.GraphExplorer.Models;

    public class AddEdgeOperation : IOperation
    {
        #region Fields
        private readonly GraphArea _graphArea;

        private readonly DataEdge _edge;
        #endregion

        #region Constructors
        public AddEdgeOperation(GraphArea graphArea, DataEdge edge)
        {
            Argument.IsNotNull(() => graphArea);
            Argument.IsNotNull(() => edge);

            _graphArea = graphArea;
            _edge = edge;
            CanRedo = true;
            Description = "add egde";
        }
        #endregion

        #region IOperation Members
        public void Undo()
        {
            _graphArea.Logic.Graph.RemoveEdge(_edge);
            StatusMessage.SendWith(string.Format("Undo {0}", Description));
        }

        public void Redo()
        {
            Do();

            StatusMessage.SendWith(string.Format("Redo {0}", Description));
        }

        public object Target { get; private set; }

        public string Description { get; set; }

        public object Tag { get; set; }

        public bool CanRedo { get; private set; }

        public void Do()
        {
            _graphArea.Logic.Graph.AddEdge(_edge);
        }
        #endregion
    }
}