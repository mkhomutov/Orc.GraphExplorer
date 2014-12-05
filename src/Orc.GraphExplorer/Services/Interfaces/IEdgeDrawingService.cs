// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEdgeDrawingService.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Services
{
    using System.Windows;
    using System.Windows.Media;

    using Orc.GraphExplorer.Models;
    using Orc.GraphExplorer.Models.Data;

    public interface IEdgeDrawingService
    {
        #region Methods
        bool IsInDrawing();

        void StartEdgeDrawing(Graph graph, DataVertex startVertex, Point startPoint, Point lastPoint);

        bool IsStartVertex(DataVertex dataVertex);

        void FinishEdgeDrawing(DataVertex endVertex);

        DataVertex GetStartVertex();

        void MoveBrush(Point point);

        PathGeometry GetEdgeGeometry();
        #endregion
    }
}