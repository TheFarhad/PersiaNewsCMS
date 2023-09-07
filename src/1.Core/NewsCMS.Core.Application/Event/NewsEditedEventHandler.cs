namespace NewsCMS.Core.Application.Event;

using Sky.App.Core.Contract.Services.Event;
using Domain.Aggregates.Events;

public class NewsEditedEventHandler : IEventHandler<NewsEditedEvent>
{
    public Task HandleAsync(NewsEditedEvent Source)
    {

        return Task.CompletedTask;
    }
}
