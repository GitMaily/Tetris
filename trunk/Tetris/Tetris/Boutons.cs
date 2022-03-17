using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.EventSystems.PointerEventData.InputButton;



namespace Tetris
{
    public class Boutons : MonoBehaviour
    {
        private bool isPressed;

        
        /* On va initialiser les touches ainsi que décrire leur comportements
         * On réalise des test de sortie d'abord
         */
        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Flèche gauche appuyée");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Flèche droite appuyée");
            }
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Flèche haut appuyée");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Flèche bas appuyée");
            }
            
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Debug.Log("Tabulation appuyée : échange");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Espace appuyé : faire descendre la pièce rapidement");
            }
            
            //Eventuellement essayer d'implémenter le bouton maintenu en continu
            
            /*if (Input.GetKeyDown("Space"))
            {
                Debug.Log("Espace appuyé : faire descendre la pièce rapidement");
            }
            */
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Echap appuyée");
            }
            
            
            //bool left = Input.GetKeyDown(KeyCode.LeftArrow);

            
            
        }

        
        
    }
}