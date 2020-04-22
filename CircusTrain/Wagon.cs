using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrain
{
    public class Wagon
    {
        public int MaxSize { get => 10; }

        private List<Animal> _animals;

        public Wagon()
        {
            _animals = new List<Animal>();
        }

        public IReadOnlyList<Animal> GetAnimals()
        {
            return _animals;
        }

        public bool AddAnimal(Animal animal)
        {
            if (DoesAnimalFit(animal) && DoesAnimalSurvive(animal))
            {
                _animals.Add(animal);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DoesAnimalFit(Animal animal)
        {
            int size = GetPoints();

            size += (int)animal.Size;

            if (size <= MaxSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DoesAnimalSurvive(Animal animal)
        {
            Animal carnivore = null;
            for (Size s = Size.Large; s >= Size.Small; s--)
            {
                foreach (var a in _animals)
                {
                    if (a.Size == s && a.Diet == Diet.Carnivore)
                    {
                        carnivore = a;
                    }
                }
            }
            if (carnivore != null)
            {
                if (carnivore.Size >= animal.Size)
                {
                    return false;
                }
            }
            return true;
        }

        private int GetPoints()
        {
            int size = 0;

            foreach (var a in _animals)
            {
                size += (int)a.Size;
            }

            return size;
        }
    }
}
