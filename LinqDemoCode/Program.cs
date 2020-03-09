using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemoCode
{

    class Program
    {
        static void Main(string[] args)
        {
            
            QueryStringArray();
            QueryIntArray();
            QueryArrayList();
            QueryCollection();
            Console.WriteLine();
            QueryAnimalData();
            Console.WriteLine();
            Console.WriteLine("press the [any] key");
            Console.ReadKey();
        }
        static void QueryStringArray()
        {
            string[] dogs =
            {
                 "K-9", "Brian Griffin", "Scooby Doo", "Old Yelloer", "Underdog",
            "Rin Tin Tin", "Benji", "Charlie B. Barkin", "Lassie", "Snoopy"};

            var dogSpaces = from dog in dogs
                            where dog.Contains(" ")
                            orderby dog descending
                            select dog;
            foreach (var d in dogSpaces)
            {
                
                Console.WriteLine(d);
                
            }
        }
        static int[] QueryIntArray()
        {
            int[] numbers = { 2, 4, 5, 6, 7, 8, 9, 10,20,25,30,124,255 };
            var gt20 = from num in numbers
                       where num > 20
                       orderby num
                       select num;
            foreach(var n in gt20)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine($"type is {gt20.GetType()}");
            var listgt20 = gt20.ToList<int>();
            var arraygt20 = gt20.ToArray();
            numbers[0] = 40;

            foreach (var n in gt20)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();
            return numbers;

        }
        static void QueryArrayList()
        {
            ArrayList famAnimals = new ArrayList()
            {
                new Animal{Name = "Heidi", Height = .8, Weight = 18},
                new Animal{Name = "Shrek", Height = 4, Weight = 130},
                new Animal{Name = "Congo", Height = 3.8, Weight = 90}
            };
            var famAnimalEnum = famAnimals.OfType<Animal>();
            var smAnimals = from Animal in famAnimalEnum
                            where Animal.Weight <= 90
                            orderby Animal.Name
                            select Animal;
            foreach(var x in smAnimals)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
                }
        static void QueryCollection()
        {
            var animalList = new List<Animal>()
            {
                new Animal{Name = "St Bernard", Height = 30, Weight = 200},
                new Animal{Name = "Chihuahua", Height = 7, Weight = 4.4},
                new Animal{Name = "German Shepherd", Height = 25, Weight = 75},
                new Animal{Name = "Bull Terrier", Height = 18, Weight = 45},
                new Animal{Name = "Mastif", Height = 31, Weight = 205},
            };
            var bigDogs = from dog in animalList
                          where dog.Weight > 70 && dog.Height > 25
                          orderby dog.Name
                          select dog;      //dog out of scope now
            foreach (var dog in bigDogs)   //new dog
            {
                Console.WriteLine(dog);
            }
        }
        static void QueryAnimalData()
        {
            Animal[] animals = new[]
            {
                new Animal{Name = "St Bernard", Height = 30, Weight = 200, AnimalId =1},
                new Animal{Name = "Chihuahua", Height = 7, Weight = 4.4, AnimalId=2},
                new Animal{Name = "German Shepherd", Height = 25, Weight = 75, AnimalId=3},
                new Animal{Name = "Bull Terrier", Height = 18, Weight = 45, AnimalId=4},
                new Animal{Name = "Mastif", Height = 31, Weight = 205, AnimalId=5},
                new Animal{Name = "Pug", Height = 12, Weight = 16, AnimalId=2},
                new Animal{Name = "Beagle", Height = 15, Weight = 23, AnimalId=7},
            };
            
            Owner[] owners = new[]
            {
                new Owner{Name="Doug Parks", OwnerId = 1},
                new Owner{Name="Sally Smith", OwnerId = 2},
                new Owner{Name="Paul Doe", OwnerId = 3},
            };
            var nameHeight = from a in animals
                             select new
                             {
                                 a.Name,
                                 a.Height
                             };
            Array arrNameHeight = nameHeight.ToArray();
            foreach (var i in arrNameHeight) Console.WriteLine(i);

            var innerJoin =
                from a in animals
                join o in owners on a.AnimalId
                equals o.OwnerId
                select new
                {
                    animalName = a.Name,
                    ownerName = o.Name
                };
            foreach (var i in innerJoin)
            {
                Console.WriteLine("{0} owns {1}", i.ownerName, i.animalName);
            }
            Console.WriteLine();

        }
    }
}
