// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyView.xaml.cs" company="Orcomp development team">
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
    /// Логика взаимодействия для PropertyView.xaml
    /// </summary>
    public partial class PropertyView
    {
        #region Constructors
        public PropertyView()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public new PropertyViewModel ViewModel
        {
            get
            {
                return base.ViewModel as PropertyViewModel;
            }
        }
        #endregion

        #region Methods
        protected override void OnViewModelChanged()
        {
            DataContext = ViewModel;
            base.OnViewModelChanged();

            Loaded += PropertyView_Loaded;
            CloseViewModelOnUnloaded = false;
        }

        private void PropertyView_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = ViewModel;

            var relationalViewModel = viewModel as IRelationalViewModel;
            var parentView = this.FindLogicalOrVisualAncestorByType<VertexView>();
            if (parentView != null && relationalViewModel != null && viewModel.ParentViewModel == null)
            {
                relationalViewModel.SetParentViewModel(parentView.ViewModel);
            }
        }
        #endregion
    }
}