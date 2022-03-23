using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        //new SceneLoadInfo();
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
