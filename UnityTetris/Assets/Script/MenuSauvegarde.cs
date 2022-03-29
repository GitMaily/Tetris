using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MenuSauvegarde : MonoBehaviour
{
    private bool sauvegarde1;
    private bool sauvegarde2;
    private bool sauvegarde3;
    private bool sauvegarde4;
    private bool sauvegarde5;
    private bool sauvegarde6;
    private bool sauvegarde7;
    private bool sauvegarde8;

    public MenuSauvegarde()
    {
        sauvegarde1 = false;
        sauvegarde2 = false;
        sauvegarde3 = false;
        sauvegarde4 = false;
        sauvegarde5 = false;
        sauvegarde6 = false;
        sauvegarde7 = false;
        sauvegarde8 = false;
    }

    public void Sauvegardes()
    {
        MenuSauvegarde sauvegardes = new MenuSauvegarde();
        
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (!sauvegarde1)
            {
                Sauvegarder fichier = new Sauvegarder();
                fichier.Sauvegarde();
            }
            else
            {
                ChargerSauvegarde fichiercharge = new ChargerSauvegarde();
                fichiercharge.ChargerUneSauvegarde();
            }
        }else if (Input.GetKeyDown(KeyCode.F2))
        {
            if (!sauvegarde2)
            {
                Sauvegarder fichier = new Sauvegarder();
                fichier.Sauvegarde();
            }
            else
            {
                ChargerSauvegarde fichiercharge = new ChargerSauvegarde();
                fichiercharge.ChargerUneSauvegarde();
            }
        }else if (Input.GetKeyDown(KeyCode.F3))
        {
            if (!sauvegarde3)
            {
                Sauvegarder fichier = new Sauvegarder();
                fichier.Sauvegarde();
            }
            else
            {
                ChargerSauvegarde fichiercharge = new ChargerSauvegarde();
                fichiercharge.ChargerUneSauvegarde();
            }
        }else if (Input.GetKeyDown(KeyCode.F4))
        {
            if (!sauvegarde4)
            {
                Sauvegarder fichier = new Sauvegarder();
                fichier.Sauvegarde();
            }
            else
            {
                ChargerSauvegarde fichiercharge = new ChargerSauvegarde();
                fichiercharge.ChargerUneSauvegarde();
            }
        }else if (Input.GetKeyDown(KeyCode.F5))
        {
            if (!sauvegarde5)
            {
                Sauvegarder fichier = new Sauvegarder();
                fichier.Sauvegarde();
            }
            else
            {
                ChargerSauvegarde fichiercharge = new ChargerSauvegarde();
                fichiercharge.ChargerUneSauvegarde();
            }
        }else if (Input.GetKeyDown(KeyCode.F6))
        {
            if (!sauvegarde6)
            {
                Sauvegarder fichier = new Sauvegarder();
                fichier.Sauvegarde();
            }
            else
            {
                ChargerSauvegarde fichiercharge = new ChargerSauvegarde();
                fichiercharge.ChargerUneSauvegarde();
            }
        }else if (Input.GetKeyDown(KeyCode.F7))
        {
            if (!sauvegarde7)
            {
                Sauvegarder fichier = new Sauvegarder();
                fichier.Sauvegarde();
            }
            else
            {
                ChargerSauvegarde fichiercharge = new ChargerSauvegarde();
                fichiercharge.ChargerUneSauvegarde();
            }
        }else if (Input.GetKeyDown(KeyCode.F8))
        {
            if (!sauvegarde8)
            {
                Sauvegarder fichier = new Sauvegarder();
                fichier.Sauvegarde();
            }
            else
            {
                ChargerSauvegarde fichiercharge = new ChargerSauvegarde();
                fichiercharge.ChargerUneSauvegarde();
            }
        }
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
