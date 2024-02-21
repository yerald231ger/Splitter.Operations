using Ardalis.Specification;

namespace Splitter.Operations.Specification;

public class GetByRangeDateEspecification<TEntity>(DateTime? from, DateTime? to, Func<TEntity, DateTime> dateSelector) : Specification<TEntity>
{
    private readonly DateTime? _from = from;
    private readonly DateTime? _to = to;
    private readonly Func<TEntity, DateTime> _dateSelector = dateSelector;
    public override bool IsSatisfiedBy(TEntity entity)
    {

        if (_from.HasValue && _to.HasValue)
        {
            return _dateSelector(entity) >= _from.Value && _dateSelector(entity) <= _to.Value;
        }
        else if (_from.HasValue && !_to.HasValue)
        {
            return _dateSelector(entity) >= _from.Value;
        }
        else if (_to.HasValue && !_from.HasValue)
        {
            return _dateSelector(entity) <= _to.Value;
        }
        return true;
    }
}
