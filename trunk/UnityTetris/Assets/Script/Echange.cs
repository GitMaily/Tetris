using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Script
{
    public class Echange : MonoBehaviour
    {
        //private GameObject _clone;
        public GameObject genererEchange; 
        //public GameObject clone;
        private GenerateurTetro _generateur;
        private void Update()
        {
            _generateur = genererEchange.GetComponent<GenerateurTetro>();
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                
                _generateur.GenererEchange();
                //clone.tag = "clone";
                
                var clones = GameObject.FindGameObjectsWithTag ("clone");

                foreach (var clone in clones)
                {
                    Destroy(clone);
                }
            }
        }

        
        public void Stocker()
        {
            Debug.Log("On veut stocker la pièce courante dans l'espace d'échange");
            Destroy(gameObject);
        }
    }
}