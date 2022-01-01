using UnityEngine;

namespace PetCare
{
    public class Candy : MonoBehaviour, IActivate
    {
        private int id;

        private int amountToHeal;

        private Material[] sweetMaterial;

        private bool canBeSelected;

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int Amount
        {
            get
            {
                return this.amountToHeal;
            }
            set
            {
                this.amountToHeal = value;
            }
        }

        public void Activate()
        {
            this.gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            this.gameObject.SetActive(false);
        }

        public void InitializeCandy(int id, int amountToHeal, Material[] sweetMaterial)
        {
            this.ID = id;
            this.Amount = amountToHeal;

            this.sweetMaterial = sweetMaterial;

            this.Activate();

        }

        public void ChangeMaterial(bool enabled)
        {
            if (enabled)
            {
                this.GetComponentInChildren<Renderer>().sharedMaterial = sweetMaterial[0];
            }
            else
            {
                this.GetComponentInChildren<Renderer>().sharedMaterial = sweetMaterial[1];
            }
        }
    }
}

