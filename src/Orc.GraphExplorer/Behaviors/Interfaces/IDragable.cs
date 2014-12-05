// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDragable.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Behaviors
{
    using System;
    using System.Windows;

    public interface IDragable
    {
        #region Properties
        Type DataType { get; }
        #endregion

        #region Methods
        DragDropEffects GetDragEffects();

        object GetData();
        #endregion
    }
}