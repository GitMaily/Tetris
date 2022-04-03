using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class Energie : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxEnergie(int energie)
        {
            slider.maxValue = energie;
            slider.value = energie;
            
            
        }


        public void SetEnergie(int energie)
        {
            slider.value = energie;
        }
    }
    
    
}

