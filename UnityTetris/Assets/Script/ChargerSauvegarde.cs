using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Script
{
    public class ChargerSauvegarde : MonoBehaviour
    {
        private Sauvegarde fichier;

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
            fichier = (Sauvegarde) formatter.Deserialize(stream);
            stream.Close();
        }
    }
}
