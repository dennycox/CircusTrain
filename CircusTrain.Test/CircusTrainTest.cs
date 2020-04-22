using CircusTrain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CircusTrain.Tests
{
    [TestClass]
    public class CircusTrainTest
    {
        [TestMethod]
        public void AddAnimals_Add2Animals_True()
        {
            // Arrange
            var train = new CircusTrain();
            var animals = new List<Animal>()
            {
                new Animal(Diet.Carnivore, Size.Large),
                new Animal(Diet.Carnivore, Size.Large),
            };

            // Act
            train.AddAnimals(animals);

            // Assert
            Assert.AreEqual(2, train.GetWagons().Count);
        }

        [TestMethod]
        public void AddAnimals_Add3Animals_True()
        {
            // Arrange
            var train = new CircusTrain();
            var animals = new List<Animal>()
            {
                new Animal(Diet.Carnivore, Size.Large),
                new Animal(Diet.Herbivore, Size.Medium),
                new Animal(Diet.Carnivore, Size.Medium),
            };

            // Act
            train.AddAnimals(animals);
            IReadOnlyList<Animal> animalsInTrain = train.GetAnimals();

            // Assert
            Assert.IsTrue(animalsInTrain[0].Size == Size.Large & animalsInTrain[0].Diet == Diet.Carnivore);
            Assert.IsTrue(animalsInTrain[1].Size == Size.Medium & animalsInTrain[1].Diet == Diet.Carnivore);
            Assert.IsTrue(animalsInTrain[2].Size == Size.Medium & animalsInTrain[2].Diet == Diet.Herbivore);
        }
    }
}
