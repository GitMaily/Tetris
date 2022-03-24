using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Script
{
    public class Mouvement : MonoBehaviour
    {
        public float temps;
        public float tempsChute = 0.5f;
        
        public void AGauche()
        {
            Debug.Log("Déplacement gauche");
            transform.position += new Vector3(-1, 0, 0);
            //transform.position += new Vector3(-50, 0, 0);
        }
        public void ADroite()
        {
            Debug.Log("Déplacement droit");
            transform.position += new Vector3(1, 0, 0);
            //transform.position += new Vector3(50, 0, 0);

        }
        public void Descente()
        {
            Debug.Log("Descente verticale plus rapide de la pièce");
            transform.position += new Vector3(0, -1, 0);
            //transform.position += new Vector3(0, -50, 0);

        }
        
        public void RotationGauche()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {   
                Debug.Log("Flèche haut appuyée : effectuer la rotation à gauche de la pièce de 90°");
                transform.Rotate(0, 0, -90);
            }
            
        }
        
        public void RotationDroite()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {   
                Debug.Log("Flèche haut appuyée : effectuer la rotation à droite de la pièce de 90°");
                transform.Rotate(0, 0, 90);
            }
            
        }

        public void Chute()
        {
            if (Time.time - temps > tempsChute)
            {
                transform.position += new Vector3(0, -1, 0);
                temps = Time.time;
            }
        }
        
    }
}