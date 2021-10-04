﻿using CleanArchitectureTemplate.Core.Specifications.Interfaces;
using Ardalis.Specification;

namespace CleanArchitectureTemplate.Core.Specifications
{
    /// <summary>
    ///     Specification for searching and returning aggregated value. E.g. Count, Sum, etc..
    ///     This is similar to a search specification, minus the sorting.
    /// </summary>
    public class ToDoItemSearchAggregationSpecification : Specification<Entities.ToDoItem>
    {
        public ToDoItemSearchAggregationSpecification(string title = "",
                                             int pageStart = 0,
                                             int pageSize = 50,
                                             string sortColumn = "title",
                                             SortDirection sortDirection = SortDirection.Ascending,
                                             bool exactSearch = false
                                             )
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                if (exactSearch)
                {
                    Query.Where(item => item.Title.ToLower() == title.ToLower());
                }
                else
                {
                    Query.Where(item => item.Title.ToLower().Contains(title.ToLower()));
                }
            }

        }
    }
}
