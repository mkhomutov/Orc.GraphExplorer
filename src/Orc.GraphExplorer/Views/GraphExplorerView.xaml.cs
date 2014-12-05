// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GraphExplorerView.xaml.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Views
{
    using Orc.GraphExplorer.ViewModels;

    /// <summary>
    /// Логика взаимодействия для GraphExplorerView.xaml
    /// </summary>
    public partial class GraphExplorerView
    {
        #region Constructors
        public GraphExplorerView()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public new GraphExplorerViewModel ViewModel
        {
            get
            {
                return base.ViewModel as GraphExplorerViewModel;
            }
        }
        #endregion

        #region Methods
        protected override void OnViewModelChanged()
        {
            base.OnViewModelChanged();

            DataContext = ViewModel;
        }
        #endregion
    }
}