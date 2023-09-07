namespace NewsCMS.Infra.Data.Sql.Query.DbSets;

using System;
using System.Collections.Generic;

public class News
{
    public long Id { get; set; }
    public Guid Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Body { get; set; }
    public List<Keyword> Keywords { get; set; } = new();
}

public class Keyword
{
    public long Id { get; set; }
    public Guid KCode { get; set; }
}
