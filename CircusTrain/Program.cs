using System;
using System.Collections.Generic;

namespace CircusTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            var train = new CircusTrain();

            List<Animal> animals = GetRandomAnimals();
            train.AddAnimals(animals);

            Console.WriteLine(train);
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

                animals.Add(new Animal { Size = size, Diet = diet });
            }

            return animals;
        }
    }
}
