namespace NewsCMS.Core.Contract.Services.Query;

using Sky.App.Core.Contract.Services.Query;

public class NewsSearchByTitleQuery : PageQuery<NewsSearchByTitlePayload>
{
    public string Title { get; set; }
}

public class NewsSearchByTitlePayload : QueryPayload<NewsSearchItem> { }

public class NewsSearchItem
{
    public long Id { get; set; }
    public Guid Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Body { get; set; }
    public List<NewsKeywordInfo> Keywords { get; set; } = new();
}

public class NewsKeywordInfo
{
    public Guid Code { get; set; }
    public string Title { get; set; }
}
