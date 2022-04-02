using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class Score : MonoBehaviour
    {
        private int _scoreCourant;
        public Text ScoreUI;

        public void Initialiser()
        {
            _scoreCourant = 0;
        }

        public void AjouterScore(int ligneDetruit)
        {
            _scoreCourant += (int)(100 * ligneDetruit * (1 + 0.1 * ligneDetruit));
        }

        public override string ToString()
        {
            string _stringScore = _scoreCourant.ToString();
            if (_stringScore.Length <= 10)
            {
                for (int i = _stringScore.Length; i < 10; i++)
                {
                    _stringScore = "0" + _stringScore;
                }
            }

            return _stringScore;
        }

        public void UpdateScore()
        {
            ScoreUI.text = ToString();
        }
        
    }
}