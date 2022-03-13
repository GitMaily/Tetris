using System;

namespace Tetris
{
    /// <summary>
    /// EspaceEchange est pour indiquer des Tétrominos échangé par le joueur.
    /// Elle est classe concernant l'interface. 
    /// </summary>
    public class EspaceEchange
    {
        private TypeTetromino tertominoDansEspaceEchange;

        public EspaceEchange()
        {
            Random random = new Random();
            tertominoDansEspaceEchange = (TypeTetromino) random.Next(0,7);
        }

        public TypeTetromino GetType()
        {
            return tertominoDansEspaceEchange;
        }

        public void SetType(TypeTetromino tetromino)
        {
            tertominoDansEspaceEchange = tetromino;
        }
        
        //todo affichier écran d'espace echange en utilisant code unity.
    }
}