using System;
using System.Collections.Generic;
using System.Text;

namespace Roman.CQRS.Abstraction.Query
{
    public class ListQueryParameters : IListQueryParameters
    {
        public string? SortBy { get; set; } = null;

        public int ItemsPerPage { get; set; } = -1;
        public int Page { get; set; } = 1;
        public bool? SortDesc { get; set; } = null;

        public void AssignListQueryParameters(ListQueryParameters parameters)
        {
            ItemsPerPage = parameters.ItemsPerPage;
            Page = parameters.Page;
            SortBy = parameters.SortBy;
            SortDesc = parameters.SortDesc;
        }
    }
}