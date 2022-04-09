using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering;
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
        // private MenuSauvegarde menuSauvegarde;

        public GameObject score;
        private Score _score;

        public GameObject pause;

        
        private GameObject _shapeTetromino;
        private const int DistanceCarre = 50; // Distance entre chaque carré (espace de 3 entre chaque carré, donc 47 + 3)


        public GameObject ligne;
        private DestructionLigne _destructionLigne;

        public GameObject colli;
        private Collision _collisions;

        public GameObject energie;
        private EnergieCourant _energieCourant;
        
        public GameObject perdu;
        private GameOver _perdu;

        public GameObject menuPause;
        private MenuPause _menuPause;

        public GameObject loadController;
        private LoadController _loadController;
        
        #endregion Objets
        
        
        // Start is called before the first frame update
        // Chargement début
        void Start()
        {
            _loadController = loadController.GetComponent<LoadController>();
            //Obtenir des composants dans la classe EcranPrincipal et les initialiser.
            _ecranPrincipal = ecranPrincipal.GetComponent<EcranPrincipal>(); 
            _ecranPrincipal.Initialiser();

            if (_loadController.GetIsLoad())
            {
                Sauvegarde sauvegarde = ChargerSauvegarde("sauvegarde1.json");
                _tetroCourrant = tetroCourrant.GetComponent<TetroCourrant>();
                _tetroCourrant.InitialiserTetromino();
                _score = score.GetComponent<Score>();
                _energieCourant = energie.GetComponent<EnergieCourant>();
                foreach (TypeTetromino typeTetromino in sauvegarde.listTetromino)
                {
                    _tetroCourrant._tetroGenerator.ListTetrominos.Dequeue();
                    _tetroCourrant._tetroGenerator.ListTetrominos.Enqueue(typeTetromino);
                }

                _score._scoreCourant = sauvegarde.score;
                
                _energieCourant.Initialiser(sauvegarde.energie);

            }
            else
            {
                _tetroCourrant = tetroCourrant.GetComponent<TetroCourrant>();
                _tetroCourrant.InitialiserTetromino();
                
                            
                // Score
                _score = score.GetComponent<Score>();
                _score.Initialiser();
                                        
                // Energie
                _energieCourant = energie.GetComponent<EnergieCourant>();
                _energieCourant.Initialiser(0.0f);
            }
            // Charger les tetrominos
            _tetroCourrant.UpdateTetromino();
            // Charger l'espace Next
            
            _tetroCourrant.Next();
            //_tetroCourrant.Next3();
           

            // Charger l'utilisation des boutons
            _boutonsBis = boutonsBis.GetComponent<BoutonsBis>();
            _boutonsBis.Initialiser();
            
            
            // Destruction Ligne
            _destructionLigne = ligne.GetComponent<DestructionLigne>();

            _destructionLigne.Initialiser();
            

            // Collision
            
            _collisions = colli.GetComponent<Collision>();
            
            // GameOver
            _perdu = perdu.GetComponent<GameOver>();

            // Pause
            _menuPause = menuPause.GetComponent<MenuPause>();

        }

        // Update is called once per frame
        void Update()
        {

            //menuSauvegarde.Sauvegardes();

            if (!MenuPause._estPause && !_tetroCourrant.ConditionGameOver())
            {
                _tetroCourrant.Chute();
                _boutonsBis.BoutonCheck();
                _boutonsBis.BoutonBas();
                _boutonsBis.BoutonHaut();
                _boutonsBis.BoutonEspace();
                _boutonsBis.Echap();

            }
            
            _tetroCourrant.Next();
            
            //_destructionLigne.LigneBonus();
            
            _score.AjouterScoreBonus(_destructionLigne.LigneBonus());
            _score.AjouterScore(_destructionLigne.Ligne());
            
            _score.UpdateScore();
            
            _energieCourant.AjoutEnergie(_destructionLigne.GetLignesDetruitesEchange());
            _energieCourant.AjoutEnergie(_destructionLigne.GetLignesBonusDetruites());

            
            _energieCourant.AjoutEnergieVerrou(_tetroCourrant.GetCompteurVerrou());


            if (!MenuPause._estPause && !_tetroCourrant.ConditionGameOver() && Input.GetKeyDown(KeyCode.Tab) && Mathf.RoundToInt(_energieCourant.energie) >= Mathf.RoundToInt(4f))
            {
                
                    _energieCourant.ResetEnergie();
                    _tetroCourrant.GenererEchange();
                
            }
            

            _tetroCourrant.AugmentationDifficulte(_destructionLigne.GetTotalLignesDetruites());


            //_perdu.ScoreFinal();
            _menuPause.Pause();
            if (_tetroCourrant.ConditionGameOver())
            {
                _perdu.gameOverUI.SetActive(true);
                //Time.timeScale = 0f;
                _perdu.GamePerdu();

            }
            
            
        }

        public void Sauvegarder()
        {
            Sauvegarde _sauvegarde = new Sauvegarde();
            _sauvegarde.typeTetrominoEchange = _tetroCourrant._typeTetrominoEchange;
            
            if (_sauvegarde.typeTetrominoEchange == TypeTetromino.Null)
            {
                for (int i = 0; i < 9; i++)
                    _sauvegarde.listTetromino.Add(_tetroCourrant._tetroGenerator.ListTetrominos.ToArray()[i]);
                _sauvegarde.listTetromino.Insert(0, _tetroCourrant._typeTetromino);
            }
            else
            {
                for (int i = 0; i < 8; i++)
                    _sauvegarde.listTetromino.Add(_tetroCourrant._tetroGenerator.ListTetrominos.ToArray()[i]);
                _sauvegarde.listTetromino.Insert(0, _sauvegarde.typeTetrominoEchange);
                _sauvegarde.listTetromino.Insert(1, _tetroCourrant._typeTetromino);
                _sauvegarde.hasTetroEchange = true;
            }

            _sauvegarde.score = _score._scoreCourant;

            _sauvegarde.energie = _energieCourant.energie;

            //_sauvegarde.Matrice = _ecranPrincipal.Matrice;

            

            string filepath = Application.dataPath + "/sauvegarde1.json";

            string sauvegardeJson = JsonUtility.ToJson(_sauvegarde, true);

            StreamWriter streamWriter = File.CreateText(filepath);
            
            streamWriter.Close();
            
            File.WriteAllText(filepath, sauvegardeJson, Encoding.UTF8);
            
        }

        public Sauvegarde ChargerSauvegarde(string filename)
        {
            //if (File.Exists(Application.dataPath + "/" + filename))
            {
                string json = File.ReadAllText(Application.dataPath + "/" + filename);
                return JsonUtility.FromJson<Sauvegarde>(json);
            }
            
        }
    }
}
