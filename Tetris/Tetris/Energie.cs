namespace Tetris
{
    /// <summary>
    /// Energie est utilisé pour l'échange
    /// </summary>
    public class Energie
    {
        private int total;

        public Energie(int total)
        {
            this.total = total;
        }

        public Energie() : this(0)
        {
            
        }
        
        /// <summary>
        /// réinitialiser la valeur de variable <c>total</c>
        /// </summary>
        public void Reset()
        {
            total = 0;
        }

        /// <summary>
        /// ajouter l'énergie selon le destruction des lignes.
        /// </summary>
        public void AjouterEnergie()
        {
            /*
             todo
             obtenir un methode pour calculer l'énergie à ajouter
             */
        }
        
        /// <summary>
        /// Quand le joueur utilise un échange, l'énergie se diminue.
        /// </summary>
        public void DiminuerEnergie()
        {
            /*
             todo
             dicuter utlise une foi l'échange consomme combien d'énergie
             */
        }
    }
}