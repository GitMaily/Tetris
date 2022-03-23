using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class MainGame : MonoBehaviour
    {
        #region  //indiquer des objets on va utiliser

        public GameObject ecranPrincipal;
        private EcranPrincipal _ecranPrincipal;

        public GameObject score;

        public GameObject pause;

        #endregion
        
        
        // Start is called before the first frame update
        void Start()
        {
            //Obtenir des composants dans la classe EcranPrincipal et les initialiser.
            _ecranPrincipal = ecranPrincipal.GetComponent<EcranPrincipal>(); 
            _ecranPrincipal.Initialiser();
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
