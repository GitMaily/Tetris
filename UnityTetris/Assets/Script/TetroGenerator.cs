using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script
{
    public class TetroGenerator : MonoBehaviour
    {
        
        private Queue<TypeTetromino> _listTetrominos;

        public Queue<TypeTetromino> ListTetrominos
        {
            get => _listTetrominos;
            set => _listTetrominos = value;
        }
        
        public void GenerateTetro()
        {
            
            _listTetrominos.Enqueue(RandomTetro());
        }

        private TypeTetromino RandomTetro()
        {
            List<bool> boxBool = new List<bool>
            {
                true,
                true,
                true,
                false,
                false
            };
            List<TypeTetromino> boxTetrominos = new List<TypeTetromino>
            {
                TypeTetromino.TetroI,       // Posibilité TetroI = 4 / 23 = 0.174
                TypeTetromino.TetroI,
                TypeTetromino.TetroI,
                TypeTetromino.TetroI,
                TypeTetromino.TetroJ,       // Posibilité TetroJ = 3 / 23 = 0.130
                TypeTetromino.TetroJ,
                TypeTetromino.TetroJ,
                TypeTetromino.TetroL,       // Posibilité TetroL = 3 / 23 = 0.130
                TypeTetromino.TetroL,
                TypeTetromino.TetroL,
                TypeTetromino.TetroO,       // Posibilité TetroO = 3 / 23 = 0.130
                TypeTetromino.TetroO,
                TypeTetromino.TetroO,
                TypeTetromino.TetroS,       // Posibilité TetroS = 3 / 23 = 0.130
                TypeTetromino.TetroS,
                TypeTetromino.TetroS,
                TypeTetromino.TetroT,       // Posibilité TetroT = 4 / 23 = 0.174
                TypeTetromino.TetroT,
                TypeTetromino.TetroT,
                TypeTetromino.TetroT,
                TypeTetromino.TetroZ,       // Posibilité TetroZ = 3 / 23 = 0.130
                TypeTetromino.TetroZ,
                TypeTetromino.TetroZ
            };

            TypeTetromino typeTetromino = boxTetrominos[Random.Range(0, boxTetrominos.Count)];
            if (_listTetrominos.Count > 1 && 
                typeTetromino == _listTetrominos.ToArray()[_listTetrominos.Count - 1] && 
                boxBool[Random.Range(0, boxBool.Count)])
            {
                typeTetromino = boxTetrominos[Random.Range(0, boxTetrominos.Count)];
            }

            return typeTetromino;
        }
    }
    
    
    
}

