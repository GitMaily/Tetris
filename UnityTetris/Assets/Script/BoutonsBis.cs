using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Script
{
    public class BoutonsBis : MonoBehaviour
    {
        private GameObject _shapeTetromino;
        private const int DistanceCarre = 50; // Distance entre chaque carré (espace de 3 entre chaque carré, donc 47 + 3)


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
           
            if (Input.GetKeyDown(KeyCode.S))
            {
                _tetroCourrant.Descente();
            }
                
        }
        public void BoutonHaut() // Rotation droite
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            { 
               _tetroCourrant.RotationDroite();
            }
                
        }
            
        public void BoutonBas() // Rotation gauche
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _tetroCourrant.RotationGauche();
            }
        }
        
        public void Tabulation() // Echange
        {
            if (Input.GetKeyDown(KeyCode.Tab )) // Problème d'échange avec 2* Tab résolus
            {
                _tetroCourrant.Next();

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