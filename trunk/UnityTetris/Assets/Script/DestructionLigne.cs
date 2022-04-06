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


        public int totalLignesDetruites;
        public int lignesDetruitesEchange;
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
                                 // C'est parce que la distance entre chaque carré est de 50.
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
                if (i % 50 == 0)  // Le champ de jeu ne possède des objets qu'à chaque modulo 50.
                    // C'est parce que la distance entre chaque carré est de 50.
                {
                    Destroy(_champDeJeu.Matrice[i, y].gameObject); // Pour chaque colonne i de la Matrice, détruire l'objet de la ligne y.

                }
            }
        }

        public void DescenteLignes(int ligne)
        {
            for (int y = ligne; y < 1100 - 50; y++)
            {
                for (int x = 0; x <= 500; x++)
                {
                   
                    if (_champDeJeu.Matrice[x, y +50] != null)
                    {
                        _champDeJeu.Matrice[x, y] = _champDeJeu.Matrice[x, y + 50];
                       
                        _champDeJeu.Matrice[x, y + 50] = null;
                        _champDeJeu.Matrice[x, y].gameObject.transform.position +=new Vector3(0,-1*50,0);
                        
                        
                    }
                }
            }
            
        }
        
        /// <summary>
        /// Détruit une ligne si elle est complète, puis fait descendre les carrés du dessus.
        /// </summary>
        /// <returns>Le nombre de lignes détruites.</returns>
        public int Ligne()
        {
            int _ligneCompteur = 0;
            for (int y =0; y < 1100; y++)
            {

                if (LigneEstComplete(y))
                {

                    DetruireLigne(y);
                    DescenteLignes(y);
                    _ligneCompteur++;
                    totalLignesDetruites++;
                }
            }

            lignesDetruitesEchange = _ligneCompteur;
            return _ligneCompteur;
        }

        /// <summary>
        /// Donne le nombre total de lignes détruites.
        /// </summary>
        /// <returns>Un entier</returns>
        public int GetTotalLignesDetruites()
        {
            return totalLignesDetruites;
        }
        
        /// <summary>
        /// Donne le nombre de lignes détruites sans faire appel à Ligne().
        /// </summary>
        /// <returns>Le nombre de lignes détruites.</returns>
        public int GetLignesDetruitesEchange()
        {
            
            return lignesDetruitesEchange;
        }
        
        
        
        
        /// <summary>
        /// Détermine si une ligne est complète.
        /// </summary>
        /// <param name="y">La position y du champ de jeu.</param>
        /// <returns>
        /// Vrai si une ligne est complète.
        /// Faux sinon.
        /// </returns>
        public bool LigneCompleteEstBonus(int y)
        {


            /*for (int i = 50; i <= 500; i++)
            {
                if (i % 50 == 0)
                {
                    if (LigneEstComplete(y) && _champDeJeu.Matrice[i, y] == GameObject.Find("CarreBonus(Clone)").transform)
                    {
                        return true;
                    }
                }
                
            }*/
            
            //////
            if (LigneEstComplete(y) && Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Bonus").transform.position.y) == y)
            {
                Debug.Log("TrueeeeeEeeeEEEE");

                return true;
            }

            return false;

        }
        
        /// <summary>
        /// Détruit une ligne assignée.
        /// </summary>
        /// <param name="y">Position y de la ligne à détruire.</param>
        public void DetruireLigneBonus(int y)
        {
            for (int i = 50; i <= 500; i++) 
            {
                if (i % 50 == 0)
                { 
                    if (_champDeJeu.Matrice[i, y + 50] != null)
                    {
                        Destroy(_champDeJeu.Matrice[i, y+50].gameObject);
                    }
                }
            }
        }

        public void DescenteLignesBonus(int ligne)
        {
            for (int y = ligne+50; y < 1100 - 50; y++)
            {
                for (int x = 0; x <= 500; x++)
                {
                   
                    if (_champDeJeu.Matrice[x, y +100] != null)
                    {
                        _champDeJeu.Matrice[x, y] = _champDeJeu.Matrice[x, y + 100]; // 50?
                       
                        _champDeJeu.Matrice[x, y + 100] = null;
                        _champDeJeu.Matrice[x, y+50].gameObject.transform.position +=new Vector3(0,-1*50*2,0);
                        
                        
                    }
                }
            }
            
        }
        
        /// <summary>
        /// Détruit une ligne si elle est complète, puis fait descendre les carrés du dessus.
        /// </summary>
        /// <returns>Le nombre de lignes détruites.</returns>
        public int LigneBonus()
        {
            int _ligneCompteur = 0;
            for (int y =0; y < 1100; y++)
            {

                if (LigneCompleteEstBonus(y))
                {

                    DetruireLigneBonus(y);
                    DescenteLignesBonus(y);
                    _ligneCompteur++;
                    totalLignesDetruites++;
                }
            }

            lignesDetruitesEchange = _ligneCompteur;
            return _ligneCompteur;
        }
        
    }
    
    
}

