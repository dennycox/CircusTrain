using CircusTrain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CircusTrain.Tests
{
    [TestClass]
    public class CircusTrainTest
    {
        [TestMethod]
        public void AddAnimals_Add2Animals_True()
        {
            // Arrange
            CircusTrain train = new CircusTrain();
            List<Animal> animals = new List<Animal>()
            {
                new Animal(Diet.Carnivore, Size.Large),
                new Animal(Diet.Carnivore, Size.Large),
            };

            // Act
            animals = animals.OrderBy(animal => animal.Diet).ThenByDescending(animal => animal.Size).ToList();
            animals.ForEach(animal => train.AddAnimal(animal));

            // Assert
            Assert.AreEqual(2, train.Wagons.Count);
        }

        [TestMethod]
        public void AddAnimals_Add3Animals_True()
        {
            // Arrange
            CircusTrain train = new CircusTrain();
            List<Animal> animals = new List<Animal>()
            {
                new Animal(Diet.Carnivore, Size.Large),
                new Animal(Diet.Herbivore, Size.Medium),
                new Animal(Diet.Carnivore, Size.Medium),
            };

            // Act
            animals = animals.OrderBy(animal => animal.Diet).ThenByDescending(animal => animal.Size).ToList();
            animals.ForEach(animal => train.AddAnimal(animal));
            IReadOnlyList<Animal> animalsInTrain = train.Animals;

            // Assert
            Assert.IsTrue(animalsInTrain[0].Size == Size.Large & animalsInTrain[0].Diet == Diet.Carnivore);
            Assert.IsTrue(animalsInTrain[1].Size == Size.Medium & animalsInTrain[1].Diet == Diet.Carnivore);
            Assert.IsTrue(animalsInTrain[2].Size == Size.Medium & animalsInTrain[2].Diet == Diet.Herbivore);
        }
    }
}
