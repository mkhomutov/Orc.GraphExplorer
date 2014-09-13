﻿namespace Orc.GraphExplorer.Operations
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.MVVM.Views;
    using GraphX;
    using Models;

    using Orc.GraphExplorer.ObjectModel;
    using Orc.GraphExplorer.Views;
    using Services.Interfaces;
    using ViewModels;

    public class CreateVertexOperation : VertexOperation
    {
        double _x;
        double _y;
        const double GapX = 150;
        const double GapY = 150;
        const string CreateVertex = "Create Vertex";
        public override string Sammary
        {
            get { return CreateVertex; }
        }

        public override void Do()
        {
            _vCtrl = new VertexControl(_vertex);
            AddVertex(_vertex, _vCtrl);
            //ArrangeVertexPosition();

            if (_x != double.MinValue && _y != double.MinValue)
            {
                SetPositon();
            }

            if (_callback != null)
            {
                _callback.Invoke(_vertex, _vCtrl);
            }

        }

        private void SetPositon()
        {
            var app = Application.Current;

            if (app != null)
            {
                RunCodeInUiThread(() =>
                {
                    if (_x != double.MinValue)
                    { GraphArea.SetX(_vCtrl, _x, true); }
                    if (_y != double.MinValue)
                    { GraphArea.SetY(_vCtrl, _y, true); }
                }, app.Dispatcher, DispatcherPriority.Loaded);
            }
            else
            {
                if (_x != double.MinValue)
                { GraphArea.SetX(_vCtrl, _x, true); }
                if (_y != double.MinValue)
                { GraphArea.SetY(_vCtrl, _y, true); }
            }
        }

        //private void ArrangeVertexPosition()
        //{
        //    double maxY
        //    //throw new NotImplementedException();
        //}

        public override void UnDo()
        {            
            RemoveVertex(_vertex);

            if (_undoCallback != null)
            {
                _undoCallback.Invoke(_vertex);
            }
        }

        public CreateVertexOperation(GraphArea area, DataVertex data = null, double x = double.MinValue, double y = double.MinValue, Action<DataVertex, VertexControl> callback = null, Action<DataVertex> undoCallback = null)
            : base(area, data, callback, undoCallback)
        {
            _vCtrl = new VertexControl(_vertex);

            if (x != double.MinValue)
                _x = x;

            if (y != double.MinValue)
                _y = y;
        }

        // TODO: to be refactored
        public static CreateVertexOperation NewOperation(ZoomViewModel zoomViewModel, Point position)
        {
            var viewManager = ServiceLocator.Default.ResolveType<IViewManager>();
            var views = viewManager.GetViewsOfViewModel(zoomViewModel);
            var view = views.Single() as ContentControl;
            var area = view.Content as GraphArea;

            var viewModelManager = ServiceLocator.Default.ResolveType<IViewModelManager>();

            var graphExplorerViewModel = viewModelManager.GetFirstOrDefaultInstance<GraphExplorerViewModel>();
            if (graphExplorerViewModel == null)
            {
                throw new NoNullAllowedException(string.Format("Uable to find viewmodel {0}", typeof(GraphExplorerViewModel)));
            }

            return  new CreateVertexOperation(area, DataVertex.Create(), position.X, position.Y, (v, vc) =>
            {
                graphExplorerViewModel.SelectedVertices.Add(v.Id);

                graphExplorerViewModel.UpdateHighlightBehaviour(false);

                foreach (int selectedV in graphExplorerViewModel.SelectedVertices)
                {
                    VertexControl localvc = area.VertexList.Where(pair => pair.Key.Id == selectedV).Select(pair => pair.Value).FirstOrDefault();
                    HighlightBehaviour.SetHighlighted(localvc, true);
                }

                if (graphExplorerViewModel.CanDrag)
                {
                    DragBehaviour.SetIsDragEnabled(vc, true);
                }
                else
                {
                    DragBehaviour.SetIsDragEnabled(vc, false);
                }

                v.IsEditing = true;
                v.OnPositionChanged -= v_OnPositionChanged;
                v.OnPositionChanged += v_OnPositionChanged;
            }, v =>
            {
                graphExplorerViewModel.SelectedVertices.Remove(v.Id);
                //on vertex recreated
            });
        }
        // TODO: to be refactored
        private static void v_OnPositionChanged(object sender, DataVertex.VertexPositionChangedEventArgs e)
        {
            var viewModelManager = ServiceLocator.Default.ResolveType<IViewModelManager>();
            var graphExplorerViewModel = viewModelManager.GetFirstOrDefaultInstance<GraphExplorerViewModel>();
            if (graphExplorerViewModel == null)
            {
                throw new NoNullAllowedException(string.Format("Uable to find viewmodel {0}", typeof(GraphExplorerViewModel)));
            }

            var viewManager = ServiceLocator.Default.ResolveType<IViewManager>();
            var views = viewManager.GetViewsOfViewModel(graphExplorerViewModel);
            var view = views.Single() as GraphExplorerView;
            var area = view.Area;

            var operationObserver = ServiceLocator.Default.ResolveType<IOperationObserver>();

            var vertex = (DataVertex)sender;
            if (area.VertexList.Keys.Any(v => v.Id == vertex.Id))
            {
                VertexControl vc = area.VertexList.First(v => v.Key.Id == vertex.Id).Value;
                //throw new NotImplementedException();
                operationObserver.Do(new VertexPositionChangeOperation(area, vc, e.OffsetX, e.OffsetY, vertex));
            }
        }
    }
}
