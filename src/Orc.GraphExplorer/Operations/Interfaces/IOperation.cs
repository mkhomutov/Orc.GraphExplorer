// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOperation.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Operations
{
    using Catel.Memento;

    public interface IOperation : IMementoSupport
    {
        #region Methods
        void Do();
        #endregion
    }
}