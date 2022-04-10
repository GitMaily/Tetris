using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace Script
{
    public class DestructionLigne : MonoBehaviour
    {
        
        public GameObject tetroCourrant;
        private TetroCourrant _tetroCourrant;
        
        private GameObject[] _positionVerrou;
        public GameObject[] _positionBonus;

        public GameObject champDeJeu;
        private EcranPrincipal _champDeJeu;


        public int totalLignesDetruites;
        public int lignesDetruitesEchange;
        public int lignesDetruitesBonus;
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
            //Debug.Log("Une ligne est complete");
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

                    _tetroCourrant.GetListeVerrou().Remove(_champDeJeu.Matrice[i, y].transform.position);
                    _tetroCourrant.GetNomBlock().Remove(_champDeJeu.Matrice[i, y].gameObject.name);

                    
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

        public bool PossedeBonus(int y)
        {
            _positionBonus = GameObject.FindGameObjectsWithTag("BonusVerrou");

            foreach (GameObject bonus in _positionBonus) // pour chaque carré bonus placés
            {
                if (Mathf.RoundToInt(bonus.transform.position.y) == Mathf.RoundToInt(y)) // on vérifie si la position y du carré bonus correspond à la ligne y rentrée en paramètre
                {
                    return true; // Un des carrés possède donc un y identique à celui passé en paramètre
                }
            }

            return false;
        }
        
        
        /// <summary>
        /// Détermine si la ligne complète comporte un carré Bonus.
        /// </summary>
        /// <param name="y">La position y du champ de jeu.</param>
        /// <returns>
        /// Vrai si une ligne complète comporte un carré Bonus.
        /// Faux sinon.
        /// </returns>
        public bool LigneCompleteEstBonus(int y)
        {

            _positionBonus = GameObject.FindGameObjectsWithTag("BonusVerrou");

            if (GameObject.FindGameObjectWithTag("BonusVerrou")) // On cherche s'il existe un carré bonus qui a été verrouillé.
            {
                // On vérifie d'abord que la ligne est complète
                if (LigneEstComplete(y)) //&& Mathf.RoundToInt(GameObject.FindGameObjectWithTag("BonusVerrou").transform.position.y) == Mathf.RoundToInt(y))
                {
                    foreach (GameObject bonus in _positionBonus) // pour chaque carré bonus placés
                    {
                        if (Mathf.RoundToInt(bonus.transform.position.y) == Mathf.RoundToInt(y)) // on vérifie si la position y du carré bonus correspond à la ligne y rentrée en paramètre
                        {
                            return true; // Un des carrés possède donc un y identique à celui passé en paramètre
                        }
                    }
                }
            }
            

            return false;

        }
        
        /// <summary>
        /// Détruit une ligne assignée comportant un carré bonus.
        /// </summary>
        /// <param name="y">Position y de la ligne à détruire.</param>
        public void DetruireLigneBonus(int y)
        {
            for (int i = 50; i <= 500; i++) 
            {
                if (i % 50 == 0)
                { 
                    if (_champDeJeu.Matrice[i, y ] != null)
                    {
                        Destroy(_champDeJeu.Matrice[i, y].gameObject);
                        _tetroCourrant.GetListeVerrou().Remove(_champDeJeu.Matrice[i, y].transform.position);
                        _tetroCourrant.GetListeVerrouBonus().Remove(_champDeJeu.Matrice[i, y].transform.position);

                    }
                }
            }
        }

        public void DescenteLignesBonus(int ligne)
        {
            for (int y = ligne; y < 1100 - 50; y++)
            {
                for (int x = 0; x <= 500; x++)
                {
                   
                    if (_champDeJeu.Matrice[x, y +50] != null)
                    {
                        _champDeJeu.Matrice[x, y] = _champDeJeu.Matrice[x, y + 50]; // 50?
                       
                        _champDeJeu.Matrice[x, y + 50] = null;
                        _champDeJeu.Matrice[x, y].gameObject.transform.position +=new Vector3(0,-1*50,0);
                        
                        
                    }
                }
            }
            
        }

        /// <summary>
        /// Cache un canvas après un certain nombre de temps.
        /// </summary>
        /// <param name="canvas">Le canvas à cacher</param>
        /// <param name="secondes">Le nombre de secondes à attendre avant de cacher le canvas</param>
        /// <param name="estActif">Vrai si on veut montrer le canvas, Faux sinon</param>
        /// <returns>Retourne une routine (doit être appelée dans un StartCoroutine</returns>
        IEnumerator CacherCanvas (GameObject canvas, float secondes, bool estActif = false)
        {
            //int frame;
            //yield return new WaitUntil(() => frame >= 10);
            
            yield return new WaitForSeconds(secondes); // secondes à attendre avant de cacher le canvas
            canvas.SetActive(estActif);
            

        }
        /// <summary>
        /// Détruit un canvas après un certain nombre de temps.
        /// </summary>
        /// <param name="canvasDestroy">Le canvas à détruire</param>
        /// <param name="secondes">Le nombre de secondes à attendre avant de détruire le canvas</param>
        /// <returns>Retourne une routine (doit être appelée dans un StartCoroutine)</returns>
        IEnumerator DestroyCanvas (GameObject canvasDestroy, float secondes)
        {
            yield return new WaitForSeconds(secondes); // secondes à attendre avant de détruire le canvas
            Destroy(canvasDestroy);
        }

        
        public GameObject ligneBonusCanvas;
        public GameObject ligneParent;

        /// <summary>
        /// Détruit une ligne si elle est complète et comporte un carré bonus, puis fait descendre les carrés du dessus.
        /// </summary>
        /// <returns>Le nombre de lignes détruites.</returns>
        public int LigneBonus()
        {
            GameObject ligneCanvas;
            int _ligneBonusCompteur = 0;
            for (int y =0; y < 1100; y++)
            {
                if (LigneCompleteEstBonus(y))
                {
                    // Faire apparaître un fond blanc à chaque fois qu'une ligne Bonus est détruite
                    ligneCanvas = Instantiate(ligneBonusCanvas, new Vector3(275, y, 0), Quaternion.identity);
                    ligneCanvas.transform.SetParent(ligneParent.transform);
                    StartCoroutine(DestroyCanvas(ligneCanvas, 0.5f));


                    //ligneBonusCanvas.transform.position = new Vector3(275, y, 0);
                    //ligneBonusCanvas.SetActive(true);
                    //StartCoroutine(CacherCanvas(ligneBonusCanvas, 0.3f));

                    DetruireLigneBonus(y);
                    DescenteLignesBonus(y);
                    
                    _ligneBonusCompteur++;
                    totalLignesDetruites++;
                }
            }

            lignesDetruitesBonus = _ligneBonusCompteur;
            return _ligneBonusCompteur;
        }
        
        
        public int GetLignesBonusDetruites()
        {
            
            return lignesDetruitesBonus;
        }
        
    }
    
    
}

