using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Script
{
    public class EnergieCourant : MonoBehaviour
    {

        //public DestructionLigne destructionLigne;
        private TetroCourrant _tetroCourrant;
        public int maxEnergie = 16;
        public int energie;

        //private int _energieCourant;
        public Energie barreEnergie;

        /// <summary>
        /// Initialise la barre d'énergie à 2 au lancement du jeu et son maximum à 16.
        /// </summary>
        public void Initialiser()
        {
            energie = 2;
            barreEnergie.SetMaxEnergie(maxEnergie);
        }

       

        /// <summary>
        /// Ajoute 1 énergie pour 1 ligne détruite, 2 pour 2 lignes, etc.
        /// </summary>
        /// <param name="lignesDetruites">Nombre de lignes détruites.</param>
        public void AjoutEnergie(int lignesDetruites)
        {
            //energie += destructionLigne.Ligne();
            Debug.Log("Nombre de lignes détruites:"+lignesDetruites);

            if (energie != maxEnergie) // N'ajoute pas plus d'énergie si la barre d'énergie est déjà au max
            {
                energie += lignesDetruites;
                barreEnergie.SetEnergie(energie);

            }

            
        }
        /// <summary>
        /// Enlève 4 d'énergie à la barre d'énergie.
        /// </summary>
        public void ResetEnergie()
        {
            energie -= 4;

            barreEnergie.SetEnergie(energie);
        }
    }
}

