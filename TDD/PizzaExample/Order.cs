using System.Collections.Generic;
using System.Linq;

namespace PizzaExample
{
    public class Order
    {
        private readonly IList<OrderPosition> _positions = new List<OrderPosition>();
        public IEnumerable<OrderPosition> Positions => _positions;

        public void Add(OrderPosition position)
        {
            _positions.Add(position);
        }

        public bool IsValid()
        {
            return AllPiecesAreDivisibleBy8() && SumOfEachKindIsDivisibleBy4();
        }
       
        private bool SumOfEachKindIsDivisibleBy4()
        {
            return _positions
                            .GroupBy(x => x.PizzaName)
                            .Select(PizzaGroups)
                            .All(kind => kind.TotalPieces % 4 == 0);
        }

        private PizzaGroup PizzaGroups(IGrouping<string, OrderPosition> group)
        {
            return new PizzaGroup
            {
                PizzaName = group.Key,
                TotalPieces = group.Sum(x => x.Pieces)
            };
        }

        private bool AllPiecesAreDivisibleBy8()
        {
            return _positions.Sum(p => p.Pieces) % 8 == 0;
        }

        private class PizzaGroup
        {
            public string PizzaName { get; set; }
            public int TotalPieces { get; set; }
        }
    }
}
