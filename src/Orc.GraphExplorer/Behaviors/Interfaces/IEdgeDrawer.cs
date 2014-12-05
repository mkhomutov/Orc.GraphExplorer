// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEdgeDrawer.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Behaviors
{
    using System.Windows;
    using System.Windows.Media;

    using Orc.GraphExplorer.Models;

    public interface IEdgeDrawer
    {
        #region Methods
        bool TryStartEdgeDrawing(DataVertex startVertex, Point startPoint, Point lastPoint);

        bool TryFinishEdgeDrawing(DataVertex endVertex);

        void MoveBrush(Point point);

        PathGeometry GetEdgeGeometry();
        #endregion
    }
}