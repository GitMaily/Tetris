namespace Tetris
{
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

        public void AjouterEnergie()
        {
            /*
             todo
             obtenir un methode pour calculer l'énergie à ajouter
             */
        }

        public void DiminuerEnergie()
        {
            /*
             todo
             dicuter utlise une foi l'échange consomme combien d'énergie
             */
        }
    }
}