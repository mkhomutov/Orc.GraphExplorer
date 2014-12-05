// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GraphToolsetView.xaml.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Views
{
    using System.Windows;

    using Catel.MVVM;
    using Catel.Windows;

    using Orc.GraphExplorer.ViewModels;

    /// <summary>
    /// Логика взаимодействия для GraphToolsetView.xaml
    /// </summary>
    public partial class GraphToolsetView
    {
        #region Constructors
        public GraphToolsetView()
        {
            CloseViewModelOnUnloaded = false;
            InitializeComponent();
            Loaded += GraphToolsetView_Loaded;
        }
        #endregion

        #region Properties
        public new GraphToolsetViewModel ViewModel
        {
            get
            {
                return base.ViewModel as GraphToolsetViewModel;
            }
        }
        #endregion

        #region Methods
        private void GraphToolsetView_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = ViewModel;

            var relationalViewModel = viewModel as IRelationalViewModel;
            var parentView = this.FindLogicalOrVisualAncestorByType<GraphExplorerView>();
            if (parentView != null && relationalViewModel != null && viewModel.ParentViewModel == null)
            {
                relationalViewModel.SetParentViewModel(parentView.ViewModel);
            }
        }
        #endregion
    }
}