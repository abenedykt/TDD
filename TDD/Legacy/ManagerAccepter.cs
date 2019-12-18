using System.Collections.Generic;

namespace LegacyExcercise
{
    internal class ManagerAccepter : IAcceptExpenses
    {
        public bool Approve(IList<IExpense> expenses)
        {
            var total = 0.0;

            foreach (var expense in expenses)
            {
                total += expense.Value;
            }

            return total <= 5000;
        }
    }
}
