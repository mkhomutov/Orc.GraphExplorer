// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterableEntity.cs" company="Orcomp development team">
//   Copyright (c) 2008 - 2014 Orcomp development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.GraphExplorer.Models.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Catel;

    public class FilterableEntity
    {
        #region Constructors
        public FilterableEntity(DataVertex vertex)
        {
            Argument.IsNotNull(() => vertex);

            ID = vertex.ID;
            Title = vertex.Title;
            FirstName = vertex.Properties.Any(p => string.Equals(p.Key, "FirstName")) ? vertex.Properties.First(p => string.Equals(p.Key, "FirstName")).Value : string.Empty;
            LastName = vertex.Properties.Any(p => string.Equals(p.Key, "LastName")) ? vertex.Properties.First(p => string.Equals(p.Key, "LastName")).Value : string.Empty;
            Age = vertex.Properties.Any(p => string.Equals(p.Key, "Age") && p.Value.IsInteger()) ? int.Parse((vertex.Properties.First(p => string.Equals(p.Key, "Age")).Value)) : 0;
            Vertex = vertex;
        }
        #endregion

        #region Properties
        public int ID { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DataVertex Vertex { get; set; }
        #endregion

        #region Methods
        public static IEnumerable<FilterableEntity> GenerateFilterableEntities(IEnumerable<DataVertex> vertices)
        {
            Argument.IsNotNull(() => vertices);

            var enumerable = vertices.Select(v => new FilterableEntity(v));

            return enumerable;
        }
        #endregion
    }
}