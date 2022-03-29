using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class ChargerSauvegarde : MonoBehaviour
{
    private Sauvegarder fichier;

    public ChargerSauvegarde()
    {
        fichier = null;
    }
    
    /* A FINIR */
    public void ChargerUneSauvegarde()
    {
        if (!File.Exists("GameSave.bin")) return;

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream("GameSave.bin", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
        fichier = (Sauvegarder)formatter.Deserialize(stream);
        stream.Close();
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
