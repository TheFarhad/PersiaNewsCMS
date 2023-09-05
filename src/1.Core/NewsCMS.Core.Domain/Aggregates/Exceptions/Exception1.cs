namespace NewsCMS.Core.Domain.Aggregates.Exceptions;

using Sky.App.Core.Domain.Aggregate.Exception;

public class Exception1 : InvalidEntityException
{

    public Exception1(string message, params string[] args) : base(message, args) { }
}
