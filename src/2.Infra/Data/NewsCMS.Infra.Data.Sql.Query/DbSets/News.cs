namespace NewsCMS.Infra.Data.Sql.Query.DbSets;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class News
{
    public long Id { get; set; }
    public Guid Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Body { get; set; }
    public List<NewsKeyword> NewsKeywords { get; set; } = new();
}

public class NewsKeyword
{
    public long Id { get; set; }

    [ForeignKey("News")]
    public long NewsId { get; set; }
    public News News { get; set; }

    [ForeignKey("Keyword")]
    public Guid KeywordCode { get; set; }
    public Keyword Keyword { get; set; }
}
