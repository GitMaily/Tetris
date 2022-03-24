using UnityEngine;
using UnityEngine.EventSystems;

namespace Script
{
    public class BoutonsBis : MonoBehaviour
    {
        public GameObject tetroCourrant;

        private TetroCourrant _tetroCourrant;

        public void Initialiser()
        {
            _tetroCourrant = tetroCourrant.GetComponent<TetroCourrant>();
        }

        public void BottonCheck()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _tetroCourrant.ADroite();
            }
            
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _tetroCourrant.AGauche();
            }
        }
        
        
    }
}