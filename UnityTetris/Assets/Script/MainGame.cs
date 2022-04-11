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
        
        public GameObject TetroI;
        public GameObject TetroJ;
        public GameObject TetroL;
        public GameObject TetroO;
        public GameObject TetroS;
        public GameObject TetroZ;
        public GameObject TetroT;

        public GameObject carreI;
        public GameObject carreJ;
        public GameObject carreL;
        public GameObject carreO;
        public GameObject carreS;
        public GameObject carreZ;
        public GameObject carreT;

        public GameObject carreBonus;





        
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

        private GameObject _placerEchange;
        private GameObject placerCarre;
        
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

        private List<GameObject> nomCarres;
        
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


                // Met dans une liste de GameObject les carrés à instancier selon leur noms enregistrés dans le fichier JSON
                // NameToGameObject();
                List<GameObject> listNomCarres = new List<GameObject>(); // Liste de GameObject stockant les carrés à instancier
                for (int nom = 0; nom < sauvegarde.nomCarre.Count; nom++)
                {
                    switch (sauvegarde.nomCarre[nom])
                    {
                        case "CarreI":
                            listNomCarres.Add(carreI);
                            break;
                        case "CarreJ":
                            listNomCarres.Add(carreJ);
                            break;
                        case "CarreL":
                            listNomCarres.Add(carreL);
                            break;
                        case "CarreO":
                            listNomCarres.Add(carreO);
                            break;
                        case "CarreS":
                            listNomCarres.Add(carreS);
                            break;
                        case "CarreZ":
                            listNomCarres.Add(carreZ);
                            break;
                        case "CarreT":
                            listNomCarres.Add(carreT);
                            break;
                       

                    }
                }
                
                // Intancie les carrés verrouillés par leur précédente position ainsi que par leur noms sauvegardés dans le fichier JSON
                for (int i = 0; i < sauvegarde.listePositionCarres.Count; i++)
                {
                    Vector3 positionCarre = sauvegarde.listePositionCarres[i];
                    //_tetroCourrant.carresVerrouilles.transform.position = positionCarre;
                    placerCarre = Instantiate(listNomCarres[i], positionCarre, Quaternion.identity);
                    placerCarre.transform.SetParent(_tetroCourrant.carresVerrouilles.transform);
                    placerCarre.tag = "Verrou";
                    //_tetroCourrant.VerrouillerCarre(_sauvegarde.Matrice,listNomCarres);


                }
                
                // Intancie les carrés Bonus verrouillés par leur précédente position ainsi que par leur noms sauvegardés dans le fichier JSON
                for (int i = 0; i < sauvegarde.listePositionCarresBonus.Count; i++)
                {
                    Vector3 positionCarreBonus = sauvegarde.listePositionCarresBonus[i];
                    //_tetroCourrant.carresVerrouilles.transform.position = positionCarre;
                    placerCarre = Instantiate(carreBonus, positionCarreBonus, Quaternion.identity);
                    placerCarre.transform.SetParent(_tetroCourrant.BonusVerrouilles.transform);
                    placerCarre.tag = "BonusVerrou";

                }

                _tetroCourrant.VerrouillerCarre(); // Verrouille les nouveaux carrés instanciés
                _tetroCourrant.VerrouillerCarreBonus(); // Verrouille les nouveaux carrés Bonus instanciés


                // Instancie le Tetromino sauvegardé de l'espace échange 
                if (sauvegarde.typeTetrominoEchange != TypeTetromino.Null)
                {
                    switch (sauvegarde.typeTetrominoEchange)
                    {
                        case TypeTetromino.TetroI: 
                            _placerEchange = Instantiate(TetroI,new Vector3(660, 600, 0), Quaternion.identity);
                            break;
                        case TypeTetromino.TetroJ:
                            _placerEchange = Instantiate(TetroJ,new Vector3(660, 600, 0), Quaternion.identity);
                            break;
                        case TypeTetromino.TetroL:
                            _placerEchange = Instantiate(TetroL,new Vector3(660, 600, 0), Quaternion.identity);
                            break;
                        case TypeTetromino.TetroO: 
                            _placerEchange = Instantiate(TetroO,new Vector3(660, 600, 0), Quaternion.identity);
                            break;
                        case TypeTetromino.TetroS: 
                            _placerEchange = Instantiate(TetroS,new Vector3(660, 600, 0), Quaternion.identity);
                            break;
                        case TypeTetromino.TetroZ: 
                            _placerEchange = Instantiate(TetroZ,new Vector3(660, 600, 0), Quaternion.identity);
                            break;
                        case TypeTetromino.TetroT: 
                            _placerEchange = Instantiate(TetroT,new Vector3(660, 600, 0), Quaternion.identity);
                            break;

                    }
                    _placerEchange.tag = "EchangeGroupe"; // Donne le tag "EchangeGroupe" au groupe
                   
                    _tetroCourrant.GenererCarreBonus(_placerEchange); // Va générer un carré bonus dans le groupe d'échange

                    

                }


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
            
            //_tetroCourrant.PosCarres();
            //_tetroCourrant.AfficherVectorList();
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
            
            
            for (int i = 0; i < 9; i++)
                _sauvegarde.listTetromino.Add(_tetroCourrant._tetroGenerator.ListTetrominos.ToArray()[i]);
            _sauvegarde.listTetromino.Insert(0, _tetroCourrant._typeTetromino);
            

            _sauvegarde.score = _score._scoreCourant;

            _sauvegarde.energie = _energieCourant.energie;

            
            // Sauvegarde les informations concernant tous les carrés verrouillés
            // Probablement inutile pour le chargement de sauvegarde
            _sauvegarde.nomCarre = _tetroCourrant.NomCarre(); // Enregistre le nom du carré verrouilé : permet de savoir la couleur
            _sauvegarde.listePositionCarresBonus = _tetroCourrant.PosCarresBonus(); // Enregistre chaque position d'un carré bonus verrouillé
            _sauvegarde.listePositionCarres = _tetroCourrant.PosCarres(); // Enregistre chaque position d'un carré verrouillé
           
            //// INUTILE ////
            // Sauvegarde de GameObjects <=> Le fichier JSON enregistre le "Instance ID" du GameObject
            // Tester si ça correspond à nos prefab etc
            _sauvegarde.carresVerrouilles = _tetroCourrant.carresVerrouilles; // Il s'agit du GameObject parent de la liste des carrés verrouillés dans Unity, je crois que c'est inutile?
            _sauvegarde.listeCarresVerrouilles = _tetroCourrant._positionVerrou; // Enregistre la liste des GameObject des carrés verrouillés
            _sauvegarde.listeCarresBonusVerrouilles = _tetroCourrant._positionBonus; // Enregistre la liste des GameObject des carrés bonus verrouillés
            //// INUTILE ////
            
            //_sauvegarde.Matrice = _tetroCourrant.GetMatrice();
            
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
