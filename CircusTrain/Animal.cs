using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrain
{
    public class Animal
    {
        public Diet Diet { get; set; }

        public Size Size { get; set; }

        public override string ToString()
        {
            return $"Animal - Diet: {Diet}, Size: {Size}";
        }
    }
}
