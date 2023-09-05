namespace NewsCMS.Core.Domain.Aggregates.Elements;

using Sky.App.Core.Domain.Aggregate.ValueObject;

public class ValueObject1 : Element<ValueObject1>
{
    protected override IEnumerable<object> AttributesToEquality()
    {
        throw new NotImplementedException();
    }
}
