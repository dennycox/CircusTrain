using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrain
{
    public static class SizeExtensions
    {
        public static int Points(this Size size)
        {
            switch (size)
            {
                case Size.Small:
                    return 1;
                case Size.Medium:
                    return 3;
                case Size.Large:
                    return 5;
                default:
                    return 0;
            }
        }
    }
}
