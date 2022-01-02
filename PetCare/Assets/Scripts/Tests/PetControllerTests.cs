using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using PetCare;
using NSubstitute;

public class PetControllerTests
{
    [Test]
    public void DecreaseHungry_ShouldNotDecreaseHungryWhenItHasLessValueThanZero()
    {
        Pet pet = new Pet();

        pet.Data.Returns(
            new PetData() 
            { 
                hungry = 3,
                maxHungry = 10
            }
        );

        pet.Amount = 5; 

        pet.DecreaseHungry();

        Assert.IsFalse(pet.Data.hungry < 0);
    }
}


