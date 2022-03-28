using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Script
{
    public class Collision: MonoBehaviour
    {
        public static int largeur = 10;
        public static int hauteur = 20;

        private static Transform[,] epspace = new Transform[largeur, hauteur];

        private void ChampDuJ()
        {
            foreach (Transform block in transform)
            {
                int X = Mathf.RoundToInt(block.transform.position.x);
                int Y = Mathf.RoundToInt(block.transform.position.y);

                epspace[X, Y] = block;
                
             

            }
            


        }

        

        
        
        bool CollisionZone
        {
            get
            {
                foreach (Transform block in transform)
                {
                    int x = Mathf.RoundToInt(block.position.x);
                    int y = Mathf.RoundToInt(block.position.y);

                    if (x < 0 || x >= largeur || y < 0 || y >= hauteur || epspace[x, y] != null)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}