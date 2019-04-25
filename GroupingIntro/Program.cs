using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupingIntro
{
    class Program
    {
        static void Main()
        {

            List<Person> people = new List<Person>()
            {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 21, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 19, Gender.Female),
                new Person("John", "Jones", 7, 160, 22, Gender.Female),
                new Person("Samba", "TheLion", 8, 175, 23, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 21, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie", "Lewis", 11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 23, Gender.Female)
            };

            //-----------------------------------------------

            var genderGroup = from p in people
                              group p by p.Gender;

            foreach (var person in genderGroup)
            {
               // Console.WriteLine($"{person.Key}");
                foreach (var p in person)
                {
                    Console.WriteLine($"{p.FirstName} is a {p.Gender}.");
                }
            }

            SeparatingLine();
            //------------------------------------------------
            var groupWithConditions = from p in people
                                      where p.Age > 20
                                      group p by p.Age;
            foreach (var key in groupWithConditions)
            {
                Console.WriteLine($"{key.Key}");

                foreach (var item in key)
                {
                    Console.WriteLine($"  {item.Age} {item.FirstName}");
                }
            }

            SeparatingLine();

            var groupByAlphabet = from p in people
                                  group p by p.FirstName[0];
            foreach (var key in groupByAlphabet)
            {
                Console.WriteLine($"{key.Key}");
                foreach (var item in key)
                {
                    Console.WriteLine($"  {item.FirstName}");
                }
            }

            SeparatingLine();

            var multipleKeys = from p in people
                               group p by new { p.Gender, p.Age };
            foreach (var key in multipleKeys)
            {
                Console.WriteLine($"{key.Key}");
                foreach (var item in key)
                {
                    Console.WriteLine($"{item.FirstName}  {item.LastName}");
                }
            }

            SeparatingLine();

            var orderedKeys = from p in multipleKeys
                              orderby p.Count()
                              select p;
            foreach (var key in orderedKeys)
            {
                Console.WriteLine($"Gender : {key.Key.Gender}, Age : {key.Key.Age}");
                foreach (var item in key)
                {
                    Console.WriteLine($"{item.FirstName}  {item.LastName}");
                }
            }

            SeparatingLine();
            // into
            var peopleByAge = from p in people
                              group p by p.Age into ageGroup
                              orderby ageGroup.Key
                              select ageGroup;

            foreach (var key in peopleByAge)
            {
                Console.WriteLine($"Age: {key.Key}");

                foreach (var item in key)
                {
                    Console.WriteLine($" {item.Age}");
                }
            }

            SeparatingLine();

            //---------------------------------------------
            int[] arrayOfNumbers = { 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

            var evenOrOddNumbers = from n in arrayOfNumbers
                                   orderby n
                                   let evenOrOdd = (n % 2 == 0) ? "even" : "odd"
                                   group n by evenOrOdd into nums
                                   orderby nums.Count()
                                   select nums;

            foreach (var key in evenOrOddNumbers)
            {
                Console.WriteLine($"{key.Key}");

                foreach (var item in key)
                {
                    Console.WriteLine($"  {item}");
                }
            }

            SeparatingLine();

            //---------------------------------------------

            var peopleWithMultipleGrouping = from p in people
                                             let ageSelection = 
                                             p.Age < 20 
                                                ? "Young" 
                                                : p.Age >= 20 && p.Age <= 22 
                                                ? "Adult" 
                                                : "Senior"
                                             group p by ageSelection;
            foreach (var key in peopleWithMultipleGrouping)
            {
                Console.WriteLine($"{key.Key}");
                foreach (var item in key)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
                }
            }

            SeparatingLine();

            //---------------------------------------------

            var howManyOfEachGroup = from p in people
                                     group p by p.Gender into g
                                     select new { Gender = g.Key, NumOfPeople = g.Count() };
            foreach (var item in howManyOfEachGroup)
            {
                Console.WriteLine($"{item.Gender}");
                Console.WriteLine($"  {item.NumOfPeople}");
            }



                 Console.WriteLine("blOOp!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 40));
        }
    }

    internal class Person
    {
        private string firstName;
        private string lastName;
        private int id;
        private int height;
        private int age;

        private Gender gender;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        public Person(string firstName, string lastName, int id, int height, int age, Gender gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.Height = height;
            this.Age = age;
            this.Gender = gender;
        }
    }

    internal enum Gender
    {
        Male,
        Female
    }
}