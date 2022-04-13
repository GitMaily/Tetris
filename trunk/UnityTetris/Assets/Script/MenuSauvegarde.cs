using System.Collections;
using System.Collections.Generic;
using System.IO;
using Script;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

namespace Script
{
    

    public class MenuSauvegarde : MonoBehaviour
    {
        
        public static int NumeroSauvegarde = 0;

        
        
        public GameObject save1UI;
        public GameObject save2UI;
        public GameObject save3UI;
        public GameObject save4UI;
        public GameObject save5UI;
        public GameObject save6UI;
        public GameObject save7UI;
        public GameObject save8UI;


        public static bool sauvegarde1 = false;
        public static bool sauvegarde2 = false;
        public static bool sauvegarde3 = false;
        public static bool sauvegarde4 = false;
        public static bool sauvegarde5 = false;
        public static bool sauvegarde6 = false;
        public static bool sauvegarde7 = false;
        public static bool sauvegarde8 = false;



        /// <summary>
        /// Active le bouton associé à la sauvegarde si le fichier existe.
        /// </summary>
        #region SetActive
        
        public void ShowSauvegarde1()
        {
            if (File.Exists(Application.dataPath + "/" + "sauvegarde1.json"))
            {
                sauvegarde1 = true;
                save1UI.SetActive(true);

            }
        }
        public void ShowSauvegarde2()
        {
            if (File.Exists(Application.dataPath + "/" + "sauvegarde2.json"))
            {
                sauvegarde2 = true;
                save2UI.SetActive(true);

            }
        }

        public void ShowSauvegarde3()
        {
            if (File.Exists(Application.dataPath + "/" + "sauvegarde3.json"))
            {  
                sauvegarde3 = true;
                save3UI.SetActive(true);

            }
        }

        public void ShowSauvegarde4()
        {
            if (File.Exists(Application.dataPath + "/" + "sauvegarde4.json"))
            {  
                sauvegarde4 = true;
                save4UI.SetActive(true);

            }
        }

        public void ShowSauvegarde5()
        {
            if (File.Exists(Application.dataPath + "/" + "sauvegarde5.json"))
            {  
                sauvegarde5 = true;
                save5UI.SetActive(true);

            }
        }

        public void ShowSauvegarde6()
        {
            if (File.Exists(Application.dataPath + "/" + "sauvegarde6.json"))
            {  
                sauvegarde6 = true;
                save6UI.SetActive(true);

            }
        }

        public void ShowSauvegarde7()
        {
            if (File.Exists(Application.dataPath + "/" + "sauvegarde7.json"))
            {  
                sauvegarde7 = true;
                save7UI.SetActive(true);

            }
        }

        public void ShowSauvegarde8()
        {
            if (File.Exists(Application.dataPath + "/" + "sauvegarde8.json"))
            {  
                sauvegarde8 = true;
                save8UI.SetActive(true);

            }
        }

        #endregion SetActive

        /// <summary>
        /// Permet le chargement des sauvegardes et attribue une valeur selon le numero de la sauvegarde.
        /// </summary>
        #region Sauvegardes

        public void Sauvegarde1()
        {

            NumeroSauvegarde = 1;
            SceneManager.LoadScene("ChampDuJeu");
        }
        public void Sauvegarde2()
        {

            NumeroSauvegarde = 2;
            SceneManager.LoadScene("ChampDuJeu");
        }
        public void Sauvegarde3()
        {

            NumeroSauvegarde = 3;
            SceneManager.LoadScene("ChampDuJeu");
        }
        public void Sauvegarde4()
        {

            NumeroSauvegarde = 4;
            SceneManager.LoadScene("ChampDuJeu");
        }
        public void Sauvegarde5()
        {

            NumeroSauvegarde = 5;
            SceneManager.LoadScene("ChampDuJeu");
        }
        public void Sauvegarde6()
        {

            NumeroSauvegarde = 6;
            SceneManager.LoadScene("ChampDuJeu");
        }
        public void Sauvegarde7()
        {

            NumeroSauvegarde = 7;
            SceneManager.LoadScene("ChampDuJeu");
        }
        public void Sauvegarde8()
        {

            NumeroSauvegarde = 8;
            SceneManager.LoadScene("ChampDuJeu");
        }
        #endregion Sauvegardes


        public void Retour()
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
            ShowSauvegarde1();
            ShowSauvegarde2();
            ShowSauvegarde3();
            ShowSauvegarde4();
            ShowSauvegarde5();
            ShowSauvegarde6();
            ShowSauvegarde7();
            ShowSauvegarde8();

        }
    }
}