using UnityEngine;

namespace CardHouse.attacking_scripts
{
    public class MenuManager : MonoBehaviour
    {
        public string gamePlaySceneName = "Ccg";
        public void PlayGame() 
        {
            CommonlyUsedStaticMethods.OpenSceneWithSceneName(gamePlaySceneName);
        }

        public void ExitGame()
        {
            CommonlyUsedStaticMethods.QuitGame();
        }
    }
}
