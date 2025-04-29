using UnityEngine;

namespace RapidAssetPrototypes.CardHouse.UI.Scripts
{
    public class MenuManager : MonoBehaviour
    {
        public string gamePlaySceneName = "Ccg";
        public void PlayGame() 
        {
            Commonly_Used_Static_Methods.CommonlyUsedStaticMethods.OpenSceneWithSceneName(gamePlaySceneName);
        }

        public void ExitGame()
        {
            Commonly_Used_Static_Methods.CommonlyUsedStaticMethods.QuitGame();
        }
    }
}
