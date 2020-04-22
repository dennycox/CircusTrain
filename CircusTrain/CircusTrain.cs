using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrain
{
    public class CircusTrain
    {
        private List<Wagon> _wagons;

        public CircusTrain()
        {
            _wagons = new List<Wagon>();
        }

        public IReadOnlyList<Wagon> GetWagons()
        {
            return _wagons;
        }

        public void AddAnimals(List<Animal> animals)
        {
            while (animals.Count > 0)
            {
                var wagon = new Wagon();

                AddCarnivore(animals, wagon);
                AddHerbivore(animals, wagon);

                _wagons.Add(wagon);
            }
        }

        private void AddCarnivore(List<Animal> animals, Wagon wagon)
        {
            var carnivore = GetLargestCarnivore(animals);

            if (carnivore != null)
            {
                if (wagon.AddAnimal(carnivore))
                {
                    animals.Remove(carnivore);
                }
            }
        }

        private void AddHerbivore(List<Animal> animals, Wagon wagon)
        {
            for (Size s = Size.Large; s >= Size.Small; s--)
            {
                while (true)
                {
                    var herbivore = GetHerbivore(animals, s);

                    if (herbivore != null)
                    {
                        if (wagon.AddAnimal(herbivore))
                        {
                            animals.Remove(herbivore);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private Animal GetLargestCarnivore(List<Animal> animals)
        {
            for (Size s = Size.Large; s >= Size.Small; s--)
            {
                foreach (var a in animals)
                {
                    if (a.Size == s && a.Diet == Diet.Carnivore)
                    {
                        return a;
                    }
                }
            }

            return null;
        }

        private Animal GetHerbivore(List<Animal> animals, Size size)
        {
            foreach (var a in animals)
            {
                if (a.Size == size && a.Diet == Diet.Herbivore)
                {
                    return a;
                }
            }

            return null;
        }

        public IReadOnlyList<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>();

            foreach (Wagon wagon in _wagons)
            {
                foreach (Animal animal in wagon.GetAnimals())
                {
                    animals.Add(animal);
                }
            }

            return animals;
        }
    }
}
