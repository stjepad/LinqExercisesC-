using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLinqStudy
{
    class EntryPoint
    {
        private static IEnumerable<int> getTheNumbers;

        static void Main(string[] args)
        {
            string sentence = "I love cats";
            string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            int[] numbers = { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

            //----------------------------------------------
            SeparatingLine();

            var getTheNumbers = from number in numbers
                                where number < 5
                                orderby number descending
                                select number;

            Console.WriteLine(string.Join(", ", getTheNumbers));

            //List<int> newNumbers = new List<int>();
            //foreach (var number in numbers)
            //{
            //    if (number < 5)
            //    {
            //        newNumbers.Add(number);
            //    }
            //}
            //Console.WriteLine(string.Join(", ", newNumbers));
            SeparatingLine();

           var  simpleLinq = from s in sentence
                         select s;
            Console.WriteLine(string.Join("!", simpleLinq));
            SeparatingLine();

            var catsWithA = from cat in catNames
                            where cat.Contains("a") && cat.Length < 5
                            select cat;
            Console.WriteLine(string.Join(", ", catsWithA));


            Console.WriteLine("blOOp!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
            private static void SeparatingLine()
            {
                Console.WriteLine(new string('-', 40));
            }
    }
}