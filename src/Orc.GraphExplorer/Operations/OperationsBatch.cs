// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationsBatch.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Operations
{
    using System.Collections.Generic;
    using System.Linq;

    using Orc.GraphExplorer.Messages;

    public class OperationsBatch : IOperation
    {
        #region Fields
        private readonly List<IOperation> _operations;
        #endregion

        #region Constructors
        public OperationsBatch()
        {
            _operations = new List<IOperation>();
            CanRedo = true;
        }
        #endregion

        #region Properties
        public IEnumerable<IOperation> Operations
        {
            get
            {
                return _operations.AsEnumerable();
            }
        }
        #endregion

        #region IOperation Members
        public void Undo()
        {
            for (int i = _operations.Count - 1; i >= 0; i--)
            {
                var operation = _operations[i];
                operation.Undo();
            }

            StatusMessage.SendWith(string.Format("Undo {0}", Description));
        }

        public void Redo()
        {
            Do();
            StatusMessage.SendWith(string.Format("Redo {0}", Description));
        }

        public object Target { get; private set; }

        public string Description { get; set; }

        public object Tag { get; set; }

        public bool CanRedo { get; private set; }

        public void Do()
        {
            foreach (var operation in _operations)
            {
                operation.Do();
            }
        }
        #endregion

        #region Methods
        public void AddOperation(IOperation operation)
        {
            _operations.Add(operation);
        }
        #endregion
    }
}