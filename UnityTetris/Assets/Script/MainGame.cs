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

        public GameObject _sauvegarde;
        private MenuSauvegarde menuSauvegarde;

        public GameObject score;
        private Score _score;

        public GameObject pause;

        
        private GameObject _shapeTetromino;
        private const int DistanceCarre = 50; // Distance entre chaque carré (espace de 3 entre chaque carré, donc 47 + 3)


        public GameObject ligne;
        private DestructionLigne _destructionLigne;

        public GameObject colli;
        private Collision _collisions;
        
        
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
            
            // Sauvegarde

            //menuSauvegarde = _sauvegarde.GetComponent<MenuSauvegarde>();
            
            // Destruction Ligne
            _destructionLigne = ligne.GetComponent<DestructionLigne>();

            _destructionLigne.Initialiser();
            

            // Collision
            
            _collisions = colli.GetComponent<Collision>();

            _score = score.GetComponent<Score>();
            _score.Initialiser();

        }

        // Update is called once per frame
        void Update()
        {

            //menuSauvegarde.Sauvegardes();

            //_tetroCourrant.BloquerChampDeJeu();
            //_tetroCourrant.ChampDuJ();

            _tetroCourrant.Chute();
            _boutonsBis.BoutonCheck();
            _boutonsBis.BoutonBas();
            _boutonsBis.BoutonHaut();
            _boutonsBis.BoutonEspace();
            _boutonsBis.Tabulation();
            _boutonsBis.Echap();
            _tetroCourrant.Next();
            
           
            _score.AjouterScore(_destructionLigne.Ligne());
            _score.UpdateScore();
            


        }
    }
}
