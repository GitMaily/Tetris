namespace Tetris
{
    /// <summary>
    /// le composant de tétrominos
    /// </summary>
    public class Carre
    {
        private TypeCarre typeCarre;

        public Carre(TypeCarre typeCarre)
        {
            this.typeCarre = typeCarre;
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
    }
    
    public enum TypeCarre
    {
        Principal = 0,
        Explosif = 1
    }
}


