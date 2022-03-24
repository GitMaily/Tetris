using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{

    public void Reprendre()
    {
        
    }

    
    public void Sauvegarder()
    {
        
    }

    // Quitter la partie : retourner au menu principal
    public void Quitter()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    // On va charger une nouvelle partie
    public void Recommencer()
    {
        SceneManager.LoadScene("SampleScene");
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
