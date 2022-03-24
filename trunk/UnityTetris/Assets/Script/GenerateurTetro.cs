using UnityEngine;
using System.Collections;

namespace Script
{
    public class GenerateurTetro : MonoBehaviour

    {
        public GameObject[] tetrominos;
        public GameObject clone;

        //public Vector3Int spawnPosition;
        
        
        public void Generer() {
            // Choisi un tetromino aléatoire (entre le premier élément de la liste jusqu'au dernier)
            // Les prefabs des tetrominos ont été insérés un par un dans l'objet, ce qui donne un tableau de 0 à 6
            int i = Random.Range(0, tetrominos.Length);

            // Génère un tetromino 
            clone = Instantiate(tetrominos[i], transform.position, Quaternion.identity);


            
        }

        public void GenererEchange()
        {
            Debug.Log("Tabulation appuyée: génération d'un nouveau tétromino");
            Generer();
            
            
        }
        //Il faut générer un premier tetromino au début d'une partie
        void Start()
        {

            Generer();
            clone.tag = "clone";
            /*if (Boutons.Tabulation())
            {
                GenererEchange();
            }*/
        }
    }
}