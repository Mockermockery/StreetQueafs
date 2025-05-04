using System.Collections;
using TMPro;
using UnityEngine;

namespace CardHouse.attacking_scripts
{
    public class EndGameScript : MonoBehaviour
    {
        public GameObject endGameGameObject;
        public TMP_Text gameOverText;
        public string mainMenuSceneName = "Main Menu";

        private void Awake()
        {
            endGameGameObject.gameObject.SetActive(false);
        }

        public void EndGame(string gameOverTextToPrint)
        {
            endGameGameObject.gameObject.SetActive(true);
            if (gameOverTextToPrint == "Player1")
            {
                gameOverText.text = "Chad Wins!!";
            }
            else if (gameOverTextToPrint == "Player2")
            {
                gameOverText.text = "Normie Wins!";
            }
            else
            {
                gameOverText.text = gameOverTextToPrint;
            }
            StartCoroutine(DoSomethingAfterDelay());
        }
        
        IEnumerator DoSomethingAfterDelay()
        {
            Debug.Log("Waiting 2 seconds...");
            yield return new WaitForSeconds(2f);
            Debug.Log("Done waiting! Do the thing.");
            CommonlyUsedStaticMethods.OpenSceneWithSceneName(mainMenuSceneName);
            // Place your code here (e.g., play sound, damage player, etc.)
        }
    }
}
