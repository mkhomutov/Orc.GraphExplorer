﻿using System;
using Catel.IoC;

using Orc.GraphExplorer;
using Orc.GraphExplorer.Csv.Services;
using Orc.GraphExplorer.Factories;
using Orc.GraphExplorer.Services;
using Orc.GraphExplorer.Models;
using GraphX.Controls.Models;

using Catel.Memento;

/// <summary>
/// Used by the ModuleInit. All code inside the Initialize method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    /// <summary>
    /// Initializes the module.
    /// </summary>
    public static void Initialize()
    {
        var serviceLocator = ServiceLocator.Default;
        serviceLocator.RegisterType<IDataLocationSettingsService, DataLocationSettingsService>();    
        serviceLocator.RegisterType<IGraphControlFactory, CustomGraphControlFactory>();
        serviceLocator.RegisterType(typeof(IGraphDataGetter), typeof(CsvGraphDataService));
        serviceLocator.RegisterType<IMementoService, MementoService>();
        serviceLocator.RegisterType<IGraphAreaEditorService, GraphAreaEditorService>();
        serviceLocator.RegisterType<IGraphAreaLoadingService, GraphAreaLoadingService>();
        serviceLocator.RegisterType<IEdgeDrawingService, EdgeDrawingService>();
        serviceLocator.RegisterType<IDataVertexFactory, DataVertexFactory>();
        serviceLocator.RegisterType<IGraphDataService, CsvGraphDataService>();
        serviceLocator.RegisterType<IGraphExplorerFactory, GraphExplorerFactory>();
        serviceLocator.RegisterType<INavigationService, NavigationService>();
        serviceLocator.RegisterType<Explorer>(CreateExplorer);
    }

    private static Explorer CreateExplorer(ServiceLocatorRegistration serviceLocatorRegistration)
    {
        var serviceLocator = ServiceLocator.Default;
        var factory = serviceLocator.ResolveType<IGraphExplorerFactory>();
        return factory.CreateExplorer();
    }
}