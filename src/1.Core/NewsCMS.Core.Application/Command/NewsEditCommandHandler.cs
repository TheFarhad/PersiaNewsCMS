namespace NewsCMS.Core.Application.Command;

using Sky.App.Core.Service.Command;
using Sky.App.Core.Contract.Services.Command;
using Contract.Infra.Command;
using Contract.Services.Command;
using Domain.Aggregates.References;

public class NewsEditCommandHandler : CommandHandler<NewsEditCommand, NewsEditPayload>
{
    private readonly INewsCommandRepository _repository;

    public NewsEditCommandHandler(INewsCommandRepository repository) => _repository = repository;

    public override async Task<CommandResult<NewsEditPayload>> HandleAsync(NewsEditCommand source)
    {
        var model = await _repository.GetAsync(source.Code);
        if (model is null) Result = await NotFound();
        else
        {
            model.Edit(source.Title, source.Description, source.Body, source.Keywords.Select(_ => NewsKeyword.Instance(_)).ToList());
            await _repository.SaveAsync();
            Result = await OK(new NewsEditPayload { Id = model.Id });
        }
        return Result;
    }
}
