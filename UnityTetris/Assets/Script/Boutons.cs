using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using UnityEngine.EventSystems.PointerEventData.InputButton;



namespace Script
{
    public class Boutons : MonoBehaviour
    {
        public float temps;
        public float tempsChute = 0.5f;

        private bool isPressed;
        //int keyFrame = 0;


        /* On va initialiser les touches ainsi que décrire leur comportements
         * On réalise des test de sortie 
         */
        /*public Boutons(bool isPressed)
        {
            this.isPressed = isPressed;
        }
        */

        /* Ici on peut tenter d'implémenter le maintient de bouton et donc le mouvement en continu d'une pièce. Pour l'instant on laisse en mode "un par un"
             
        namespace Tetris
        {
            public class Test1 : MonoBehaviour
            {
                // pour enregistrer le nombre de frame quand un bouton est pressé
                int keyFrame = 0;
            
                // Update is called once per frame
                void Update()
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        Debug.Log("A Down");
                    }
             
                    if (Input.GetKey(KeyCode.A))
                    {
                        keyFrame++;
                        Debug.Log("A est pressé pendent" + keyFrame + "frame");
                    }
            
                    if (Input.GetKeyUp(KeyCode.A))
                    {
                        keyFrame = 0;
                        Debug.Log("A Up");
                    }
                }
            }
        }*/




    
        //Création d'un objet tetro
        public GameObject tetro;
        
        //Instance de TetroT
        //private Tetrot _tetrot;
        
        //Une instance move de la classe Mouvement
        private Mouvement _move;

       

        public void BoutonDroit()
        {
            //_tetrot = tetro.GetComponent<Tetrot>();
            _move = tetro.GetComponent<Mouvement>();
            
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //_tetrot.Droit();
                _move.ADroite();
            }
            
            
        }
        public void BoutonGauche()
        {
            //_tetrot = tetro.GetComponent<Tetrot>();
            _move = tetro.GetComponent<Mouvement>();
            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //_tetrot.Droit();
                _move.AGauche();
            }
        }

        public void BoutonHaut()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {   
                _move.RotationDroite();
            }
            
        }
        
        public void BoutonBas()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {   
                _move.RotationGauche();
            }
            
        }

        public void BarreEspace()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _move.Descente();
                
            }
        }
        
        private void Update()
        {
            BoutonHaut();
            BoutonBas();
            BoutonDroit();
            BoutonGauche();
            BarreEspace();

            /*if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Flèche gauche appuyée");
                transform.position += new Vector3(-1, 0, 0);


            }*/

            /*if (Input.GetKey(KeyCode.LeftArrow))
            {
                keyFrame++;
                Debug.Log("flèche gauche maintenue");
                Debug.Log("A est pressé pendent" + keyFrame + "frame");
        
            }
            */



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

            if (Time.time - temps > tempsChute)
            {
                transform.position += new Vector3(0, -1, 0);
                temps = Time.time;
            }

        }
    }
}


        

    
