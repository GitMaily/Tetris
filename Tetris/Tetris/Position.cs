namespace Tetris
{
    /// <summary>
    /// La Position dans le champ du jeu.
    /// </summary>
    public class Position
    {
        private int abscisse;
        private int ordonnee;

        public Position(int abscisse, int ordonnee)
        {
            this.abscisse = abscisse;
            this.ordonnee = ordonnee;
        }

        public int GetAbscisse()
        {
            return abscisse;
        }

        public int GetOrdonne()
        {
            return ordonnee;
        }

        public void SetAbscisse(int abscisse)
        {
            this.abscisse = abscisse;
        }

        public void SetOrdonnee(int ordonnee)
        {
            this.ordonnee = ordonnee;
        }
    }
}