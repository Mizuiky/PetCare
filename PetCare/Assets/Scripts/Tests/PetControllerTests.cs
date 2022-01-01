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
        IPet pet = Substitute.For<IPet>();

        pet.Status = new PetStatus()
        {
            hungry = 3
        };

        pet.Amount = 5; 

        pet.DecreaseHungry();

        Assert.IsFalse(pet.Status.hungry < 0);
    }
}


