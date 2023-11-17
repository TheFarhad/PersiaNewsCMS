namespace NewsCMS.Infra.Data.Sql.Query.Repositories;

using Microsoft.EntityFrameworkCore;
using Sky.Kernel.Extentions;
using Sky.App.Infra.Data.Sql.Query;
using Contexts;
using Core.Contract.Infra.Query;
using Core.Contract.Services.Query;

public class NewsQueryRepository : QueryRepository<NewsCMSQueryDbContext>, INewsQueryRepository
{
    public NewsQueryRepository(NewsCMSQueryDbContext context) : base(context) { }

    public async Task<NewsSearchByTitlePayload> ListAsync(NewsSearchByTitleQuery source)
    {
        var result = new NewsSearchByTitlePayload();

        var query = Context.News.AsNoTracking();
        if (source.NeededTotalCount) result.Total = await query.CountAsync();

        if (source.Title.IsNotEmpty())
            query = query.
                Where(_ => _.Title.Contains(source.Title));

        result.Items = await query
            .Skip(source.Skip)
            .Take(source.Size)
            .OrderBy(source.SortBy, source.SortAscending)
            //.Include(_ => _.NewsKeywords)
            //.ThenInclude(_ => _.Keyword)
            .Select(_ => new NewsSearchItem
            {
                Id = _.Id,
                Code = _.Code,
                Title = _.Title,
                Description = _.Description,
                Body = _.Body,
                Keywords = _.NewsKeywords
                    .Select(_ => _.Keyword)
                    .Select(_ => new NewsKeywordInfo
                    {
                        Code = _.Code,
                        Title = _.Title
                    }).ToList()
            })
            .ToListAsync();

        return result;
    }
}
