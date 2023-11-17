namespace PollingPublisher.Events;

using Sky.App.Core.Domain.Aggregate.Event;

public class KeywordCreatedEvent : IEvent
{
    public Guid Code { get; set; }
    public string Title { get; set; }
}