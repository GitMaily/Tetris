using System;
using UnityEngine;

namespace Script
{
    public class LoadController : MonoBehaviour
    {
        public static bool isLoad = false;

        public void LoadClick()
        {
            isLoad = true;
        }

        public bool IsLoad
        {
            get => isLoad;
            set => isLoad = value;
        }
        
        
    }
}