using System;
using System.Linq;

namespace Anatomia
{
    class Program
    {
        static void Main()
        {
            Sum_should_return_the_sum_of_arguments();

            //System.Reflection.Assembly.GetCallingAssembly()
            //    .GetTypes()
            //    .Where(t=>t.IsPublic == true)
            //    .SelectMany(t=>t.GetMethods())
            //    .Where(m=>m.IsPublic == true)
        }

        private static void Assembly()
        {
            throw new NotImplementedException();
        }

        private static void Sum_should_return_the_sum_of_arguments()
        {

            // arrange 
            var a = double.MaxValue;
            var b = 2;


            // act
            var result = Sum(a, b);


            // assert
            if (result == 3)
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }

        public static double Sum(double a, double b)
        {
            return a + b;
        }
    }
}
