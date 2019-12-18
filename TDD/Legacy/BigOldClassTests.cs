using System;
using System.Collections.Generic;
using LegacyExcercise;
using NSubstitute;
using Xunit;

namespace Legacy
{
    public class BigOldClassTests
    {
        private BigOldClass _sut;
        private ITravel _travel;

        public BigOldClassTests()
        {
            _sut = new BigOldClass();
            _travel = Substitute.For<ITravel>();
        }

        [Fact]
        public void When_total_expenses_are_less_than_5000_and_person_is_manager_should_accept_travel_expenses()
        {
            _travel.Person.IsManager.Returns(true);
            _travel.Expenses.Returns(new List<IExpense>
            {
                new Expense
                {
                    Value = 200
                }
            });

            var result = _sut.CanAcceptTravelExpenses(_travel);

            Assert.True(result);
        }

        [Fact]
        public void When_total_expenses_are_more_than_5000_and_person_is_manager_should_not_accept_travel_expenses()
        {
            _travel.Person.IsManager.Returns(true);
            _travel.Expenses.Returns(new List<IExpense>
            {
                new Expense
                {
                    Value = 5500
                }
            });

            var result = _sut.CanAcceptTravelExpenses(_travel);
    
            Assert.False(result);
        }

        [Fact]
        public void When_total_expenses_are_exacly_5000_and_person_is_manager_should_accept_travel_expenses()
        {
            _travel.Person.IsManager.Returns(true);
            _travel.Expenses.Returns(new List<IExpense>
            {
                new Expense
                {
                    Value = 5000
                }
            });

            var result = _sut.CanAcceptTravelExpenses(_travel);

            Assert.True(result);
        }

        [Fact]
        public void When_person_is_not_a_manager_and_works_less_than_365_days_should_not_acceppt_expenses()
        {
            _travel.Person.IsManager.Returns(false);
            _travel.Person.Hired.Returns(DateTime.Now.AddDays(-10));

            
            var result = _sut.CanAcceptTravelExpenses(_travel);

            Assert.False(result);
        }

        [Fact]
        public void When_person_is_not_manager_and_works_more_than_365_days_and_expenses_less_than_1000_should_accept()
        {
            _travel.Person.IsManager.Returns(false);
            _travel.Person.Hired.Returns(DateTime.Now.AddDays(-370));
            _travel.Expenses.Returns(new List<IExpense>
            {
                new Expense
                {
                    Value = 500
                }
            });


            var result = _sut.CanAcceptTravelExpenses(_travel);

            Assert.True(result);
        }

        [Fact]
        public void When_person_is_not_manager_and_works_more_than_365_days_and_expenses_equal_1000_should_accept()
        {
            _travel.Person.IsManager.Returns(false);
            _travel.Person.Hired.Returns(DateTime.Now.AddDays(-370));
            _travel.Expenses.Returns(new List<IExpense>
            {
                new Expense
                {
                    Value = 1000
                }
            });


            var result = _sut.CanAcceptTravelExpenses(_travel);

            Assert.True(result);
        }

        [Fact]
        public void When_person_is_not_manager_and_works_more_than_365_days_and_expenses_higher_then_1000_should_not_accept()
        {
            _travel.Person.IsManager.Returns(false);
            _travel.Person.Hired.Returns(DateTime.Now.AddDays(-370));
            _travel.Expenses.Returns(new List<IExpense>
            {
                new Expense
                {
                    Value = 5000
                }
            });


            var result = _sut.CanAcceptTravelExpenses(_travel);

            Assert.False(result);
        }

        [Fact]
        public void ___()
        {
            _travel.Person.IsManager.Returns(false);
            _travel.Person.Hired.Returns(DateTime.Now.AddDays(-370));
            _travel.Expenses.Returns(new List<IExpense>
            {
                new Expense
                {
                    Value = 100
                },
                new Expense
                {
                    Value = 5000,
                    Transport = true
                },
            });


            var result = _sut.CanAcceptTravelExpenses(_travel);

            Assert.True(result);
        }

        [Fact]
        public void ______()
        {
            _travel.Person.IsManager.Returns(false);
            _travel.Person.Hired.Returns(DateTime.Now.AddDays(-370));
            _travel.Expenses.Returns(new List<IExpense>
            {
                new Expense
                {
                    Value = 50000
                },
                new Expense
                {
                    Value = 100,
                    Transport = true
                },
            });


            var result = _sut.CanAcceptTravelExpenses(_travel);

            Assert.False(result);
        }

    }
}
