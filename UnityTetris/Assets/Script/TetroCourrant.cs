using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;


public class TetroCourrant : MonoBehaviour
{
    // On crée un objet pour chaque tétromino

    #region ObjetsTetro

    public GameObject TetroI;
    public GameObject TetroJ;
    public GameObject TetroL;
    public GameObject TetroO;
    public GameObject TetroS;
    public GameObject TetroZ;
    public GameObject TetroT;

    public GameObject TetroBonus;
    #endregion ObjetsTetro

    public GameObject canvas;

    public EcranPrincipal _champDeJeu;

    //public GameObject TableauDeJeu;
    public GameObject[] _positionVerrou;

    public GameObject carresVerrouilles;

    public GameObject tetroGenerator;
    public TetroGenerator _tetroGenerator;

    private GameObject _shapeTetromino;
    private GameObject _shapeTetrominoNext;
    private GameObject _shapeTetrominoEchange;
    
    [SerializeField]
    public TypeTetromino _typeTetromino;

    [SerializeField] 
    public TypeTetromino _typeTetrominoNext;

    [SerializeField] 
    public TypeTetromino _typeTetrominoEchange = TypeTetromino.Null;

    //public GameObject detruireLigne;

    public GameObject score;
    private Score _score;

    // Initialisation du temps
    // On peut modifier les valeurs sur l'éditeur
    public float temps;
    public float tempsChute = 0.5f;
    private float _compteurTemps;
    public int compteurChute;


    private const int DistanceCarre = 50; // Distance entre chaque carré (espace de 3 entre chaque carré, donc 47 + 3)

    /// <summary>
    /// Génère une liste de Tetrominos avec la classe TetroGenerator.
    /// La liste correspond à une file, méthode first in first out.
    /// </summary>
    public void InitialiserTetromino()
    {
        _tetroGenerator = tetroGenerator.GetComponent<TetroGenerator>();

        _tetroGenerator.ListTetrominos = new Queue<TypeTetromino>(10); // création d'une file d'attente

        while (_tetroGenerator.ListTetrominos.Count < 10) // Génération d'au moins 10 tétrominos
        {
            _tetroGenerator.GenerateTetro();
        }

    }

    /// <summary>
    /// Utilise la méthode Dequeue() pour instancier dans le champ de jeu le prochain Tetromino de la file à la position (250,1050).
    /// </summary>
    public void UpdateTetromino()
    {
        GameObject clones = GameObject.FindWithTag("clone");
        if (clones == null)
        {
            
        
            //if (_shapeTetromino == null)

            //{
            _tetroGenerator.GenerateTetro();
            _typeTetromino = _tetroGenerator.ListTetrominos.Dequeue();
            
            switch (_typeTetromino) // On défile
                                                             // On instancie le Tetrominos défilé
            {

                case TypeTetromino.TetroI:
                    _shapeTetromino = Instantiate(TetroI, new Vector3(250, 1050, 0), Quaternion.identity);
                    _shapeTetromino.tag = "clone"; // On associe chaque instance de Tetro avec le tag "clone", nous permettant de les manipuler 
                    // On pourra par exemple détruire ou les remplacer.

                    break;
                case TypeTetromino.TetroJ:
                    _shapeTetromino = Instantiate(TetroJ, new Vector3(250, 1050, 0), Quaternion.identity);
                    _shapeTetromino.tag = "clone";

                    break;
                case TypeTetromino.TetroL:
                    _shapeTetromino = Instantiate(TetroL, new Vector3(250, 1050, 0), Quaternion.identity);
                    _shapeTetromino.tag = "clone";

                    break;
                case TypeTetromino.TetroO
                    : // Le Tetro O est particulier, son millieu ne contenant pas de carré, il a fallut décaler de (25,-25)
                    _shapeTetromino = Instantiate(TetroO, new Vector3(250, 1050, 0), Quaternion.identity);
                    _shapeTetromino.tag = "clone";
                    
                    break;
                case TypeTetromino.TetroS:
                    _shapeTetromino = Instantiate(TetroS, new Vector3(250, 1050, 0), Quaternion.identity);
                    _shapeTetromino.tag = "clone";
                    break;
                case TypeTetromino.TetroZ:
                    _shapeTetromino = Instantiate(TetroZ, new Vector3(250, 1050, 0), Quaternion.identity);
                    _shapeTetromino.tag = "clone";
                    break;
                case TypeTetromino.TetroT:
                    _shapeTetromino = Instantiate(TetroT, new Vector3(250, 1000, 0), Quaternion.identity);
                    _shapeTetromino.tag = "clone";
                    break;
                default:
                    _shapeTetromino = null;
                    break;
            }
            // Si la pièce a été placée, détruire le tétromino de l'espace Next pour la remplacer avec la prochaine
            if (!EstDedans())
            {
                GameObject nextGroupe = GameObject.FindGameObjectWithTag("next"); // On cherche les objets ayant pour tag "next"
                Destroy(nextGroupe);
            }

            //}

            if (_tetroGenerator.ListTetrominos.Count < 10)
            {
                _tetroGenerator.GenerateTetro();
            }
        }
    }



