namespace NewsCMS.Core.Contract.Infra.Query;

using NewsCMS.Core.Contract.Services.Query;
using Sky.App.Core.Contract.Infra.Query;

public interface INewsQueryRepository : IQueryRepository
{
    Task<NewsSearchByTitlePayload> ListAsync(NewsSearchByTitleQuery source);
}
