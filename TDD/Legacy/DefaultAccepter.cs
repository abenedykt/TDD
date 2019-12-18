using System.Collections.Generic;

namespace LegacyExcercise
{
    internal class DefaultAccepter : IAcceptExpenses
    {
        public bool Approve(IList<IExpense> expenses)
        {
            return false;
        }
    }
}
