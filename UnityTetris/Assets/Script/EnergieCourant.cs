using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Script
{
    public class EnergieCourant : MonoBehaviour
    {

        public DestructionLigne destructionLigne;
        private TetroCourrant _tetroCourrant;
        public int maxEnergie = 4;
        public int energie;

        private int _energieCourant;
        public Energie barreEnergie;

        public void Initialiser()
        {
            energie = 0;
            barreEnergie.SetMaxEnergie(maxEnergie);
        }

       

        public void AjoutEnergie(int lignesDetruites)
        {
            //energie += destructionLigne.Ligne();

            _energieCourant += lignesDetruites;
            barreEnergie.SetEnergie(_energieCourant);

            
        }
        public void ResetEnergie()
        {
            energie -= 4;

            barreEnergie.SetEnergie(energie);
        }
    }
}

