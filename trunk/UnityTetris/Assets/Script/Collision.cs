using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Script
{
    public class Collision
    {
        public static int largeur = 10;
        public static int hauteur = 20;

        private static Transform[,] epspace = new Transform[largeur, hauteur];

        void nouvGrille()
        {
            foreach (Transform block in Transform)
            {
                int roundedX = Mathf.RoundToInt(block.transform.position.x);
                int roundedY = Mathf.RoundToInt(block.transform.position.y);

                epspace[roundedX, roundedY] = block;

            }
            


        }

        void CollisionZone()
        {
            foreach (Transform block in Transform)
            {
                int abscisseX = Mathf.RoundToInt(block.transform.position.x);
                int ordonneY = Mathf.RoundToInt(block.transform.position.y);

                if (abscisseX < 0 || abscisseX >= largeur || ordonneY < 0 || ordonneY >= hauteur)
                {
                    return false;
                }
                return true;

            }
        }
    }
}