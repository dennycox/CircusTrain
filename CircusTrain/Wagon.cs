﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CircusTrain
{
    public class Wagon
    {
        private List<Animal> _animals;
        public int MaxSize { get => 10; }
        public int AnimalSizePoints { get => _animals.Sum(animal => (int)animal.Size); }
        public IReadOnlyList<Animal> Animals { get => _animals; }

        public Wagon()
        {
            _animals = new List<Animal>();
        }

        // In onderstaande methode zouden de if statements verdeeld kunnen worden in private 
        // methods om de code begrijpbaarder te maken
        // Momenteel is het echter goed genoeg van de leraar
        public bool TryAddAnimal(Animal animal)
        {
            if (AnimalSizePoints + (int)animal.Size <= MaxSize)
            {
                bool canAdd = true;
                foreach (Animal a in _animals)
                {
                    if(!a.CanFitTogether(animal))
                    {
                        canAdd = false;
                    }
                }
                if(canAdd)
                {
                    _animals.Add(animal);
                    return true;
                }
            }
            return false;
        }
    }
}
