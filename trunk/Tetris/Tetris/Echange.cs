
namespace Tetris
{
    public class Echange
    {
        private Energie energie;

        public Echange()
        {
            energie = new Energie();
        }
        
        public void Echanger(TypeTetromino tetrominoCourrant, EspaceEchange espaceEchange)
        {
            if(//Energie est suffisante)
            {
                TypeTetromino auxiliaire = tetrominoCourrant;
                tetrominoCourrant = espaceEchange.GetType();
                espaceEchange.SetType(auxiliaire);
                energie.DiminuerEnergie();
            }
            else //Energie n'est pas suffisante
            
            
        }
    }
}