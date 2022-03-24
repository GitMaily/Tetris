using System;
using System.Collections;
using System.Collections.Generic;
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
            _listTetrominos.Enqueue((TypeTetromino) Random.Range(0,7));
        }
    }
    
}

