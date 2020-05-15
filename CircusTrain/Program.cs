using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CircusTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            var train = new CircusTrain();

            // Het maken van de lijst met animals en deze sorteren zou kunnen worden verplaatst naar 
            // de CircusTrain class in een DistributeAnimals method
            // Momenteel is het echter goed genoeg van de leraar
            List<Animal> animals = GetRandomAnimals()
                .OrderBy(animal => animal.Diet).ThenByDescending(animal => animal.Size).ToList();
            animals.ForEach(animal => train.AddAnimal(animal));
            
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
            IReadOnlyList<Wagon> wagons = train.Wagons;

            foreach (Wagon wagon in wagons)
            {
                Console.WriteLine("--------------------");
                foreach (Animal animal in wagon.Animals)
                {
                    Console.WriteLine($"Diet: {animal.Diet}, Size: {animal.Size}");
                }
            }
        }
    }
}
