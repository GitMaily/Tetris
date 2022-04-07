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
        public Gradient gradient;
        public Slider slider;
        public Image fill;
        /// <summary>
        /// Attribue un maximum à la barre d'énergie.
        /// </summary>
        /// <param name="energie">Le nombre d'énergie maximale que l'on veut attribuer</param>
        public void SetMaxEnergie(float energie)
        {
            slider.maxValue = energie;
            slider.value = energie;

            fill.color = gradient.Evaluate(1f);
        }


        /// <summary>
        /// Attribue de l'énergie à la barre d'énergie.
        /// </summary>
        /// <param name="energie">Nombre d'énergie à attribuer.</param>
        public void SetEnergie(float energie)
        {
            slider.value = ArrondirFloat(energie,100);
            fill.color = gradient.Evaluate(slider.normalizedValue);

        }
        
        
        
        
        /// <summary>
        /// Arrondit un float à une precision déterminée.
        /// </summary>
        /// <param name ="unFloat">Un float à arrondir</param>
        /// <param name ="precision">Nombre de chiffres apres la virgule avec le nombre de zéros(100000....)</param>
        /// <returns> La valeur du float arrondie </returns>
        public static float ArrondirFloat(float unFloat, float precision)
        {
            return Mathf.Floor(unFloat * precision + 0.5f) / precision;
        }

    }
    
    
    
    
}

