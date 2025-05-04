using UnityEngine;

namespace CardHouse.attacking_scripts
{
    public class WhenThisPlayerDiesRunAThing : MonoBehaviour
    {
        public string playerid;
        public bool endingGame = false;
        private void OnDisable()
        {
            RunEndGame();
        }

        private void OnDestroy()
        {
            RunEndGame();
        }

        public void RunEndGame()
        {
            if (endingGame == false)
            {
                EndGameScript endGame = FindObjectOfType<EndGameScript>();
                if (endGame != null)
                {
                    Debug.Log("Ending Game");
                    endGame.EndGame(playerid); 
                    endingGame = true;
                }
                else
                {
                    Debug.Log("No End Game GameObject in Scene");
                }
            }
            
        }
    }
}
