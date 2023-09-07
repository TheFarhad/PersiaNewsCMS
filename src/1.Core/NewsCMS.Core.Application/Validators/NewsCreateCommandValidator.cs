namespace NewsCMS.Core.Application.Validators;

using FluentValidation;
using Contract.Services.Command;

public class NewsCreateCommandValidator : AbstractValidator<NewsCreateCommand>
{
    public NewsCreateCommandValidator()
    {

    }
}
