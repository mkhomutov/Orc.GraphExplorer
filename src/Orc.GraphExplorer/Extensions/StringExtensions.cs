// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer
{
    using System.Linq;

    using Catel;

    public static class StringExtensions
    {
        #region Methods
        public static bool IsInteger(this string str)
        {
            Argument.IsNotNull(() => str);

            return !string.IsNullOrEmpty(str) && str.All(c => "0123456789".Contains(c));
        }
        #endregion
    }
}