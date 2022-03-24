using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class MainGame : MonoBehaviour
    {
        #region  //indiquer des objets on va utiliser

        public GameObject ecranPrincipal;
        private EcranPrincipal _ecranPrincipal;

        public GameObject tetroCourrant;
        private TetroCourrant _tetroCourrant;

        public GameObject boutonsBis;
        private BoutonsBis _boutonsBis;

        public GameObject score;

        public GameObject pause;

        #endregion
        
        
        // Start is called before the first frame update
        void Start()
        {
            //Obtenir des composants dans la classe EcranPrincipal et les initialiser.
            _ecranPrincipal = ecranPrincipal.GetComponent<EcranPrincipal>(); 
            _ecranPrincipal.Initialiser();

            _tetroCourrant = tetroCourrant.GetComponent<TetroCourrant>();
            _tetroCourrant.InitialiserTetromino();
            _tetroCourrant.UpdateTetromino();

            _boutonsBis = boutonsBis.GetComponent<BoutonsBis>();
            _boutonsBis.Initialiser();

        }

        // Update is called once per frame
        void Update()
        {
            _tetroCourrant.Chute();
            _boutonsBis.BottonCheck();
        }
    }
}
