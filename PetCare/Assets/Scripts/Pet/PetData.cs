using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    [Serializable]
    public class PetData
    {
        public int hungry;
        public int happiness;

        public int maxHungry;
        public int maxHappiness;

        public int initialHungry;
        public int initialHappiness;
    }
}

