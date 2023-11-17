namespace PollingPublisher.Events;

using Sky.App.Core.Domain.Aggregate.Event;

public class KeywordTitleChangedEvent : IEvent
{
    public Guid Code { get; set; }
    public string Title { get; set; }
}