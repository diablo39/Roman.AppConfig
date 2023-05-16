using Microsoft.EntityFrameworkCore;
using Roman.AppConfig.Domain.Model;
using Roman.AppConfig.Domain.UnitOfWork;

namespace Roman.AppConfig.Application.Queries
{
    public class ApplicationListQuery : ListQueryParameters, IQuery
    {
    }

    public class ApplicationListQueryValidator : AbstractValidator<ApplicationListQuery>
    {
        public ApplicationListQueryValidator()
        {
        }
    }

    public class ApplicationListQueryResult : CollectionQueryResultBase<ApplicationListQueryResultItem>
    {
        public ApplicationListQueryResult(IEnumerable<ApplicationListQueryResultItem> items, int count)
            : base(items, count)
        {
        }
    }

    public class ApplicationListQueryResultItem
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }

    public class ApplicationListQueryHandler : IQueryHandler<ApplicationListQuery, ApplicationListQueryResult>
    {
        private readonly IQueryDataModel _queryModel;

        public ApplicationListQueryHandler(IQueryDataModel queryModel)
        {
            _queryModel = queryModel;
        }

        public async Task<OperationResult<ApplicationListQueryResult>> ExecuteAsync(ApplicationListQuery query)
        {
            var dbQuery = _queryModel
              .Applications
              .Select(MappingDomainToQueryResult());

            var count = dbQuery.Count();
            var items = dbQuery.ToArray();

            var result = new ApplicationListQueryResult(items, count);

            await Task.CompletedTask; // hack to avoid warning

            return OperationResult.Success(result);
        }

        internal static Expression<Func<Domain.Model.ApplicationRegistration, ApplicationListQueryResultItem>> MappingDomainToQueryResult()
        {
            return e => new ApplicationListQueryResultItem
            {
                Name = e.Name,
                Description = e.Description,
            };
        }
    }
}