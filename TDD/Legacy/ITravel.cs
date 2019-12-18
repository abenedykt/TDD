using System.Collections.Generic;

namespace LegacyExcercise
{
    public interface ITravel
    {
        IList<IExpense> Expenses { get; set; }
        IPerson Person { get; set; }
    }
}