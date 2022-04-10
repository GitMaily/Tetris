using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    
    public class MenuPrincipal : MonoBehaviour
    {

        //public string partieCharger;
        public string newPartie;
        //Commencer une partie
        public void StartGame()
        {
            Debug.Log("Une nouvelle partie a été lancée");
            SceneManager.LoadScene("ChampDuJeu");
        }
        
        //Charger une partie
        public void LoadSave()
        {
            
            //string json = File.ReadAllText(Application.dataPath + "/" + filename);
            
            
            
            //new SceneLoadInfo();
            //SceneManager.LoadScene("ListeSauvegarde");

            
            
            SceneManager.LoadScene("ChampDuJeu");
            //return JsonUtility.FromJson<Sauvegarde>(json);

        }

        public void ChargerPartie(string filename)
        {
            //LoadSave("sauvegarde1.json");
        }
        
        //Quitter l'application

        public void QuitGame()
        {
            Application.Quit();
        }
        
        //Afficher les crédits

        public void Credits()
        {
            SceneManager.LoadScene("Credits");
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