using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    bool pause=true ;
    public GameObject Canvas;

    public void Reprendre()
    {
        
        SceneManager.LoadScene("MenuPause");
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
        if (pause == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Time.timeScale = 0;
                pause = false;
                Canvas.SetActive(true);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Time.timeScale = 1;
                    pause = true;
                    Canvas.SetActive(false);
                }

            }
        }

    }
}
