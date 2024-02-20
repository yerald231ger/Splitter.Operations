using System.Linq.Expressions;

namespace Splitter.Operations.Models;

public class FilterRange<T>
{
    public Guid? Id { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }


    public FilterRange(Guid? id, DateTime? from, DateTime? to)
    {
        Id = id;
        From = from;
        To = to;
    }
}
