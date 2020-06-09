using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *
             * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
               
               Find the sum of all the multiples of 3 or 5 below 1000.
             *  every => All
             *  any => Any
             *     => None
             *  filter => Where
             *  map => Select
             *  reduce => Aggregate
             */

            //Exercise1();

            Exercise2();
        }

        private static void Exercise2()
        {
            var node = new FibonacciNode {LastNumber = 1, SecondLastNumber = 1, SumOfEvensSoFar = 0};
            while (node.LastNumber <= 4000000)
            {
                node = NewNodeFromPreviousNode(node, 0);
            }

            Console.WriteLine(node.SumOfEvensSoFar);
            
            //var lastNode = Enumerable
            //    .Range(0, 20)
            //    .Aggregate(seed, NewNodeFromPreviousNode);
            //Console.WriteLine(lastNode.SumOfEvensSoFar);
            return;
         



            var sum = GetFibonacciNumbers(4000000).Where(n=>n%2==0).Sum();
            Console.WriteLine(sum);


            //var ints = new List<int>();
            //ints.Add(1);
            //ints.Add(1);
            //while (ints.Last() < 100)
            //{
            //    AddNextFibonacciNumber(ints);
            //    Console.WriteLine(ints.Last());
            //}


            //var lastNumber = 1;
            //var secondLastNumber = 1;
            //while (lastNumber <= 100)
            //{
            //    var nextNumber = lastNumber + secondLastNumber;
            //    secondLastNumber = lastNumber;
            //    lastNumber = nextNumber;
            //    Console.WriteLine(lastNumber);
            //}
        }

        private static FibonacciNode NewNodeFromPreviousNode(FibonacciNode node, int n)
        {
            return new FibonacciNode
            {
                SecondLastNumber = node.LastNumber,
                LastNumber = node.LastNumber + node.SecondLastNumber,
                SumOfEvensSoFar = node.SumOfEvensSoFar + (node.LastNumber%2==0? node.LastNumber:0)
            };
        }

        public static IEnumerable<int> GetFibonacciNumbers(int max)
        {
            yield return 1;
            yield return 1;
            var lastNumber = 1;
            var secondLastNumber = 1;
            while (lastNumber<=max)
            {
                var nextNumber = lastNumber + secondLastNumber;
                secondLastNumber = lastNumber;
                lastNumber = nextNumber;
                yield return nextNumber;
            }
        }

        public static void AddNextFibonacciNumber(List<int> list)
        {
            list.Add(list[list.Count - 1] + list[list.Count-2]);
        }

        private static void Exercise1()
        {
            /*
             *
             * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

               Find the sum of all the multiples of 3 or 5 below 1000.
             */

            // LINQ method syntax
            var numbers = Enumerable.Range(1, 999).Where(n => n % 3 == 0 || n % 5 == 0);

            // LINQ query syntax
            var numbers2 = from n in Enumerable.Range(1, 999)
                           where n % 3 == 0 || n % 5 == 0
                           select n;

            //var numberTexts = numbers.Select((n, i) => $"Det {i + 1}. tallet er {n}");
            //Console.WriteLine(string.Join("\n", numberTexts));
            //var sum = numbers.Sum();

            //Console.WriteLine(sum);
            //var sum = numbers
            var sum = numbers.Aggregate(0, (sumSoFar, n) => sumSoFar + n);
            var txt = numbers.Aggregate("", (txtSoFar, n) => $"{txtSoFar}\n Tallet er {n}");
            Console.WriteLine(txt);
            /*
             *  1  => sumSoFar=0, n=1 => 0+1=1
             *  2  => sumSoFar=1, n=2 => 1+2=3
             *  3  => sumSoFar=3, n=3 => 3+3=6
             *
             */


            //var sum = 0;
            //for (var n = 1; n < 1000; n++)
            //{
            //    if (n % 3 == 0 || n % 5 == 0)
            //    {
            //        sum += n;
            //    }
            //}
            //Console.WriteLine(sum);
        }


    }
}
