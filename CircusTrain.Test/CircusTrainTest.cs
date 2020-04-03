using CircusTrain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CircusTrain.Tests
{
    [TestClass]
    public class CircusTrainTest
    {
        [TestMethod]
        public void AddAnimals_Add3Animals_3AnimalsAdded()
        {
            // 1. Arrange
            var train = new CircusTrain();
            var animals = new List<Animal>()
            {
                new Animal{ Diet=Diet.Carnivore, Size=Size.Large },
                new Animal{ Diet=Diet.Carnivore, Size=Size.Large },
                new Animal{ Diet=Diet.Carnivore, Size=Size.Large },
            };

            // 2. Act
            train.AddAnimals(animals);

            // 3. Assert
            Assert.AreEqual(3, train.WagonAmount);
        }
    }
}
