using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Script
{
    public class EnergieCourant : MonoBehaviour
    {

        //public DestructionLigne destructionLigne;
        public GameObject tetroCourant;
        private TetroCourrant _tetroCourrant;
        
        public float maxEnergie = 16f;
        public float energie;

        //private int _energieCourant;
        public Energie barreEnergie;

        /// <summary>
        /// Initialise la barre d'énergie à 0 au lancement du jeu et son maximum à 16.
        /// </summary>
        public void Initialiser(float energie)
        {
            this.energie = energie;
            barreEnergie.SetMaxEnergie(maxEnergie);
        }

       

        /// <summary>
        /// Ajoute 1 énergie pour 1 ligne détruite, 2 pour 2 lignes, etc.
        /// </summary>
        /// <param name="lignesDetruites">Nombre de lignes détruites.</param>
        public void AjoutEnergie(int lignesDetruites)
        {
            _tetroCourrant = tetroCourant.GetComponent<TetroCourrant>();

            if (!(_tetroCourrant.ConditionGameOver()) && Mathf.RoundToInt(energie) != (Mathf.RoundToInt(maxEnergie))) // N'ajoute pas plus d'énergie si la barre d'énergie est déjà au max
            {
                energie += lignesDetruites;

                //String energieString = energie.ToString(".##");
               
                barreEnergie.SetEnergie(energie);

            }

            
        }

        /// <summary>
        /// Ajoute 0.1 énergie après chaque Tétromino placé.
        /// </summary>
        /// <param name="nombreVerrou">Le nombre de Tetromino placé</param>
        public void AjoutEnergieVerrou(int nombreVerrou)
        {
            if (!(_tetroCourrant.ConditionGameOver()) && Mathf.RoundToInt(energie) != (Mathf.RoundToInt(maxEnergie))) // N'ajoute pas plus d'énergie si la barre d'énergie est déjà au max
            {
                energie += nombreVerrou/10f; // A chaque fois, on divise 1 par 10 donc on ajoute 0.1
                barreEnergie.SetEnergie(energie);

            }
        }
        
        /// <summary>
        /// Enlève 4 d'énergie à la barre d'énergie.
        /// </summary>
        public void ResetEnergie()
        {
            energie -= 4f;

            barreEnergie.SetEnergie(energie);
        }
    }
}

