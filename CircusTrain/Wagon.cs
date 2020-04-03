using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrain
{
    public class Wagon
    {
        public int MaxSize { get => 10; }

        private List<Animal> Animals { get; set; }

        public Wagon()
        {
            Animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            int size = GetPointsAmount();

            size += animal.Size.Points();

            if (size <= MaxSize)
            {
                Animals.Add(animal);
            }
            else
            {
                throw new Exception("Wagon max size limit exceeded!");
            }
        }

        private int GetPointsAmount()
        {
            int size = 0;

            foreach (var a in Animals)
            {
                size += a.Size.Points();
            }

            return size;
        }

        public override string ToString()
        {
            var s = "";

            s = s + $"Points: {GetPointsAmount()}" + "\n\r";

            foreach (var animal in Animals)
            {
                s = s + animal + "\n\r";
            }

            return s;
        }
    }
}
