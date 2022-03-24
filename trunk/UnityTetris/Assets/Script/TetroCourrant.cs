using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

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
    
    public GameObject tetroGenerator;
    private TetroGenerator _tetroGenerator;

    public GameObject _shapeTetromino;
    
    // Initialisation du temps
    // On peut modifier les valeurs sur l'éditeur
    public float temps;
    public float tempsChute = 0.5f;

    
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
        if (_shapeTetromino == null)
        {
            switch (_tetroGenerator.ListTetrominos.Dequeue())
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
                case TypeTetromino.TetroO: // Le Tetro O est particulier, son millieu ne contenant pas de carré, il a fallut décaler de (25,-25)
                    _shapeTetromino = Instantiate(TetroO, new Vector3(275, 1025, 0), Quaternion.identity);
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
        }
        
        if (_tetroGenerator.ListTetrominos.Count < 10)
        {
            _tetroGenerator.GenerateTetro();
        }
    }
    
    public void AGauche()
    {
        Debug.Log("Déplacement gauche");
        _shapeTetromino.transform.position += new Vector3(-1 * DistanceCarre, 0, 0);
        //transform.position += new Vector3(-50, 0, 0);
    }
           
    public void ADroite()
    {
        Debug.Log("Déplacement droit");
        _shapeTetromino.transform.position += new Vector3(1 * DistanceCarre, 0, 0);
        //transform.position += new Vector3(50, 0, 0);
    
    }
           
    public void Descente()
    {
        Debug.Log("Descente verticale plus rapide de la pièce");
        _shapeTetromino.transform.position += new Vector3(0, -1 * DistanceCarre, 0);
        //transform.position += new Vector3(0, -50, 0);
    }
            
    public void RotationGauche()
    {
        
        Debug.Log("Flèche haut appuyée : effectuer la rotation à gauche de la pièce de 90°"); 
        _shapeTetromino.transform.Rotate(0,0,90);
                
    }
            
    public void RotationDroite()
    {
        
        Debug.Log("Flèche haut appuyée : effectuer la rotation à droite de la pièce de 90°"); 
        _shapeTetromino.transform.Rotate(0,0,-90);
        

    }
    // méthode pour implémenter le stockage eventuellement
    public void Echanger()
    {
        UpdateTetromino();
        Debug.Log("tab appuyée de tetroCourrant");
    }
    
    public void GenererEchange() // Génère un nouveau Tetro en appuyant sur Tab
    // Penser à implémenter le stockage
    {
        
        _tetroGenerator.GenerateTetro(); // On génère un nouveau Tetro
        GameObject clones = GameObject.FindGameObjectWithTag ("clone"); // On cherche les objets ayant pour tag "clones"
        
        Destroy(clones); // On détruit l'objet
        UpdateTetromino(); // On relance l'instanciation


    }
    public void Chute() // On décrémente de une case à chaque frame et selon la valeur du temps de chute 
    {
        if (!(GameObject.FindWithTag("clone") == null)) // Seulement si il y a objet avec le tag "clone" (un tetromino dans le jeu)
        {
            if (Time.time - temps > tempsChute)
            {
                _shapeTetromino.transform.position += new Vector3(0, -1 * DistanceCarre, 0);
                temps = Time.time;
            }
        }
        
    }
}
        
