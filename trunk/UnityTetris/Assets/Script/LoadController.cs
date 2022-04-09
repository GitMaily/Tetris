using System;
using UnityEngine;

namespace Script
{
    public class LoadController : MonoBehaviour
    {
        public static bool IsLoad = false;

        public void LoadClick()
        {
            IsLoad = true;
        }

        public bool GetIsLoad()
        {
            return IsLoad;
        }
        
    }
}