using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    /// <summary>
    /// Permet l'utilisation du slider d'énergie avec l'UI d'Unity.
    /// </summary>
    public class Energie : MonoBehaviour
    {
        public Slider slider;

        /// <summary>
        /// Attribue un maximal à la barre d'énergie.
        /// </summary>
        /// <param name="energie">Le nombre d'énergie maximale que l'on veut attribuer</param>
        public void SetMaxEnergie(int energie)
        {
            slider.maxValue = energie;
            slider.value = energie;
            
            
        }


        /// <summary>
        /// Attribue de l'énergie à la barre d'énergie.
        /// </summary>
        /// <param name="energie">Nombre d'énergie à attribuer.</param>
        public void SetEnergie(int energie)
        {
            slider.value = energie;
        }
    }
    
    
}

