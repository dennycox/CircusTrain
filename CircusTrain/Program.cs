using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CircusTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            var train = new CircusTrain();

            List<Animal> animals = GetRandomAnimals();
            train.AddAnimals(animals);
            PrintToConsole(train);
        }

        private static List<Animal> GetRandomAnimals()
        {
            var animals = new List<Animal>();
            var random = new Random();

            for (int i = 0; i < 20; i++)
            {
                var diets = Enum.GetValues(typeof(Diet));
                var diet = (Diet)diets.GetValue(random.Next(diets.Length));

                var sizes = Enum.GetValues(typeof(Size));
                var size = (Size)sizes.GetValue(random.Next(sizes.Length));

                animals.Add(new Animal(diet, size));
            }

            return animals;
        }

        public static void PrintToConsole(CircusTrain train)
        {
            IReadOnlyList<Wagon> wagons = train.GetWagons();

            foreach(Wagon wagon in wagons)
            {
                Console.WriteLine("--------------------");
                foreach(Animal animal in wagon.GetAnimals())
                {
                    Console.WriteLine($"Diet: {animal.Diet}, Size: {animal.Size}");
                }
            }
        }
    }
}
