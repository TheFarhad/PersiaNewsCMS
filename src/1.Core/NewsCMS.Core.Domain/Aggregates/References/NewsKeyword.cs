namespace NewsCMS.Core.Domain.Aggregates.References;

using Sky.App.Core.Domain.Aggregate.Entity;
using Sky.App.Core.Domain.Shared.ValueObjects;

public class NewsKeyword : Reference
{
    //public Guid KeywordCode { get; private set; }
    public Code KeywordCode { get; private set; }

    private NewsKeyword() { }
    private NewsKeyword(Guid code)
    {
        KeywordCode = code;
    }

    public static NewsKeyword Instance(Guid code) => new(code);
}
