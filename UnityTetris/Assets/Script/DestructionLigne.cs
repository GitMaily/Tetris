using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Script
{
    public class DestructionLigne : MonoBehaviour
    {
        
        public GameObject tetroCourrant;
        private TetroCourrant _tetroCourrant;
        
        private GameObject[] _positionVerrou;

        public GameObject champDeJeu;
        private EcranPrincipal _champDeJeu;
        
    
        public void Initialiser()
        {
            _tetroCourrant = tetroCourrant.GetComponent<TetroCourrant>();
            _champDeJeu = champDeJeu.GetComponent<EcranPrincipal>();

        }


        /// <summary>
        /// Détermine si une ligne est complète.
        /// </summary>
        /// <param name="y">La position y du champ de jeu.</param>
        /// <returns>
        /// Vrai si une ligne est complète.
        /// Faux sinon.
        /// </returns>
        public bool LigneEstComplete(int y)
        {
            _positionVerrou = GameObject.FindGameObjectsWithTag("Verrou");
            //bool complet = true;

            for (int i = 50; i <= 500; i++) // Pour chaque colonne i de la Matrice
            {
                if (i % 50 == 0) // Le champ de jeu ne possède des objets qu'à chaque modulo 50.
                                 // C'est parce que la distance entre chaque carrés est de 50.
                {
                    //Debug.Log(i);
                    if (_champDeJeu.Matrice[i, y] == null) // Pour chaque colonne i de la Matrice de la ligne y, retourner faux s'il n'y a aucun objet.
                    {
                        return false;
                    }
                }
            }
            Debug.Log("Une ligne est complete");
            return true;
        }
        
        /// <summary>
        /// Détruit une ligne assignée.
        /// </summary>
        /// <param name="y">Position y de la ligne à détruire.</param>
        public void DetruireLigne(int y)
        {
            for (int i = 50; i <= 500; i++) 
            {
                if (i % 50 == 0){ // Le champ de jeu ne possède des objets qu'à chaque modulo 50.
                                  // C'est parce que la distance entre chaque carrés est de 50.
                    
                    Destroy(_champDeJeu.Matrice[i, y].gameObject); // Pour chaque colonne i de la Matrice, détruire l'objet de la ligne y.
                    
                }
            }
        }

        public void DescenteLignes()
        {
            
        }

        /// <summary>
        /// Détruit une ligne si elle est complète, puis fait descendre les carrés du dessus.
        /// </summary>
        public void Ligne()
        {
            for(int y = 0;y<1100;y++)
            {
                
                if (LigneEstComplete(y))
                {
                    Debug.Log("Une ligne est complete");

                    DetruireLigne(y);
                    DescenteLignes();
                    
                }
            }
        }
        
        
    }
}
