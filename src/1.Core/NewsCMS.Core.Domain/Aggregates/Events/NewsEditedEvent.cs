namespace NewsCMS.Core.Domain.Aggregates.Events;

using NewsCMS.Core.Domain.Aggregates.References;
using Sky.App.Core.Domain.Aggregate.Event;

public class NewsEditedEvent : IEvent
{
    public Guid Code { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Body { get; private set; }
    public string Keywords { get; private set; }

    private NewsEditedEvent(Guid code, string title, string description, string body, List<NewsKeyword> keywords)
    {
        Code = code;
        Title = title;
        Description = description;
        Body = body;
        Keywords = String.Join(";", keywords.Select(_ => _.KeywordCode.ToString()));
    }

    public static NewsEditedEvent Instance(Guid code, string title, string description, string body, List<NewsKeyword> keywords) =>
        new(code, title, description, body, keywords);
}
