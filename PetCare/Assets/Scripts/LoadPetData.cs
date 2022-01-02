using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public static class LoadPetData
    {
        [SerializeField]
        public static PetData data;

        public static PetData loadData()
        {
            return data;
        }
    }
}

