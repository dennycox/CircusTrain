using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrain.Tests
{
    [TestClass]
    public class AnimalTest
    {
        [TestMethod]
        public void CanFitTogether_AddLargeCarnivoreAndLargeHerbivore_False()
        {
            // Arrange
            Animal animal = new Animal(Diet.Carnivore, Size.Large);

            // Act
            animal.CanFitTogether(animal);
            bool canFit = animal.CanFitTogether(new Animal(Diet.Herbivore, Size.Large));

            // Assert
            Assert.IsFalse(canFit);
        }

        [TestMethod]
        public void CanFitTogether_AddMediumCarnivoreAndLargeHerbivore_True()
        {
            // Arrange
            Animal animal = new Animal(Diet.Carnivore, Size.Medium);

            // Act
            animal.CanFitTogether(animal);
            bool canFit = animal.CanFitTogether(new Animal(Diet.Herbivore, Size.Large));

            // Assert
            Assert.IsTrue(canFit);
        }
    }
}
