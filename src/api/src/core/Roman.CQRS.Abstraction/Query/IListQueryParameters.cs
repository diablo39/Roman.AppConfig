using System;

namespace Roman.CQRS.Abstraction.Query
{
    public interface IListQueryParameters
    {
        int ItemsPerPage { get; set; }
        int Page { get; set; }
        string? SortBy { get; set; }
        bool? SortDesc { get; set; }
    }
}