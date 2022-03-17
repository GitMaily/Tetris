
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace Tetris
{
    /// <summary>
    /// le composant de tétrominos
    /// </summary>
    public class Carre
    {
        private bool isCenter;
        private Position positionCarre;
        private TypeCarre typeCarre;

        public Carre(TypeCarre typeCarre, Position positionCarre, bool isCenter)
        {
            this.typeCarre = typeCarre;
            this.positionCarre = positionCarre;
            this.isCenter = isCenter;
        }
        
        /// <summary>
        /// pour déterminer le type d'un carre
        /// </summary>
        /// <returns>si le type d'un carre est principal, retourne true</returns>
        public bool IsCarrePrincipal()
        {
            return typeCarre == TypeCarre.Principal;
        }
        
        /// <summary>
        /// pour déterminer le type d'un carre
        /// </summary>
        /// <returns>si le type d'un carre est explosif, retourne true</returns>
        public bool IsCarreExplosif()
        {
            return typeCarre == TypeCarre.Explosif;
        }

        public Position GetPosition()
        {
            return positionCarre;
        }

        public void DescendCarre()
        {
            positionCarre.SetOrdonnee(positionCarre.GetOrdonne() - 1);
        }

        public void LeftMove()
        {
            positionCarre.SetAbscisse(positionCarre.GetAbscisse() - 1);
        }

        public void RightMove()
        {
            positionCarre.SetAbscisse(positionCarre.GetAbscisse() + 1);
        }

    }
    
    public enum TypeCarre
    {
        Principal = 0,
        Explosif = 1
    }
}


