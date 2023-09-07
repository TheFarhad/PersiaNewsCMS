namespace NewsCMS.Core.Domain.Aggregates.References;

using Sky.App.Core.Domain.Aggregate.Entity;

public class Keyword : Entity
{
    public Guid KCode { get; private set; }

    private Keyword() { }
    private Keyword(Guid code)
    {
        KCode = code;
    }

    public static Keyword Instance(Guid code) => new(code);
}
