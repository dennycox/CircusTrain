using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrain
{
    public class CircusTrain
    {
        private List<Wagon> _wagons;
        public IReadOnlyList<Wagon> Wagons { get => _wagons; }
        public IReadOnlyList<Animal> Animals
        {
            get
            {
                List<Animal> animals = new List<Animal>();

                foreach (Wagon wagon in _wagons)
                {
                    foreach (Animal animal in wagon.Animals)
                    {
                        animals.Add(animal);
                    }
                }
                return animals;
            }
        }

        public CircusTrain()
        {
            _wagons = new List<Wagon>();
        }

        public void AddAnimal(Animal animal)
        {
            foreach (Wagon wagon in _wagons)
            {
                if (wagon.AddAnimal(animal))
                {
                    return;
                }
            }
            Wagon newWagon = new Wagon();
            newWagon.AddAnimal(animal);
            AddWagons(newWagon);
        }

        public void AddWagons(Wagon wagon)
        {
            _wagons.Add(wagon);
        }
    }
}
