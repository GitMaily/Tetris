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


        public GameObject carresVerrouilles;
        public GameObject[] listeCarresVerrouilles;
        public GameObject[] listeCarresBonusVerrouilles;
        public List<String> nomCarre;
        public List<Vector3> listePositionCarresBonus;
        public List<Vector3> listePositionCarres;

        public Sauvegarde()
        {
            //Matrice = new Transform[550, 1151];
            score = 0;
            energie = 0.0f;
            listTetromino = new List<TypeTetromino>(10);
            typeTetrominoEchange = TypeTetromino.Null;
            hasTetroEchange = false;

            nomCarre = new List<string>();
            listePositionCarresBonus = new List<Vector3>();
            listePositionCarres = new List<Vector3>();
            
            carresVerrouilles = null;
            listeCarresVerrouilles = null;
            listeCarresBonusVerrouilles = null;

        }
    }
}
