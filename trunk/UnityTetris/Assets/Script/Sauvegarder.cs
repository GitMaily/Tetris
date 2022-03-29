using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class Sauvegarder : MonoBehaviour
{
    private int score;

    public Sauvegarder()
    {
        score = 0;
    }
    
    public void Sauvegarde()
    {
        Sauvegarder fichier = new Sauvegarder();
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream("GameSave.bin", FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, fichier);
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
