using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AnimalShelter;
using AnimalShelter.Model;

namespace AnimalShelter.Tests
{

  [TestClass]
  public class TestDatabase
  {
    [TestMethod]
    public void Test_GetAllAnimals()
    {
      List<Animal> animals = Animal.GetAll();
      Animal newAnimal = new Animal("Aruba", "Nonmetropolitan Territory of The Netherlands");
      bool Found = false;
      foreach (Animal animal in animals)
      {
        if (animal.Equals(newAnimal))
        {
          Found = true;
        }
      }
      Assert.IsTrue(Found);
    }
  }
}
