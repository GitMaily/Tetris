using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Serialization;


namespace Script
{
    [Serializable] 
    public class Sauvegarde
    {
        
        //public Transform[,] Matrice;
        public int score;
        public  float energie;
        public List<TypeTetromino> listTetromino;
        public TypeTetromino typeTetrominoEchange;
        public bool hasTetroEchange;
        
        public Sauvegarde()
        {
            //Matrice = new Transform[550, 1151];
            score = 0;
            energie = 0.0f;
            listTetromino = new List<TypeTetromino>(10);
            typeTetrominoEchange = TypeTetromino.Null;
            hasTetroEchange = false;
        }
    }
}
