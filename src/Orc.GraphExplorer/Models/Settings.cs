// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Models
{
    using System.ComponentModel;

    using Catel.Data;

    public class Settings : ModelBase
    {
        #region Properties
        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        [DefaultValue(false)]
        public bool IsSettingsVisible { get; set; }

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        public DataLocationSettings DataLocationSettings { get; set; }
        #endregion
    }
}