using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script
{
    public class GameOver : MonoBehaviour
    {
        public GameObject gameOverUI;

        private MenuPause _menuPause;

        private Score score;


        public void GamePerdu()
        {
            //MenuPause._estPause = true;

            gameOverUI.SetActive(true);

        }

        public void Reprendre()
        {
            gameOverUI.SetActive(false);
            Time.timeScale = 1f;
            MenuPause._estPause = false;
        }

        public void ButtonRejouer()
        {
            MenuPause._estPause = false;
            Reprendre();

            SceneManager.LoadScene("ChampDuJeu");
        }

        public void ButtonQuitter()
        {
            Reprendre();
            SceneManager.LoadScene("MenuPrincipal");
            Debug.Log("Quitter le jeu.");
        }

        
    }
}