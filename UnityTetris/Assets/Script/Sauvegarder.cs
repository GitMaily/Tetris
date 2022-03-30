using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


namespace Script
{
    [Serializable]
    public class Sauvegarder
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
            Stream stream = new FileStream("GameSave.bin", FileMode.Create, FileAccess.Write, FileShare.None); /* problème */
            Debug.Log("Création du fichier");
            formatter.Serialize(stream, fichier); /* problème */
            Debug.Log("Sérialisation");
            stream.Close();
        
            Debug.Log("Sauvegarde réussi");
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
}