    #region Mouvements joueur
    public void AGauche()
    {
        //Debug.Log("Déplacement gauche");
        _shapeTetromino.transform.position += new Vector3(-1 * DistanceCarre, 0, 0);
        //transform.position += new Vector3(-50, 0, 0);
        if (!EstDedans()) // Si la nouvelle position est hors limite
        {
            _shapeTetromino.transform.position -= new Vector3(-1 * DistanceCarre, 0, 0); // Retourner à la position d'avant (aucun mouvement)
        }
    }

    public void ADroite()
    {
        //Debug.Log("Déplacement droit");
        _shapeTetromino.transform.position += new Vector3(1 * DistanceCarre, 0, 0);
        //transform.position += new Vector3(50, 0, 0);

        if (!EstDedans()) // Si la nouvelle position est hors limite
        {
            _shapeTetromino.transform.position -= new Vector3(1 * DistanceCarre, 0, 0); // Retourner à la position d'avant (aucun mouvement)
        }

        /*if (EstEnCollision())
        {
            _shapeTetromino.transform.position -= new Vector3(1 * DistanceCarre, 0, 0);

        }*/
    }



    public void Descendre()
    {
        tempsChute /= 10;
        
        if (!EstDedans()) // Si la nouvelle position est hors limite
        {
            _shapeTetromino.transform.position -= new Vector3(0, -1 * DistanceCarre, 0); // Retourner à la position d'avant (aucun mouvement)

        }
    }
    public void Descente()
    {
        float tempsMax = 1.0f;
        float tempsMaintenu = 0f;
        //Debug.Log("Descente verticale plus rapide de la pièce");

        // Maintient bouton
        if (Input.GetKeyDown(KeyCode.S))
        {
            _shapeTetromino.transform.position += new Vector3(0, -1 * DistanceCarre, 0);

            _compteurTemps = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {

            tempsMaintenu = Time.time - _compteurTemps;
            Debug.Log("Temps maintenu :" + tempsMaintenu);
        }

        if (tempsMaintenu > tempsMax)
        {
            for (int i = 0; i < tempsMaintenu; i++)
            {
                Chute();
                _shapeTetromino.transform.position += new Vector3(0, -1 * DistanceCarre, 0);
            }
            //transform.position += new Vector3(0, -50, 0);
        }
        // Fin maintient bouton


        if (!EstDedans()) // Si la nouvelle position est hors limite
        {
            _shapeTetromino.transform.position -= new Vector3(0, -1 * DistanceCarre, 0); // Retourner à la position d'avant (aucun mouvement)

        }
    }

    public void RotationGauche()
    {
        int posX = Mathf.RoundToInt(_shapeTetromino.transform.position.x);
        int posY = Mathf.RoundToInt(_shapeTetromino.transform.position.y);
        
        //if (_typeTetromino != TypeTetromino.TetroO)
        {
            //Debug.Log("Flèche bas appuyée : effectuer la rotation à gauche de la pièce de 90°");
            _shapeTetromino.transform.Rotate(0, 0, 90);
            if (!EstDedans()) // Si la nouvelle position est hors limite
            {
                _shapeTetromino.transform.Rotate(0, 0, -90); // Retourner à la position d'avant (aucun mouvement)
                // On vérifie si la translation de la Matrice 3x3 est valide 
                if (_typeTetromino != TypeTetromino.TetroI && _shapeTetromino.transform.position.x <= 100 
                    && _champDeJeu.Matrice[posX,posY] == null
                    && _champDeJeu.Matrice[posX+50,posY] == null 
                    && _champDeJeu.Matrice[posX+100,posY] == null
                    /*&& _champDeJeu.Matrice[Mathf.RoundToInt(_shapeTetromino.transform.position.x)+150,Mathf.RoundToInt(_shapeTetromino.transform.position.y)] == null*/
                    && _champDeJeu.Matrice[posX,posY-50] == null
                    //&& _champDeJeu.Matrice[Mathf.RoundToInt(_shapeTetromino.transform.position.x),Mathf.RoundToInt(_shapeTetromino.transform.position.y-100)] == null
                    /*&& _champDeJeu.Matrice[Mathf.RoundToInt(_shapeTetromino.transform.position.x),Mathf.RoundToInt(_shapeTetromino.transform.position.y-150)] == null*/
                    && _champDeJeu.Matrice[posX+50,posY-50] == null
                    && _champDeJeu.Matrice[posX+50,posY-100] == null
                    /*&& _champDeJeu.Matrice[Mathf.RoundToInt(_shapeTetromino.transform.position.x+50),Mathf.RoundToInt(_shapeTetromino.transform.position.y-150)] == null*/
                    && _champDeJeu.Matrice[posX+100,posY-50] == null
                    && _champDeJeu.Matrice[posX+100,posY-100] == null)
                    
                {
                    ADroite();
                    _shapeTetromino.transform.Rotate(0, 0, 90);

                }
                if (_typeTetromino != TypeTetromino.TetroI && _shapeTetromino.transform.position.x >= 400 
                   && _champDeJeu.Matrice[posX,posY] == null
                   && _champDeJeu.Matrice[posX+-50,posY] == null 
                   && _champDeJeu.Matrice[posX-100,posY] == null
                   && _champDeJeu.Matrice[posX,posY-50] == null
                   && _champDeJeu.Matrice[posX-50,posY-50] == null
                   && _champDeJeu.Matrice[posX-50,posY-100] == null
                   && _champDeJeu.Matrice[posX-100,posY-50] == null
                   && _champDeJeu.Matrice[posX-100,posY-100] == null)
                {
                    AGauche();
                    _shapeTetromino.transform.Rotate(0, 0, 90);

                }

            }

                  
        }
    }

    public void RotationDroite()
    {
        int posX = Mathf.RoundToInt(_shapeTetromino.transform.position.x);
        int posY = Mathf.RoundToInt(_shapeTetromino.transform.position.y);
        
        //if (_typeTetromino != TypeTetromino.TetroO)
        {
            //Debug.Log("Flèche haut appuyée : effectuer la rotation à droite de la pièce de 90°");
            _shapeTetromino.transform.Rotate(0, 0, -90);
    
            if (!EstDedans()) // Si la nouvelle position est hors limite
            {
                _shapeTetromino.transform.Rotate(0, 0, 90); // Retourner à la position d'avant (aucun mouvement)
                
                // On vérifie si la translation de la Matrice 3x3 est valide 

                if (_typeTetromino != TypeTetromino.TetroI && _shapeTetromino.transform.position.x >= 400 
                    && _champDeJeu.Matrice[posX,posY] == null
                    && _champDeJeu.Matrice[posX-50,posY] == null 
                    && _champDeJeu.Matrice[posX-50,posY-50] == null
                    && _champDeJeu.Matrice[posX-50,posY-100] == null
                    && _champDeJeu.Matrice[posX-100,posY] == null
                    && _champDeJeu.Matrice[posX-100,posY-50] == null
                    && _champDeJeu.Matrice[posX-100,posY-100] == null
                    && _champDeJeu.Matrice[posX,posY-50] == null)
                {
                    AGauche();
                    _shapeTetromino.transform.Rotate(0, 0, -90);

                }
                if (_typeTetromino != TypeTetromino.TetroI && _shapeTetromino.transform.position.x <= 100 
                    && _champDeJeu.Matrice[posX,posY] == null
                    && _champDeJeu.Matrice[posX+50,posY] == null 
                    && _champDeJeu.Matrice[posX+100,posY] == null
                    && _champDeJeu.Matrice[posX,posY-50] == null
                    && _champDeJeu.Matrice[posX+50,posY-50] == null
                    && _champDeJeu.Matrice[posX+50,posY-100] == null
                    && _champDeJeu.Matrice[posX+100,posY-50] == null
                    && _champDeJeu.Matrice[posX+100,posY-100] == null)
                {
                    ADroite();
                    _shapeTetromino.transform.Rotate(0, 0, -90);

                }
                
                
                
                 /*if (_shapeTetromino.transform.position.x <= 100 
                    && _champDeJeu.Matrice[posX,posY] == null
                    && _champDeJeu.Matrice[posX+50,posY] == null 
                    && _champDeJeu.Matrice[posX+100,posY] == null
                    && _champDeJeu.Matrice[posX+150,posY] == null
                    && _champDeJeu.Matrice[posX,posY-50] == null
                    && _champDeJeu.Matrice[posX,posY-100] == null
                    && _champDeJeu.Matrice[posX,posY-150] == null
                    && _champDeJeu.Matrice[posX+50,posY-50] == null
                    && _champDeJeu.Matrice[posX+50,posY-100] == null
                    && _champDeJeu.Matrice[posX+50,posY-150] == null
                    && _champDeJeu.Matrice[posX+100,posY-50] == null
                    && _champDeJeu.Matrice[posX+100,posY-100] == null
                    && _champDeJeu.Matrice[posX+100,posY-150] == null
                    && _champDeJeu.Matrice[posX+150,posY-50] == null
                    && _champDeJeu.Matrice[posX+150,posY-100] == null
                    && _champDeJeu.Matrice[posX+150,posY-150] == null)
                    
                {
                    ADroite();
                    _shapeTetromino.transform.Rotate(0, 0, 90);

                }*/
                
            }
        }
    }

    private bool RotationEstPossible()
    {
        bool rotation = (_typeTetromino != TypeTetromino.TetroO);

        return rotation;
    }
    #endregion Mouvements joueurs
    
    /// <summary>
    /// Utilise la méthode Peek() pour voir le premier Tetromino de la file, sans la défiler.
    /// Instancie ce tétromino dans l'espace Next.
    /// </summary>
    public void Next()
    {
        GameObject tetroNext = GameObject.FindGameObjectWithTag("next");

        if (tetroNext == null)
        {
            _typeTetrominoNext = _tetroGenerator.ListTetrominos.Peek();
            switch (_typeTetrominoNext) // On regarde le premier élément de la file sans la défiler
                                                        // On instancie le Tetrominos donné dans l'espace Next
            {

                case TypeTetromino.TetroI:
                    _shapeTetrominoNext = Instantiate(TetroI, new Vector3(660, 950, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";

                    break;
                case TypeTetromino.TetroJ:
                    _shapeTetrominoNext = Instantiate(TetroJ, new Vector3(660, 950, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";

                    break;
                case TypeTetromino.TetroL:
                    _shapeTetrominoNext = Instantiate(TetroL, new Vector3(660, 950, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";

                    break;
                case TypeTetromino.TetroO:
                    _shapeTetrominoNext = Instantiate(TetroO, new Vector3(660, 950, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";
                    
                    break;
                case TypeTetromino.TetroS:
                    _shapeTetrominoNext = Instantiate(TetroS, new Vector3(660, 950, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";
                    break;
                case TypeTetromino.TetroZ:
                    _shapeTetrominoNext = Instantiate(TetroZ, new Vector3(660, 950, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";
                    break;
                case TypeTetromino.TetroT:
                    _shapeTetrominoNext = Instantiate(TetroT, new Vector3(660, 900, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";
                    break;

            }

        }
    }

    #region Echange
    

    /// <summary>
    /// Place un carré bonus dans l'espace Echange
    /// </summary>
    public void InstantiateBonusEspaceEchange()
    {
        GameObject shapeBonus;

        shapeBonus = Instantiate(TetroBonus, new Vector3(660, 600, 0), Quaternion.identity);
        shapeBonus.transform.SetParent(_tetroEchange.transform); 
    }
    
    /// <summary>
    /// Génère un carré bonus dans le groupe d'échange, et supprime le premier enfant du groupe.
    /// </summary>
    /// <param name="groupeEchange">Le groupe GameObject où placer le carré bonus.</param>
    public void GenererCarreBonus(GameObject groupeEchange)
    {
        GameObject shapeBonus;

        // On crée le carré bonus
        shapeBonus = Instantiate(TetroBonus, new Vector3(660, 600, 0), Quaternion.identity);
        shapeBonus.transform.SetParent(groupeEchange.transform); 
            
        // On détruit un des carré qui sera remplacé par le carré bonus. Il s'agit du premier objet du groupe
        if (groupeEchange.transform.childCount == 5)
        {

            Destroy(groupeEchange.transform.GetChild(0).gameObject);
            
        }
    }

    public GameObject _tetroEchange;
    /// <summary>
    /// Instancie dans l'espace d'Echange le Tetromino courant.
    /// </summary>
    public void GenererEchange()
    {
        GameObject shapeBonus;
        GameObject clones = GameObject.FindGameObjectWithTag("clone"); // On cherche les objets ayant pour tag "clone"
        GameObject nextGroupe = GameObject.FindGameObjectWithTag("next"); // On cherche les objets ayant pour tag "next"

        GameObject echangeGroupe = GameObject.FindGameObjectWithTag("EchangeGroupe"); // On cherche les objets ayant pour tag "EchangeGroupe"
        _tetroEchange = _shapeTetromino;


        // S'il y a déjà un groupe d'échange : //
        
        /*  1. Détruire le groupe de Tétromino dans l'espace d'échange
         *  2. Placer le tétromino courant dans l'espace d'échange
         *  3. Instancier le tétromino précédemment stocké dans le champ de jeu
         *  4. Détruire le tétromino courant
         */
        
        if (echangeGroupe != null)  
        {
            
            
            Destroy(echangeGroupe); // On détruit le Tétromino affiché dans Echange
            //Debug.Log("echange groupe a été supprimé");
            
    
            // Instancier le tétromino courant dans l'espace d'échange
            // Donner le tag "EchangeGroupe" au groupe de Tétrominos stocké
            _tetroEchange = Instantiate(_shapeTetromino, new Vector3(660, 600, 0), Quaternion.identity);
            _tetroEchange.tag = "EchangeGroupe";

            TypeTetromino temps = _typeTetrominoEchange;
            _typeTetrominoEchange = _typeTetromino;
            
            int nbCarresBonus = 0;

            
            // On compte le nombre de carrés bonus parmis un groupe de Tetrominos
            for (int i = 0; i < _tetroEchange.transform.childCount; i++)
            {
                bool estBonus = _tetroEchange.transform.GetChild(i).CompareTag("Bonus");
                if (estBonus)
                {
                    nbCarresBonus++;

                }

            }

            //Debug.Log("Nombre carres bonus:"+nbCarresBonus);
            if (nbCarresBonus == 0) // S'il n'existe aucun carré bonus, en créer un.

            {
                shapeBonus = Instantiate(TetroBonus, new Vector3(660, 600, 0), Quaternion.identity);
                shapeBonus.transform.SetParent(_tetroEchange.transform); 
            }
            else // Sinon, détruire le carré bonus de trop
            {
                Destroy(GameObject.FindWithTag("Bonus"));
                
            }

            // On détruit un des carré qui sera remplacé par le carré bonus. Il s'agit du premier objet du groupe
            if (_shapeTetromino.transform.childCount == 5 || _tetroEchange.transform.childCount == 5 )
            {
                
                Destroy(_shapeTetromino.transform.GetChild(0).gameObject);
                Destroy(_tetroEchange.transform.GetChild(0).gameObject);
            }
            
            GameObject _tetroEchange2 = echangeGroupe ;

           
            // Instancier le tétromino précédemment stocké dans le jeu
            // Donner le tag "clone" au groupe de Tétrominos courant
            _shapeTetromino = Instantiate(_tetroEchange2, new Vector3(250, 1050, 0), Quaternion.identity);
            _shapeTetromino.tag = "clone";
            _typeTetromino = temps;
            
            // On détruit un des carré qui sera remplacé par le carré bonus. Il s'agit du premier objet du groupe
            if (_tetroEchange2.transform.childCount == 5)
            {
                Destroy(_tetroEchange2.transform.GetChild(0).gameObject);

            }
            
            _tetroGenerator.GenerateTetro();
            
            Destroy(clones); // On détruit l'objet
            
        }
        // S'il n'y a aucun Tétromino dans l'espace d'échange (Tout premier échange du jeu) : //
        
        /*  1. Détruire le tétromino de l'espace Next
         *  2. Détruire le tétromino courant
         *  3. Placer le tétromino courant dans l'espace d'échange
         *  4. Instancier le prochain tétromino
         */
        
        else 
        {
            _tetroEchange.tag = "EchangeGroupe";
             
            Destroy(nextGroupe);   // On détruit le Tétromino affiché dans Next
             //Next();                // On remplace par la nouvelle pièce chargée
             
            Destroy(clones); // On détruit l'objet
            
            // Instancier le tétromino courant dans l'espace d'échange
            // Donner le tag "EchangeGroupe" au groupe de Tétrominos stocké
            _shapeTetromino = Instantiate( _tetroEchange, new Vector3(660, 600, 0), Quaternion.identity);
            _shapeTetromino.tag = "EchangeGroupe";
            _typeTetrominoEchange = _typeTetromino;
            //Object.Destroy(_shapeTetromino.transform.GetChild(0).gameObject);

            // On crée le carré bonus
            shapeBonus = Instantiate(TetroBonus, new Vector3(660, 600, 0), Quaternion.identity);
            shapeBonus.transform.SetParent(_shapeTetromino.transform);
            // On remplace un carré par le carré bonus
            if (_shapeTetromino.transform.childCount == 5)
            {
                Destroy(_shapeTetromino.transform.GetChild(0).gameObject);

            }
            UpdateTetromino();

        }
    }
    #endregion Echange


    public void AugmentationDifficulte(int totalLignesDetruites)
    {
        //Debug.Log("Total lignes détruites:"+totalLignesDetruites);
        _score = score.GetComponent<Score>();
        float vitesseChute = totalLignesDetruites / 1000f;
        tempsChute = 0.5f - vitesseChute;


    }
    
    public void Chute() // On décrémente de une case à chaque frame et selon la valeur du temps de chute 
    {
        GameObject clones = GameObject.FindWithTag("clone");
        //f (!(GameObject.FindWithTag("clone") == null )) // Seulement si il y a objet avec le tag "clone" (un tetromino dans le jeu)
        { 
            //            if (Time.time - temps > (Input.GetKey(KeyCode.Space)? tempsChute / 5 : tempsChute) )

            int compteurVerrou = 0;
            if (Time.time - temps > (Input.GetKey(KeyCode.Space)? tempsChute / 8 : tempsChute) ) 
            {
                
                _shapeTetromino.transform.position += new Vector3(0, -1 * DistanceCarre, 0);
                temps = Time.time;

                if (!EstDedans()  ) // Si la pièce est sur la limite
                {
                    _shapeTetromino.transform.position -= new Vector3(0, -1 * DistanceCarre, 0); // Annuler la chute

                    _shapeTetromino.tag = "VerrouGroupe"; // Attribuer au groupe Tetromino placé (du prefab) le tag "VerrouGroupe"

                    foreach (Transform carre in _shapeTetromino.transform) // Pour chaque carré d'un Tetromino
                    {
                        if (carre.CompareTag("Untagged"))
                        {
                            carre.tag = "Verrou"; // Attribuer à leur carré (donc à chaque enfants du prefab) le tag "Verrou"

                        } // Rechercher les Objets (ici le groupe Prefab de nos Tetrominos) qui ont un tag "Untagged"

                        else
                        {
                            carre.tag = "BonusVerrou";
                        }

                        

                    }

                    PositionCarresVerrouilles();
                    VerrouillerCarre();
                    VerrouillerCarreBonus();
                    //GameObject cloneBonus = GameObject.Find("CarreBonus");
                    //cloneBonus.tag = "BonusVerrou";
                    
                    // Puisqu'on va passer à un nouveau Tetromino, détruire le groupe dans l'espace Next
                    GameObject nextGroupe = GameObject.FindGameObjectWithTag("next"); // On cherche les objets ayant pour tag "next"
                    Destroy(nextGroupe);
                   

                    UpdateTetromino(); // Après que les tags ont été attribués, générer un nouveau Tetromino et ainsi de suite
                    compteurVerrou++;

                }
                
            }

            compteurChute = compteurVerrou;
        }
    }


    public int GetCompteurVerrou()
    {
        //Debug.Log("Nombre compteurChute:"+compteurChute);
        return compteurChute;
    }

    public bool EstDedans()

    {

        foreach (Transform carre in _shapeTetromino.transform) // Pour chaque carré d'un Tetromino
        {

            // Il faut arrondir pour éviter les problèmes de rotations et collisions
            int posX = Mathf.RoundToInt(carre.transform.position.x);
            int posY = Mathf.RoundToInt(carre.transform.position.y);

            if (posX > 500 || posX < 50 || posY < 100 || _champDeJeu.Matrice[posX,posY] != null) // Le Tetro Courant n'est plus dans la zone si il y a un dépassement dans:
                // le mur gauche (x < 50), le mur droit (x>500) et le sol (y<100)
                // S'il existe un carré verrouillé à la place du tetro Courant, ce Tetromino devient un mur aussi
            {
                return false;
                
            }
            
           
        }
        return true;
    }
    
    // Les deux méthodes PositionCarres*() retournent des Vecteur3 mais montrent différentes choses
    // Essayer de faire retourner les positions exactes de chacun de leur roles pour appliquer la collision
    
    public Vector3 PositionCarresCourrant() // Montre dans la console la position de chaque carré d'un tétromino à chaque frame
    {
        
        Vector3 positionGroupeTetro = _shapeTetromino.transform.position; // Le vecteur contient la position d'un groupe de tétromino Courrant
        Debug.Log("Position du groupe shapeTetromino:"+ positionGroupeTetro);
        
        var positionCarresCourrant = GameObject.FindWithTag("Untagged").transform.position; // Le vecteur contient la position des objets ayant pour tag "Untagged"
                                                                                                //cad chaque carré du tetromino courrant

        foreach (Transform carreCourrant in _shapeTetromino.transform) // Pour chaque carrés du groupe de Tetromino courrant
        {
            Vector3 positionCarre1 = carreCourrant.transform.position; // Prendre leur position
            Debug.Log("Position d'un carré courrant:"+ positionCarre1); // Annoncer dans la console
        }

        return positionCarresCourrant;
        
    }

    public void AfficherVectorList()
    {


        for (int i = 0; i < ListeVerrou.Count; i++)
        {
            Debug.Log("Position de chaque carrés Verrouillés dans le vecteur:"+ListeVerrou[i].ToString());
        }
    }
    
    private List<String> NomBlock = new List<String>();
    private List<Vector3> ListeVerrou = new List<Vector3>();
    private List<Vector3> ListeVerrouBonus = new List<Vector3>();
    
    public List<String> NomCarre()
    {
        _positionVerrou = GameObject.FindGameObjectsWithTag("Verrou");

        for (int i = 0; i < _positionVerrou.Length; i++)
        {
            if (carresVerrouilles.transform.GetChild(i).gameObject != null)
            {
                string nomBlock = carresVerrouilles.transform.GetChild(i).name;
                
                // Supprimer (clone) du nom du carré 
                if (nomBlock.Length > 7)
                {
                    nomBlock = nomBlock.Remove(6, nomBlock.Length-6);  // On supprime tout ce qui est après "CarreX"

                }

                NomBlock.Add(nomBlock); // On ajoute le nom dans la liste
            }
        }

        return NomBlock;
    }
    public List<String> GetNomBlock()
    {
        return NomBlock;
    }
    
    public List<Vector3> PosCarres()
    {
        _positionVerrou = GameObject.FindGameObjectsWithTag("Verrou");

        // avec for
        int count = _positionVerrou.Length;
        for(int i = 0; i < _positionVerrou.Length; i++)
        {
            if (carresVerrouilles.transform.GetChild(i).gameObject != null)
            {
                Transform block = carresVerrouilles.transform.GetChild(i);
                Vector3 positionCarre = block.transform.position;
                ListeVerrou.Add(positionCarre);
            }
        }
        return ListeVerrou;
    }
    public List<Vector3> GetListeVerrou()
    {
        return ListeVerrou;
    }
    
    public List<Vector3> PosCarresBonus()
    {
        _positionBonus = GameObject.FindGameObjectsWithTag("BonusVerrou");

        // avec for
        int count = _positionBonus.Length;
        for(int i = 0; i < _positionBonus.Length; i++)
        {
            if (BonusVerrouilles.transform.GetChild(i).gameObject != null)
            {
                
                Transform blockBonus = BonusVerrouilles.transform.GetChild(i);
                Vector3 positionCarreBonus = blockBonus.transform.position;
                ListeVerrouBonus.Add(positionCarreBonus);
            }
        }

        return ListeVerrouBonus;
    }
    public List<Vector3> GetListeVerrouBonus()
    {
        return ListeVerrouBonus;
    }
    
    
    /// <summary>
    /// Place les carrés ayant un tag "Verrou" dans le parent carresVerrouilles.
    /// </summary>
    /// <returns>Vector3 la position d'un carré avec un tag "Verrou"</returns>
    public void PositionCarresVerrouilles() // Montre dans la console la position de chaque carré qui ont été verouillés

    {

        
        _positionVerrou = GameObject.FindGameObjectsWithTag("Verrou");
        //Debug.Log(_positionVerrou.Length); // Nombre de carrés vérouillés
       
        // Pour chaque carrés ayant été vérouillés
        // Annoncer dans la console leur position
        // Les placer dans un seul et même groupe de Carrés vérouillés
        foreach (GameObject carre in _positionVerrou)
        {

            
            carre.transform.SetParent(carresVerrouilles.transform); // Les carrés vérouillés on été placés ici

            //posCarres = carre.transform.position; // Prendre leur position


        }
        
        _positionBonus = GameObject.FindGameObjectsWithTag("BonusVerrou");

        foreach (GameObject carre in _positionBonus)
        {

            var positionCarre = carre.transform.position;
            
            carre.transform.SetParent(BonusVerrouilles.transform); // Les carrés vérouillés on été placés ici


        }


    }
    
    /// <summary>
    /// Prend la position x et y de chaque carrés qui ont été verrouillés.
    /// Les place dans la Matrice 2D du champ de jeu.
    /// </summary>
    public void VerrouillerCarre()
    {
        _positionVerrou = GameObject.FindGameObjectsWithTag("Verrou");
        

        
        // avec for
        int count = _positionVerrou.Length;
        for(int i = 0; i < count; i++)
        {
            
            Transform block = carresVerrouilles.transform.GetChild(i);
            int X = Mathf.RoundToInt(block.position.x);
            int Y = Mathf.RoundToInt(block.position.y);
            //var positionCarre = block.transform.position;
            _champDeJeu.Matrice[X, Y] = block;
            
            //Debug.Log("Position d'un carré :"+ positionCarre);
            
        }

        // avec foreach
        /*foreach (Transform block in carresVerrouilles.transform)
        {
            int X = Mathf.RoundToInt(block.position.x);
            int Y = Mathf.RoundToInt(block.position.y);
            Debug.Log("nouvGrille&1 marche");

            Debug.Log("Longueur de _positionVerrou:"+_positionVerrou.Length);
            var positionCarre = block.transform.position;
            Debug.Log("Position d'un carré :"+ positionCarre);
                
            _champDeJeu.Matrice[X, Y] = block;
            Debug.Log("nouvGrille marche");

             

        }*/
            


    }

    public GameObject[] _positionBonus;
    public GameObject BonusVerrouilles;
    /// <summary>
    /// Prend la position x et y de chaque carrés qui ont été verrouillés.
    /// Les place dans la Matrice 2D du champ de jeu.
    /// </summary>
    public void VerrouillerCarreBonus()
    {
        _positionBonus = GameObject.FindGameObjectsWithTag("BonusVerrou");
        

        // avec for
        int count = _positionBonus.Length;
        for(int i = 0; i < count; i++)
        {
            
            Transform block = BonusVerrouilles.transform.GetChild(i);
            int X = Mathf.RoundToInt(block.position.x);
            int Y = Mathf.RoundToInt(block.position.y);
            //var positionCarre = block.transform.position;
            _champDeJeu.Matrice[X, Y] = block;
            
            //Debug.Log("Position d'un carré :"+ positionCarre);
        }
    }

   

    
    public bool EstEnCollision()
    {

        _positionVerrou = GameObject.FindGameObjectsWithTag("Verrou");
        GameObject _carreVerrou = GameObject.FindGameObjectWithTag("Verrou");


        foreach (Transform carre in _shapeTetromino.transform) // Pour chaque carré d'un Tetromino courant
        {
            int posX = Mathf.RoundToInt(carre.position.x);
            int posY = Mathf.RoundToInt(carre.position.y);

            if (_champDeJeu.Matrice[posX, posY] != null) 
            {
                return false;
            }
        }
        return true;

        
    }
    
    public GameObject perdu;
    private GameOver _perdu;
    
    public bool ConditionGameOver()
    {
        _perdu = perdu.GetComponent<GameOver>();

        bool depasser = false;
        foreach (Transform carre in _shapeTetromino.transform) // Pour chaque carré d'un Tetromino
        {
            int posX = Mathf.RoundToInt(carre.transform.position.x);
            int posY = Mathf.RoundToInt(carre.transform.position.y);
            // Vérifier si le tétromino dépasse le haut champ du jeu
            if (posY >= 1050 && _champDeJeu.Matrice[posX,posY] != null)
            {
                depasser = true;
                Debug.Log("Game Over.");
                //MenuPause._estPause = true;

                
                
            }
        }
        
        return depasser;
    }

    public Transform[,] GetMatrice()
    {
        return _champDeJeu.Matrice;
    }
}
        
