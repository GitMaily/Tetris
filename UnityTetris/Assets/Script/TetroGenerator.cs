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
            List<bool> boxBool = new List<bool>();
            for (int i = 0; i < 15; i++)
                boxBool.Add(true);
            
            for (int i = 0; i < 1; i++)
                boxBool.Add(false);

            List<TypeTetromino> boxTetrominos = new List<TypeTetromino>();
            for (int i = 0; i < 4; i++)
                boxTetrominos.Add(TypeTetromino.TetroI);    // Possibilité de TétrominoI = 4 / 23 = 0.174
            
            for (int i = 0; i < 3; i++)
                boxTetrominos.Add(TypeTetromino.TetroJ);    // Possibilité de TétrominoJ = 3 / 23 = 0.130
            
            for (int i = 0; i < 3; i++)
                boxTetrominos.Add(TypeTetromino.TetroL);    // Possibilité de TétrominoL = 3 / 23 = 0.130
            
            for (int i = 0; i < 3; i++)
                boxTetrominos.Add(TypeTetromino.TetroO);    // Possibilité de TétrominoO = 3 / 23 = 0.130
            
            for (int i = 0; i < 3; i++)
                boxTetrominos.Add(TypeTetromino.TetroS);    // Possibilité de TétrominoS = 3 / 23 = 0.130
            
            for (int i = 0; i < 4; i++)
                boxTetrominos.Add(TypeTetromino.TetroT);    // Possibilité de TétrominoT = 4 / 23 = 0.174
            
            for (int i = 0; i < 3; i++)
                boxTetrominos.Add(TypeTetromino.TetroZ);    // Possibilité de TétrominoZ = 3 / 23 = 0.130

            TypeTetromino typeTetromino = boxTetrominos[Random.Range(0, boxTetrominos.Count)];
            if (_listTetrominos.Count > 1 && 
                typeTetromino == _listTetrominos.ToArray()[_listTetrominos.Count - 1] && 
                boxBool[Random.Range(0, boxBool.Count)])      // Possibilité avoir deux tétrominos de même type succesivement = 0.2
            {
                typeTetromino = boxTetrominos[Random.Range(0, boxTetrominos.Count)];
            }

            return typeTetromino;
        }
    }
    
    
    
}

