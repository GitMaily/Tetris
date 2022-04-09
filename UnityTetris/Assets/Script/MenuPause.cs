using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

namespace Script
{
    public class MenuPause : MonoBehaviour
    {
        public GameObject MenuPauseUI;


        public static bool _estPause;
        //private GameObject menuPause;

        public void Pause()
        {
            if (_estPause)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1;

            }
        }

        public void Reprendre()
        {
            MenuPauseUI.SetActive(false);
            Time.timeScale = 1f;
            _estPause = false;
        }

        

        // Quitter la partie : retourner au menu principal
        public void Quitter()
        {
            _estPause = false;
            Reprendre();
            SceneManager.LoadScene("MenuPrincipal");
        }

        // On va charger une nouvelle partie
        public void Recommencer()
        {
            _estPause = false;
            Reprendre();
            SceneManager.LoadScene("ChampDuJeu");
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        /*void Update()
        {
            if (_pause)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Time.timeScale = 0;
                    _pause = false;
                    menuPause.SetActive(true);
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        Time.timeScale = 1;
                        _pause = true;
                        menuPause.SetActive(false);
                    }
    
                }
            }
    
        }*/
    }
}