using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Script
{
    public class BoutonsBis : MonoBehaviour
    {
        public GameObject tetroCourrant;

        private TetroCourrant _tetroCourrant;

        public void Initialiser()
        {
            _tetroCourrant = tetroCourrant.GetComponent<TetroCourrant>();
        }

        public void BoutonCheck()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _tetroCourrant.ADroite();
            }
            
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _tetroCourrant.AGauche();
            }
        }
        
        
        public void BoutonEspace() // Descente
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                _tetroCourrant.Descente();
            }
                
        }
        public void BoutonHaut() // Rotation gauche
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            { 
               _tetroCourrant.RotationGauche();
            }
                
        }
            
        public void BoutonBas() // Rotation droite
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _tetroCourrant.RotationDroite();
            }
        }
        
        public void Tabulation() // Echange
        {
            if (Input.GetKeyDown(KeyCode.Tab ) || Input.GetKeyUp(KeyCode.Tab)) // Pour éviter d'appuyer sur tab 2 fois
            // Problème : si on maintient la touche appuyée, aucun tetromino n'est généré
            // Problème mineur, à corriger si on a le temps
            {
                
                Debug.Log("Tabulation appuyée, chargée dans boutons.bis");
                _tetroCourrant.GenererEchange();

            }

           
        }

        public void Echap() // Pause
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Partie mise en pause : chargement du menu de pause");
                SceneManager.LoadScene("MenuPause");
            }
        }

    }
}