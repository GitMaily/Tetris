using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    
    public class MenuPrincipal : MonoBehaviour
    {

        public GameObject creditsUI;
        
        //public string partieCharger;
        public string newPartie;
        //Commencer une partie
        public void StartGame()
        {
            MenuSauvegarde.NumeroSauvegarde = 0;

            SceneManager.LoadScene("ChampDuJeu");
        }
        
        //Charger une partie
        public void LoadSave()
        {
            
            SceneManager.LoadScene("ListeSauvegarde");

        }

 
       
        //Quitter l'application
        public void QuitGame()
        {
            Application.Quit();
        }
        
        //Afficher les crédits
        public void Credits()
        {
            creditsUI.SetActive(true);
        }

        public void QuitterCredits()
        {
            creditsUI.SetActive(false);
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}