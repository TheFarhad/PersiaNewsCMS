namespace NewsCMS.Core.Application.Command;

using Sky.App.Core.Service.Command;
using Sky.App.Core.Contract.Services.Command;
using Contract.Infra.Command;
using Domain.Aggregates.Source;
using Contract.Services.Command;
using Domain.Aggregates.References;

public class NewsCreateCommandHandler : CommandHandler<NewsCreateCommand, NewsCreatePayload>
{
    private readonly INewsCommandRepository _repository;

    public NewsCreateCommandHandler(INewsCommandRepository repository) => _repository = repository;

    public override async Task<CommandResult<NewsCreatePayload>> HandleAsync(NewsCreateCommand Source)
    {
        var model = News.Instance(Source.Title, Source.Description, Source.Body, Source.Keywords.Select(_ => NewsKeyword.Instance(_)).ToList());
        await _repository.AddAsync(model);
        await _repository.SaveAsync();
        return await OK(new NewsCreatePayload { Id = model.Id });
    }
}