using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Script
{
    /// <summary>
    /// Cette classe est pour affichier l'écran principal d'une partie du jeu. Y compris le champ du jeu, score,
    /// prévsion d'un tétromino et espace d'échange.
    /// </summary>
    public class EcranPrincipal : MonoBehaviour
    {
        public GameObject _border;

        
        public Transform[,] Matrice = new Transform[550, 1151];

        
        public GameObject[,] _champDuJeu;
        public GameObject[,] _espacePrevision;
        public GameObject[,] _espaceEchange;
        
        private Point _pointOriginChampDuJeu = new Point(1, 2);
        private Point _pointOriginPrevision = new Point(12, 3);
        private Point _pointOriginEspaceEchange = new Point(12, 10);
        
        public const int LargueurDuChampDuJeu = 10;
        public const int HauteurDuChampDuJeu = 20;
        private const int LongueurEspace = 4;
        
        private const int TailleCarre = 47;
        private const int IntervalleCarre = 3;

        /// <summary>
        /// Une entrée des méthodes. Ces méthodes là sont pour initialiser l'écran.
        /// </summary>
        public void Initialiser()
        {
            InitialiserEcran();
        }

        /// <summary>
        /// L'initialisation d'écran. Cette méthode afficher le champ du jeu, score, prévision d'un tétromino,
        /// espace d'échange.
        /// </summary>
        public void InitialiserEcran()
        {
            // Creer un tableau bidimentionnel en taille de 10 x 20
            _champDuJeu = new GameObject[LargueurDuChampDuJeu, HauteurDuChampDuJeu];
            _espacePrevision = new GameObject[LongueurEspace, LongueurEspace];
            _espaceEchange = new GameObject[LongueurEspace, LongueurEspace];


            // Ajouter _border qui est une image de cadre dans le tableau _champDUJeu

            for (int colonne = 0; colonne < LargueurDuChampDuJeu; colonne++)
            {
                for (int ligne = 0; ligne < HauteurDuChampDuJeu; ligne++)
                {
                    int abscisse = (_pointOriginChampDuJeu._abscisse + colonne) * (TailleCarre + IntervalleCarre);
                    int ordonne = (_pointOriginChampDuJeu._ordonne + ligne) * (TailleCarre + IntervalleCarre);

                    Vector3 coordonneCarre = new Vector3(abscisse, ordonne, 0);

                    _champDuJeu[colonne, ligne] = Instantiate(_border, coordonneCarre, Quaternion.identity);
                }
            }
            
            for (int colonne = 0; colonne < LongueurEspace; colonne++)
            {
                for (int ligne = 0; ligne < LongueurEspace; ligne++)
                {
                    int abscisse = (_pointOriginPrevision._abscisse + colonne) * (TailleCarre + IntervalleCarre);
                    int ordonne = (_pointOriginPrevision._ordonne + ligne) * (TailleCarre + IntervalleCarre);

                    Vector3 coordonneCarre = new Vector3(abscisse , ordonne + 350, 0);

                    _espacePrevision[colonne, ligne] = Instantiate(_border, coordonneCarre, Quaternion.identity);
                }
            }
            
            
            for (int colonne = 0; colonne < LongueurEspace; colonne++)
            {
                for (int ligne = 0; ligne < LongueurEspace; ligne++)
                {
                    int abscisse = (_pointOriginEspaceEchange._abscisse + colonne) * (TailleCarre + IntervalleCarre);
                    int ordonne = (_pointOriginEspaceEchange._ordonne + ligne) * (TailleCarre + IntervalleCarre);

                    Vector3 coordonneCarre = new Vector3(abscisse , ordonne + 350, 0);

                    _espaceEchange[colonne, ligne] = Instantiate(_border, coordonneCarre, Quaternion.identity);
                }
            }

        }
        
    }
}