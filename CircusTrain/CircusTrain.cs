using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrain
{
    public class CircusTrain
    {
        private List<Wagon> wagons;

        public int WagonAmount { get => wagons.Count; }

        public CircusTrain()
        {
            wagons = new List<Wagon>();
        }

        public void AddAnimals(List<Animal> animals)
        {
            while (animals.Count > 0)
            {
                var wagon = new Wagon();

                Size sizeCarnivore = Size.Large;
                while (sizeCarnivore >= Size.Small)
                {
                    var carnivore = animals.Find(a => a.Size.Equals(sizeCarnivore) && a.Diet.Equals(Diet.Carnivore));

                    if (carnivore == null)
                    {
                        sizeCarnivore--;

                        continue;
                    }

                    wagon.AddAnimal(carnivore);
                    animals.Remove(carnivore);

                    break;
                }

                for (Size sizeHerbivore = Size.Large; sizeHerbivore > sizeCarnivore; sizeHerbivore--)
                {
                    while (true)
                    {
                        var herbivore = animals.Find(a => a.Size.Equals(sizeHerbivore) && a.Diet.Equals(Diet.Herbivore));

                        if (herbivore == null)
                        {
                            break;
                        }

                        try
                        {
                            wagon.AddAnimal(herbivore);
                            animals.Remove(herbivore);
                        }
                        catch (Exception)
                        {
                            break;
                        }

                    }
                }

                wagons.Add(wagon);
            }
        }

        public override string ToString()
        {
            var s = "";

            s = s + $"Wagon amount: {WagonAmount}" + "\n\r";

            foreach (var wagon in wagons)
            {
                s = s + wagon + "\n\r";
            }

            return s;
        }
    }
}
