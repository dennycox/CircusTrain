using CircusTrain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CircusTrain.Tests
{
    [TestClass]
    public class WagonTest
    {
        [TestMethod]
        public void AddAnimal_AddLargeCarnivoreAndLargeHerbivore_False()
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Diet.Carnivore, Size.Large);

            // Act
            wagon.AddAnimal(animal);
            bool isAdded = wagon.AddAnimal(new Animal(Diet.Herbivore, Size.Large));

            // Assert
            Assert.IsFalse(isAdded);
        }

        [TestMethod]
        public void AddAnimal_Add2MediumCarnivoresAndLargeHerbivore_True()
        {
            // Arrange
            Wagon wagon = new Wagon();
            List<Animal> animals = new List<Animal>()
            {
                new Animal(Diet.Carnivore, Size.Medium),
                new Animal(Diet.Carnivore, Size.Medium),
            };

            // Act
            animals.ForEach(animal => wagon.AddAnimal(animal));
            bool isAdded = wagon.AddAnimal(new Animal(Diet.Herbivore, Size.Large));

            // Assert
            Assert.IsTrue(isAdded);
        }
    }
}