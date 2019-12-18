using System;
using System.Collections.Generic;

namespace LegacyExcercise
{
    public class BigOldClass
    {
        public bool CanAcceptTravelExpenses(ITravel travel)
        {
            var accepter = FactoryMethod(travel.Person);
            return accepter.Approve(travel.Expenses);
        }

        private IAcceptExpenses FactoryMethod(IPerson person)
        {
            if (person.IsManager)
            {
                return new ManagerAccepter();
            }

            if (DateTime.Now.Subtract(person.Hired).TotalDays >= 365)
            {
                return new RegularEmployeeAccepter();
            }

            return new DefaultAccepter();
        }
    }

    internal interface IAcceptExpenses
    {
        bool Approve(IList<IExpense> expenses);
    }
}
