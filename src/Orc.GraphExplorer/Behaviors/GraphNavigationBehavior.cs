// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GraphNavigationBehavior.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Behaviors
{
    using Catel.IoC;
    using Catel.Windows.Interactivity;

    using Orc.GraphExplorer.Views;
    using Orc.GraphExplorer.Views.Base;
    using Services;
    using ViewModels;

    public class GraphNavigationBehavior : BehaviorBase<GraphAreaViewBase>
    {
        #region Fields
        private INavigationService _navigationService;
        #endregion

        #region Methods
        protected override void OnAssociatedObjectLoaded()
        {
            base.OnAssociatedObjectLoaded();

            var serviceLocator = AssociatedObject.ViewModel.GetServiceLocator();// as IGraphNavigator;
            _navigationService = serviceLocator.ResolveType<INavigationService>();
            
            AssociatedObject.VertexDoubleClick += AssociatedObject_VertexDoubleClick;
        }

        protected override void OnAssociatedObjectUnloaded()
        {
            AssociatedObject.VertexDoubleClick -= AssociatedObject_VertexDoubleClick;
        }

        private GraphAreaViewModel GraphAreaViewModel { get { return AssociatedObject.ViewModel as GraphAreaViewModel; } }

        private void AssociatedObject_VertexDoubleClick(object sender, GraphX.Models.VertexSelectedEventArgs args)
        {
            var vertexView = args.VertexControl as VertexView;
            if (vertexView == null)
            {
                return;
            }

            if (GraphAreaViewModel == null)
            {
                return;
            }

            if (GraphAreaViewModel.CanNavigate)
            {
                _navigationService.NavigateTo(vertexView.ViewModel.DataVertex);
            }
        }
        #endregion
    }
}