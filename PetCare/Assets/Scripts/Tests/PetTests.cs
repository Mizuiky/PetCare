using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using PetCare;
using NSubstitute;

public class PetTests
{
    [Test]
    public void DecreaseHungry_ShouldNotDecreaseWhenHungryIsBelowZero()
    {
        Pet pet = new Pet();

        pet.Data = new PetData()
        {
            hungry = 3,
            maxHungry = 10
        };

        pet.Amount = 5; 

        pet.DecreaseHungry();

        Assert.IsFalse(pet.Data.hungry < 0);
    }

    [Test]
    public void DecreaseHungry_ShouldDecreaseHungry()
    {
        Pet pet = new Pet();

        pet.Data = new PetData()
        {
            hungry = 8,
            maxHungry = 10
        };

        pet.Amount = 2;

        pet.DecreaseHungry();

        Assert.IsTrue(pet.Data.hungry == 6);
    }

    [Test]
    public void IncreaseHungry_ShouldNotIncreaseWhenHungryIsAboveMaxHungry()
    {
        Pet pet = new Pet();

        pet.Data = new PetData()
        {
            hungry = 8,
            maxHungry = 10
        };

        pet.IncreaseHungry(4);

        Assert.IsFalse(pet.Data.hungry > pet.Data.maxHungry);
    }

    [Test]
    public void IncreaseHungry_ShouldIncreaseHungry()
    {
        Pet pet = new Pet();

        pet.Data = new PetData()
        {
            hungry = 4,
            maxHungry = 10
        };

        pet.IncreaseHungry(6);

        Assert.IsTrue(pet.Data.hungry == 10);
    }
}


