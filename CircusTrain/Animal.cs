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
    }
}
