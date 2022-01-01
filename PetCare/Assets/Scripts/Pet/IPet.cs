using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public interface IPet
    {
        public int Amount { get; set; }

        public PetData Status { get; set; }

        void SetInitialStatus(PetData status);

        void UpdateStatus(PetData status);

        void DecreaseHungry();

        void DecreaseHappiness();

        void IncreaseHappiness(int amount);
    }
}

