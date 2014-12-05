// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveVertexOperation.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Operations
{
    using System.Windows;

    using Catel;

    using Orc.GraphExplorer.Messages;
    using Orc.GraphExplorer.Models;

    public class RemoveVertexOperation : IOperation
    {
        #region Fields
        private readonly GraphArea _graphArea;

        private readonly DataVertex _vertex;

        private readonly Point _point;
        #endregion

        #region Constructors
        public RemoveVertexOperation(GraphArea graphArea, DataVertex vertex)
        {
            Argument.IsNotNull(() => graphArea);
            Argument.IsNotNull(() => vertex);

            _graphArea = graphArea;
            _vertex = vertex;

            if (!graphArea.Logic.ExternalLayoutAlgorithm.VertexPositions.TryGetValue(vertex, out _point) && vertex.Tag is Point)
            {
                _point = (Point)vertex.Tag;
            }
            else if (default(Point).Equals(_point))
            {
                _point = new Point(_point.X, _point.Y);
            }

            Target = _graphArea;
            CanRedo = true;

            Description = "remove vertex";
        }
        #endregion

        #region IOperation Members
        public void Undo()
        {
            _vertex.Tag = _point;
            _graphArea.Logic.Graph.AddVertex(_vertex);

            StatusMessage.SendWith(string.Format("Undo {0}", Description));
        }

        public void Redo()
        {
            Do();
            StatusMessage.SendWith(string.Format("Redo {0}", Description));
        }

        public void Do()
        {
            _graphArea.Logic.Graph.RemoveVertex(_vertex);
        }

        public object Target { get; private set; }

        public string Description { get; set; }

        public object Tag { get; set; }

        public bool CanRedo { get; private set; }
        #endregion
    }
}