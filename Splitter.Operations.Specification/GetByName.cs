using Ardalis.Specification;

namespace Splitter.Operations.Specification;

public class GetByNameSpecification<TEntity>(string name, Func<TEntity, string> propertySelector) : Specification<TEntity>
{
    private readonly string _name = name;
    private readonly Func<TEntity, string> _propertySelector = propertySelector;

    public override bool IsSatisfiedBy(TEntity entity)
    {
        return _propertySelector(entity).Contains(_name);
    }
}
