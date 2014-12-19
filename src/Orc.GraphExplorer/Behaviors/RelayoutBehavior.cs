// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelayoutBehavior.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Behaviors
{
    using System;

    using Catel.Windows;
    using Catel.Windows.Interactivity;

    using GraphX.Controls;
    using Models;
    using Orc.GraphExplorer.Views.Base;
    using ViewModels;

    public class RelayoutBehavior : BehaviorBase<GraphAreaViewBase>
    {
        #region Methods
        protected override void OnAssociatedObjectLoaded()
        {
            base.OnAssociatedObjectLoaded();
            AssociatedObject.GenerateGraphFinished += AssociatedObject_GenerateGraphFinished;
            ResumeRelayout();
        }

        private void AssociatedObject_GenerateGraphFinished(object sender, EventArgs e)
        {
            ResumeRelayout();
        }

        private void ResumeRelayout()
        {
            ShowAllEdgesLabels(true);
            FitToBounds();
            var areaViewModel = AssociatedObject.ViewModel as GraphAreaViewModel;
            if (areaViewModel != null)
            {
                var filter = areaViewModel.ToolSetViewModel.Toolset.Filter;
                filter.ChangeFilterSource(filter.GraphLogic.Graph.Vertices);
            }
        }

        private void ShowAllEdgesLabels(bool show)
        {
            var graphAreaViewBase = AssociatedObject;

            graphAreaViewBase.ShowAllEdgesLabels(show);
            graphAreaViewBase.InvalidateVisual();
        }

        private void FitToBounds()
        {
            var zoom = AssociatedObject.FindLogicalOrVisualAncestorByType<ZoomControl>();
            zoom.ZoomToFill();

            zoom.Mode = ZoomControlModes.Custom;
        }
        #endregion
    }
}