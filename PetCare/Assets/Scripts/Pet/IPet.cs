using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public interface IPet
    {
        public float RotationAmount { get; }
        public PetStatus Status { get; }
        public int Amount { get; }

        public int InitialHungry { get; }

        public int MaxHungry { get; }

        public int InitialHappiness { get; }

        public int MaxHappiness { get; }

        void SetInitialStatus();

        void DecreaseStatus();
        void DecreaseHungry();
        void DecreaseHappiness();

        bool CheckCanConsumeItem();

        void IncreaseHappiness(int amount);
        void IncreaseHungry(int amount);

        void Rotate(bool rightSide);
    }
}

