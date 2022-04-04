using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOver gameOver;

    public void GamePerdu()
    {
        gameOverUI.SetActive(true); 
    }

    public void ButtonRejouer()
    {
        SceneManager.LoadScene("ChampDuJeu");
    }

    public void ButtonQuitter()
    {
        SceneManager.LoadScene("MenuPrincipal");
        Debug.Log("Quitter le jeu.");
    }
}
