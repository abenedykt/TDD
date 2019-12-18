using System.Collections.Generic;

namespace LegacyExcercise
{
    internal class RegularEmployeeAccepter : IAcceptExpenses
    {
        public bool Approve(IList<IExpense> expenses)
        {
            var total = 0.0;
            foreach (var expense in expenses)
            {
                if (!expense.Transport)
                {
                    total += expense.Value;
                }
            }

            return total <= 1000;
        }
    }
}
