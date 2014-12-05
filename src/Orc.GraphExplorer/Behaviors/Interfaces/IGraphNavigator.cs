// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGraphNavigator.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Behaviors
{
    using Orc.GraphExplorer.Models;

    public interface IGraphNavigator
    {
        #region Methods
        void NavigateTo(DataVertex dataVertex);
        #endregion
    }
}