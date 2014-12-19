// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationService.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Catel;
    using GraphX.GraphSharp;
    using Models;

    public class NavigationService : INavigationService
    {
        private readonly Explorer _explorer;
        private readonly IGraphAreaLoadingService _loadingService;

        public NavigationService(Explorer explorer, IGraphAreaLoadingService loadingService)
        {
            Argument.IsNotNull(() => explorer);
            Argument.IsNotNull(() => loadingService);

            _explorer = explorer;
            _loadingService = loadingService;
        }

        #region INavigationService Members
        public void NavigateTo(DataVertex dataVertex)
        {
            Argument.IsNotNull(() => dataVertex);

            _explorer.IsNavTabVisible = true;
            _explorer.IsNavTabSelected = true;

            var navigatorArea = _explorer.NavigatorToolset.Area;

            IEnumerable<DataEdge> inEdges;
            IEnumerable<DataEdge> outEdges;

            var graphDataGetter = navigatorArea.GraphDataGetter as IOverridableGraphDataGetter;
            if (graphDataGetter == null)
            {
                return;
            }
            var graph = _explorer.EditorToolset.Area.Logic.Graph;

            if (!graph.TryGetInEdges(dataVertex, out inEdges) || !graph.TryGetOutEdges(dataVertex, out outEdges))
            {
                return;
            }

            var edges = inEdges.Concat(outEdges);

            var vertices = graph.GetNeighbours(dataVertex).Concat(Enumerable.Repeat(dataVertex, 1));

            graphDataGetter.RedefineEdgesGetter(() => edges);
            graphDataGetter.RedefineVertecesGetter(() => vertices);

            _loadingService.ReloadGraphArea(navigatorArea, 0);

            _loadingService.TryRefresh(navigatorArea);
        }
        #endregion
    }
}