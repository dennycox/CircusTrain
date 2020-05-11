using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrain
{
    public class Animal
    {
        public Diet Diet { get; }
        public Size Size { get; }

        public Animal(Diet diet, Size size)
        {
            this.Diet = diet;
            this.Size = size;
        }

        public bool CanFitTogether(Animal animal)
        {
            if (animal.Diet == Diet.Carnivore && animal.Size >= Size || Diet == Diet.Carnivore && animal.Size <= Size)
            {
                return false;
            }
            return true;
        }
    }
}
