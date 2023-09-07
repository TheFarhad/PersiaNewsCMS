namespace NewsCMS.Core.Application.Query;

using Sky.App.Core.Service.Query;
using Sky.App.Core.Contract.Services.Query;
using Sky.App.Core.Contract.Services.Shared;
using Contract.Infra.Query;
using Contract.Services.Query;

public class NewsSearchByTitleQueryHandler : QueryHandler<NewsSearchByTitleQuery, NewsSearchByTitlePayload>
{
    private readonly INewsQueryRepository _repository;

    public NewsSearchByTitleQueryHandler(INewsQueryRepository repository) => _repository = repository;

    public override async Task<QueryResult<NewsSearchByTitlePayload>> HandleAsync(NewsSearchByTitleQuery source)
    {
        var payload = await _repository.ListAsync(source);
        if (payload.Items.Any()) Result = await OK(payload);
        else
        {
            Result.Status = ServiceStatus.NotFound;
            Result.SetError("...");
        }
        return Result;
    }
}
