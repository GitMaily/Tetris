using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Script;
using UnityEngine;
using UnityEngine.UIElements;

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

    #endregion ObjetsTetro


    public EcranPrincipal _champDeJeu;

    //public GameObject TableauDeJeu;
    private GameObject[] _positionVerrou;

    public GameObject carresVerrouilles;

    public GameObject tetroGenerator;
    private TetroGenerator _tetroGenerator;

    public GameObject _shapeTetromino;
    private GameObject _shapeTetrominoNext;
    private GameObject _shapeTetrominoEchange;


    // Initialisation du temps
    // On peut modifier les valeurs sur l'éditeur
    public float temps;
    public float tempsChute = 0.5f;
    private float _compteurTemps;


    private const int DistanceCarre = 50; // Distance entre chaque carré (espace de 3 entre chaque carré, donc 47 + 3)


    // Ici on va commencer à générer une liste de tétrominos grâce à la classe TetroGenerator
    // Utilisation de FILE ici, first in first out
    public void InitialiserTetromino()
    {
        _tetroGenerator = tetroGenerator.GetComponent<TetroGenerator>();

        _tetroGenerator.ListTetrominos = new Queue<TypeTetromino>(10); // création d'une file d'attente

        while (_tetroGenerator.ListTetrominos.Count < 10) // Génération d'au moins 10 tétrominos
        {
            _tetroGenerator.GenerateTetro();
        }

    }

    // Pour chaque cas, on instancie un tétromino de la file d'attente dans l'aire de jeu
    // La position sera la 5e case de la deuxième ligne du tableau (250, 1050)
    // Un par un
    public void UpdateTetromino()
    {
        GameObject clones = GameObject.FindWithTag("clone");
        if (clones == null)
        {
            
        
            //if (_shapeTetromino == null)

            //{

            _tetroGenerator.GenerateTetro();
            switch (_tetroGenerator.ListTetrominos.Dequeue()) // On défile
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
                    _shapeTetromino = Instantiate(TetroT, new Vector3(250, 1050, 0), Quaternion.identity);
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



    public void AGauche()
    {
        Debug.Log("Déplacement gauche");
        _shapeTetromino.transform.position += new Vector3(-1 * DistanceCarre, 0, 0);
        //transform.position += new Vector3(-50, 0, 0);
        if (!EstDedans()) // Si la nouvelle position est hors limite
        {
            _shapeTetromino.transform.position -=
                new Vector3(-1 * DistanceCarre, 0, 0); // Retourner à la position d'avant (aucun mouvement)
        }
    }

    public void ADroite()
    {
        Debug.Log("Déplacement droit");
        _shapeTetromino.transform.position += new Vector3(1 * DistanceCarre, 0, 0);
        //transform.position += new Vector3(50, 0, 0);

        if (!EstDedans()) // Si la nouvelle position est hors limite
        {
            _shapeTetromino.transform.position -=
                new Vector3(1 * DistanceCarre, 0, 0); // Retourner à la position d'avant (aucun mouvement)
        }

        /*if (EstEnCollision())
        {
            _shapeTetromino.transform.position -= new Vector3(1 * DistanceCarre, 0, 0);

        }*/
    }



    public void Descente()
    {
        float tempsMax = 1.0f;
        float tempsMaintenu = 0f;
        Debug.Log("Descente verticale plus rapide de la pièce");

        // Maintient bouton
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shapeTetromino.transform.position += new Vector3(0, -1 * DistanceCarre, 0);

            _compteurTemps = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.Space))
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
            _shapeTetromino.transform.position -=
                new Vector3(0, -1 * DistanceCarre, 0); // Retourner à la position d'avant (aucun mouvement)

        }
    }

    public void RotationGauche()
    {

        Debug.Log("Flèche haut appuyée : effectuer la rotation à gauche de la pièce de 90°");
        _shapeTetromino.transform.Rotate(0, 0, 90);

        if (!EstDedans()) // Si la nouvelle position est hors limite
        {
            _shapeTetromino.transform.Rotate(0, 0, -90); // Retourner à la position d'avant (aucun mouvement)

        }

    }

    public void RotationDroite()
    {

        Debug.Log("Flèche haut appuyée : effectuer la rotation à droite de la pièce de 90°");
        _shapeTetromino.transform.Rotate(0, 0, -90);

        if (!EstDedans()) // Si la nouvelle position est hors limite
        {
            _shapeTetromino.transform.Rotate(0, 0, 90); // Retourner à la position d'avant (aucun mouvement)

        }



    }

    public void Next()
    {
        GameObject tetroNext = GameObject.FindGameObjectWithTag("next");

        if (tetroNext == null)
        {
            switch (_tetroGenerator.ListTetrominos.Peek()) // On regarde le premier élément de la file sans la défiler
                                                        // On instancie le Tetrominos donné dans l'espace Next
            {

                case TypeTetromino.TetroI:
                    _shapeTetrominoNext = Instantiate(TetroI, new Vector3(669, 600, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";

                    break;
                case TypeTetromino.TetroJ:
                    _shapeTetrominoNext = Instantiate(TetroJ, new Vector3(669, 600, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";

                    break;
                case TypeTetromino.TetroL:
                    _shapeTetrominoNext = Instantiate(TetroL, new Vector3(669, 600, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";

                    break;
                case TypeTetromino.TetroO:
                    _shapeTetrominoNext = Instantiate(TetroO, new Vector3(669, 600, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";
                    
                    break;
                case TypeTetromino.TetroS:
                    _shapeTetrominoNext = Instantiate(TetroS, new Vector3(669, 600, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";
                    break;
                case TypeTetromino.TetroZ:
                    _shapeTetrominoNext = Instantiate(TetroZ, new Vector3(669, 600, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";
                    break;
                case TypeTetromino.TetroT:
                    _shapeTetrominoNext = Instantiate(TetroT, new Vector3(669, 600, 0), Quaternion.identity);
                    _shapeTetrominoNext.tag = "next";
                    break;

            }

        }
    }


   

    public void Next3()
    {
        GameObject tetroNext = GameObject.FindGameObjectWithTag("next");
    


        GameObject clones = GameObject.FindGameObjectWithTag("clone"); // On cherche les objets ayant pour tag "clones"

        GameObject _tetroNext = _shapeTetrominoNext;
        _tetroNext = Instantiate(_shapeTetrominoNext, new Vector3(669, 600, 0), Quaternion.identity);

        
        _tetroNext.tag = "next";
        

    }
    

    public void GenererEchange()
    {
        
        GameObject clones = GameObject.FindGameObjectWithTag("clone"); // On cherche les objets ayant pour tag "clone"
        GameObject nextGroupe = GameObject.FindGameObjectWithTag("next"); // On cherche les objets ayant pour tag "next"

        GameObject echangeGroupe = GameObject.FindGameObjectWithTag("EchangeGroupe"); // On cherche les objets ayant pour tag "EchangeGroupe"
        GameObject _tetroEchange = _shapeTetromino ;

        // S'il y a déjà un groupe d'échange : //
        
        /*  1. Détruire le groupe de Tétromino dans l'espace d'échange
         *  2. Placer le tétromino courant dans l'espace d'échange
         *  3. Instancier le tétromino précédemment stocké dans le champ de jeu
         *  4. Détruire le tétromino courant
         */
        
        if (echangeGroupe != null)  // S'il existe déjà un groupe d'échange
        {
            
            
            Destroy(echangeGroupe); // On détruit le Tétromino affiché dans Echange
            Debug.Log("echange groupe a été supprimé");
            
    
            // Instancier le tétromino courant dans l'espace d'échange
            // Donner le tag "EchangeGroupe" au groupe de Tétrominos stocké
            _tetroEchange = Instantiate(_shapeTetromino, new Vector3(669, 250, 0), Quaternion.identity);
            _tetroEchange.tag = "EchangeGroupe";
            
             
            GameObject _tetroEchange2 = echangeGroupe ;

           
            // Instancier le tétromino précédemment stocké dans le jeu
            // Donner le tag "clone" au groupe de Tétrominos courant
            _shapeTetromino = Instantiate(_tetroEchange2, new Vector3(250, 1050, 0), Quaternion.identity);
            _shapeTetromino.tag = "clone";
           
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
            
            // Instancier le tétromino précédemment stocké dans le jeu
            // Donner le tag "clone" au groupe de Tétrominos courant
            _shapeTetromino = Instantiate( _tetroEchange, new Vector3(669, 250, 0), Quaternion.identity);
            _shapeTetromino.tag = "EchangeGroupe";
            
            //Destroy(clones); // On détruit l'objet
            //Next();
            UpdateTetromino();

        }
    }


    public void Chute() // On décrémente de une case à chaque frame et selon la valeur du temps de chute 
    {
        GameObject clones = GameObject.FindWithTag("clone");
        //f (!(GameObject.FindWithTag("clone") == null )) // Seulement si il y a objet avec le tag "clone" (un tetromino dans le jeu)
        { 
            
            if (Time.time - temps > tempsChute)
            {

                _shapeTetromino.transform.position += new Vector3(0, -1 * DistanceCarre, 0);
                temps = Time.time;

                //PositionCarresCourrant();
                

                ///////// Collision non fonctionnelle  //////////


                if (!EstDedans()) // Si la pièce est sur la limite
                {
                    _shapeTetromino.transform.position -= new Vector3(0, -1 * DistanceCarre, 0); // Annuler la chute

                    _shapeTetromino.tag = "VerrouGroupe"; // Attribuer au groupe Tetromino placé (du prefab) le tag "VerrouGroupe"

                    foreach (Transform carre in _shapeTetromino.transform) // Pour chaque carré d'un Tetromino
                    {
                        GameObject.FindGameObjectsWithTag("Untagged"); // Rechercher les Objets (ici le groupe Prefab de nos Tetrominos) qui ont un tag "Untagged"

                        carre.tag = "Verrou"; // Attribuer à leur carré (donc à chaque enfants du prefab) le tag "Verrou"
                    }

                    PositionCarresVerrouilles();
                    
                    //Next3();
                    
                    
                    // Puisqu'on va passer à un nouveau Tetromino, détruire le groupe dans l'espace Next
                    GameObject nextGroupe = GameObject.FindGameObjectWithTag("next"); // On cherche les objets ayant pour tag "next"
                    Destroy(nextGroupe);
                    //Next();
                    
                    
                    //Verouiller();

                    UpdateTetromino(); // Après que les tags ont été attribués, générer un nouveau Tetromino et ainsi de suite
                }
                //PositionCarresVerrouilles();
            }
        }



    }



    public bool EstDedans()

    {
        //GameObject clones = GameObject.FindWithTag("clone"); 

        foreach (Transform carre in _shapeTetromino.transform) // Pour chaque carré d'un Tetromino
        {

            if (carre.transform.position.x > 500 || carre.transform.position.x < 50 || carre.transform.position.y < 100) // Le Tetro Courant n'est plus dans la zone si il y a un dépassement dans:
                // le mur gauche (x < 50), le mur droit (x>500) et le sol (y<100)
            {
                
                
                return false;
                
            }

            // Probleme : les carrés pensent qu'ils sont en collision a chaque descente
            /*if (carre.transform.position != PositionCarresVerrouilles())
            {
                return false;
            }*/

            /*if ((int) carre.transform.position.x != (int) GameObject.FindWithTag("Verrou").transform.position.x)
            {
                if ((int) carre.transform.position.y != (int) GameObject.FindWithTag("Verrou").transform.position.y)
                {
                    return false;
                }
                
                return false;
            }*/
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

    
    public Vector3 PositionCarresVerrouilles() // Montre dans la console la position de chaque carré qui ont été verouillés

    {
        
        var positionCarresVerrou = GameObject.FindWithTag("Verrou").transform.position;
        
        _positionVerrou = GameObject.FindGameObjectsWithTag("Verrou");
        Debug.Log(_positionVerrou.Length); // Nombre de carrés vérouillés
        
        
        // Pour chaque carrés ayant été vérouillés
        // Annoncer dans la console leur position
        // Les placer dans un seul et même groupe de Carrés vérouillés
        foreach (GameObject carre in _positionVerrou)
        {
            var positionCarre = carre.transform.position;
            Debug.Log("Position d'un carré bloqué:"+ positionCarre);
            
            carre.transform.SetParent(carresVerrouilles.transform); // Les carrés vérouillés on été placés ici
            

        }
        
        return positionCarresVerrou;
    }
    
    public void BloquerChampDeJeu()
    {
        _positionVerrou = GameObject.FindGameObjectsWithTag("Verrou");

        foreach (GameObject carre in _positionVerrou)
        {
            
            
            
            //_champDeJeu.Matrice[positionCarre] = carre;

        }

    }

    /*public bool EstEnCollision()
    {
        foreach (Transform carre in _shapeTetromino.transform) // Pour chaque carré d'un Tetromino

        {
            if (carre.position.y < 50 && _champDeJeu.Matrice[(int) carre.transform.position.x, (int) carre.transform.position.y] != null)
            {
                return true;
            }
        }

        return false;

        ////// Tests //////

        /*int abscisses = 0f;
        int ordonnes = 0f;
        Transform[,] positions = new Transform[abscisses,ordonnes];
        
        
     
        foreach (Transform carre in _shapeTetromino.transform)
        {
            float x = carre.position.x;
            if (positions[(int)carre.position.x,(int)carre.position.y] = GameObject.FindGameObjectWithTag("Verrou")).position[x]
            {
                Debug.Log("On a trouvé la collision!");
                return true;
            }
        }* /
        foreach (Transform carre in _shapeTetromino.transform)
        {
            if (_champDeJeu.Matrice[(int) carre.transform.position.x, (int) carre.transform.position.y] == null)
            {
                return true;
            }
        }
        
        /*foreach (Transform carre in _shapeTetromino.transform)
        {
            
            if (carre.transform.localPosition.x.Equals(GameObject.FindGameObjectWithTag("Verrou").transform.localPosition.x) && carre.transform.localPosition.y.Equals(GameObject.FindGameObjectWithTag("Verrou").transform.localPosition.y)  )
            {
                Debug.Log("Collision??????!!!!!!!!!!!!!!!!!!!!!!");
                _shapeTetromino.transform.position -= new Vector3(0, -1 * DistanceCarre, 0); // Annuler la chute

                
                return true;
            }
        }
        
        foreach (Transform carre in _shapeTetromino.transform)
        {
            GameObject.FindWithTag("Verrou");
            
        }* /

        return false;


        
    }
    }*/
}
        
