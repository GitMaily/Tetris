using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class MainGame : MonoBehaviour
    {
        //Liste d'objets à utiliser
        #region Objets

        public GameObject ecranPrincipal;
        private EcranPrincipal _ecranPrincipal;

        public GameObject tetroCourrant;
        private TetroCourrant _tetroCourrant;

        public GameObject boutonsBis;
        private BoutonsBis _boutonsBis;

        public GameObject score;

        public GameObject pause;

        #endregion Objets
        
        
        // Start is called before the first frame update
        // Chargement début
        void Start()
        {
            //Obtenir des composants dans la classe EcranPrincipal et les initialiser.
            _ecranPrincipal = ecranPrincipal.GetComponent<EcranPrincipal>(); 
            _ecranPrincipal.Initialiser();

            // Charger les tetrominos
            _tetroCourrant = tetroCourrant.GetComponent<TetroCourrant>();
            _tetroCourrant.InitialiserTetromino();
            _tetroCourrant.UpdateTetromino();
            
            // Charger l'espace Next
            
            _tetroCourrant.Next();
            //_tetroCourrant.Next3();
           

            // Charger l'utilisation des boutons
            _boutonsBis = boutonsBis.GetComponent<BoutonsBis>();
            _boutonsBis.Initialiser();

        }

        // Update is called once per frame
        void Update()
        {
            
                _tetroCourrant.Chute();
                _boutonsBis.BoutonCheck();
                _boutonsBis.BoutonBas();
                _boutonsBis.BoutonHaut();
                _boutonsBis.BoutonEspace();
                _boutonsBis.Tabulation();
                _boutonsBis.Echap();
                _tetroCourrant.Next();

            
            //_tetroCourrant.PositionCarresCourrant();

        }
    }
}